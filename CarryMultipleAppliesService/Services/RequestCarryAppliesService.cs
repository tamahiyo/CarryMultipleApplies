using CarryMultipleAppliesCommon.Log;
using CarryMultipleAppliesDataAccess;
using CarryMultipleAppliesDataAccess.DataTier.Core;
using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Persistance;
using CarryMultipleAppliesDataAccess.Models;
using CarryMultipleAppliesService.Common;
using CarryMultipleAppliesService.Enum;
using CarryMultipleAppliesService.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CarryMultipleAppliesServices
{
    public class RequestCarryAppliesService
    {

        private const int WAIT_PAGEVIEW_SECONDS = 5;

        public RequestAppliesModel _model;

        private int retryCount { get; set; }

        private DateTime now { get; set; }

        private List<M_ChooseableDomains> chooseableDomainList { get; set; }

        List<string> errorAppliesSerialList = new List<string>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model"></param>
        public RequestCarryAppliesService(RequestAppliesModel model)
        {
            this._model = model;
        }

        /// <summary>
        /// リクエスト送信(メイン)
        /// </summary>
        public List<string> SendAppliesInfo()
        {
            now = DateTime.Now;

            var options = new ChromeOptions();
            // シークレットモードで表示
            options.AddArguments("incognito");

            // cmd起動抑制
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            using (IWebDriver driver = new ChromeDriver(driverService, options))
            using (var context = new UnitOfWorks(new CarryMultipleAppliesModel()))
            using (var transaction = context.BeginTran())
            {
                driver.Manage().Window.Maximize();

                try
                {
                    chooseableDomainList = context.MChooseableDomains.GetAll().ToList();

                    foreach (var appliesStore in this._model.AppliesStoreList)
                    {
                        Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Info, appliesStore.StoreEventName + "の応募を開始");
                        foreach (var serialNo in appliesStore.SerialNoList)
                        {
                            driver.Url = appliesStore.AppliesUrl;
                            Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Info, serialNo + "シリアル入力に遷移");
                            this.InputSerialNoDisplay(driver, context, appliesStore, serialNo);
                        }
                    }

                    this.AddApplyUsers(context);
                    transaction.Commit();

                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Error, ex.Message);
                }

                return errorAppliesSerialList;
            }
            
        }

        /// <summary>
        /// シリアルNo入力画面→応募者情報入力に遷移
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="context"></param>
        /// <param name="storeEvent"></param>
        /// <param name="serialNo"></param>
        private void InputSerialNoDisplay(IWebDriver driver, IUnitOfWorks context, RequestAppliesModel.AppliesStore storeEvent, string serialNo)
        {
            string prevUrl = driver.Url.ToString();

            Thread.Sleep(WAIT_PAGEVIEW_SECONDS);
            string[] serialNoSplit = serialNo.Split('-');
            if (serialNoSplit.Count() != 4)
            {
                errorAppliesSerialList.Add(serialNo);
                return;
            }
            driver.FindElement(By.Name("SU_SERIAL_N1_001_001")).SendKeys(serialNoSplit[0]);
            driver.FindElement(By.Name("SU_SERIAL_N2_001_001")).SendKeys(serialNoSplit[1]);
            driver.FindElement(By.Name("SU_SERIAL_N3_001_001")).SendKeys(serialNoSplit[2]);
            driver.FindElement(By.Name("SU_SERIAL_N4_001_001")).SendKeys(serialNoSplit[3]);

            // スクショ保存
            this.TakeScreenShot(driver, storeEvent, serialNo, "シリアル入力");

            // ご応募はこちらを押下　
            driver.FindElement(By.XPath("//div[@id='oubo_btn']/a")).Click();

            if (IsDisplayTransition(prevUrl, driver.Url.ToString()))
            {
                Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Info, serialNo + "応募者情報入力に遷移");
                this.InputApplisUserInfo(driver, context, storeEvent, serialNo);                
            }
            else
            {
                string message = Regex.Replace(driver.FindElement(By.XPath("//div[@class='alert']")).Text, @"<[^>]*>", String.Empty);
                Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Error, serialNo + "シリアル入力エラー");
                this.AddApplyHistory(context, storeEvent.StoreEventId, serialNo, (int)ApplieStatusType.応募エラー, message);
                errorAppliesSerialList.Add(serialNo);
            }
        }

        /// <summary>
        /// 応募者情報入力→確認画面に遷移
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="context"></param>
        /// <param name="storeEvent"></param>
        /// <param name="serialNo"></param>
        private void InputApplisUserInfo(IWebDriver driver, IUnitOfWorks context, RequestAppliesModel.AppliesStore storeEvent, string serialNo)
        {
            string prevUrl = driver.Url.ToString();

            Thread.Sleep(WAIT_PAGEVIEW_SECONDS);

            // 氏名
            driver.FindElement(By.Name("KO_NAM1")).SendKeys(this._model.LastName);
            driver.FindElement(By.Name("KO_NAM2")).SendKeys(this._model.FirstName);
            driver.FindElement(By.Name("KO_YOMI1")).SendKeys(this._model.LastNameHiragana);
            driver.FindElement(By.Name("KO_YOMI2")).SendKeys(this._model.FirstNameHiragana);

            // 年代
            var ageElement = driver.FindElement(By.Name("KO_AGE2"));
            new SelectElement(ageElement).SelectByValue(this._model.AgeName);

            // 性別
            driver.FindElement(By.XPath("//input[@value='" + this._model.SexName + "']")).Click();

            // 住所
            driver.FindElement(By.Name("KO_YUBIN")).SendKeys(this._model.Zipcode.Replace("-", ""));
            var prefectureElement = driver.FindElement(By.Name("KO_ADD1"));
            new SelectElement(prefectureElement).SelectByValue(this._model.PrefectureName);
            
            driver.FindElement(By.Name("KO_ADD2")).SendKeys(this._model.City);
            driver.FindElement(By.Name("KO_ADD3")).SendKeys(this._model.StreetBunchName);
            driver.FindElement(By.Name("KO_ADD4")).SendKeys(this._model.BuildingName);

            // 電話番号
            driver.FindElement(By.Name("KO_TEL")).SendKeys(this._model.PhoneNumber.Replace("-", ""));

            // 職業
            var jobElement = driver.FindElement(By.Name("KO_JOB"));
            new SelectElement(jobElement).SelectByValue(this._model.JobName);

            // メールアドレス
            string[] mailAddress = this._model.MailAddress.Split('@');
            driver.FindElement(By.Name("KO_EMAIL_M1")).SendKeys(mailAddress[0]);
            driver.FindElement(By.Name("KO_EMAIL_M_K1")).SendKeys(mailAddress[0]);
            
            if (this.chooseableDomainList.Where(w => w.DomainName == mailAddress[1]).Any())
            {
                // selectboxから選択するドメインの場合
                var mailAddressElement = driver.FindElement(By.Name("KO_EMAIL_M21"));
                new SelectElement(mailAddressElement).SelectByValue(mailAddress[1]);
                var mailAddressConfirmElement = driver.FindElement(By.Name("KO_EMAIL_M_K21"));
                new SelectElement(mailAddressConfirmElement).SelectByValue(mailAddress[1]);
            }
            else
            {
                // ドメイン名を入力
                driver.FindElement(By.Name("KO_EMAIL_M22")).SendKeys(mailAddress[1]);
                driver.FindElement(By.Name("KO_EMAIL_M_K22")).SendKeys(mailAddress[1]);
            }
            

            // 同意する
            driver.FindElement(By.Name("agreeCheck")).Click();

            // スクショ保存
            this.TakeScreenShot(driver, storeEvent, serialNo, "応募者情報入力");

            // 確認ボタン押下
            driver.FindElement(By.XPath("//div[@id='kakunin_btn']/a")).Click();
            if (IsDisplayTransition(prevUrl, driver.Url.ToString()))
            {
                Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Info, serialNo + "応募確認画面に遷移");
                this.ConfirmToSendApplies(driver, context, storeEvent, serialNo);
            }
            else
            {
                string errorMessage = string.Empty;
                var elementList = driver.FindElements(By.ClassName("error"));
                foreach (IWebElement element in elementList)
                {
                    errorMessage += element.Text + "\r\n";
                }

                Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Error, serialNo + "応募者情報入力エラー");
                errorAppliesSerialList.Add(serialNo);
                
            }
        }

        /// <summary>
        /// 確認画面→応募完了画面に遷移
        /// </summary>
        /// <remarks>確認画面で停止の場合、応募履歴に登録</remarks>
        /// <param name="driver"></param>
        /// <param name="context"></param>
        /// <param name="storeEvent"></param>
        /// <param name="serialNo"></param>
        private void ConfirmToSendApplies(IWebDriver driver, IUnitOfWorks context, RequestAppliesModel.AppliesStore storeEvent, string serialNo)
        {
            string prevUrl = driver.Url.ToString();

            Thread.Sleep(WAIT_PAGEVIEW_SECONDS);
            this.TakeScreenShot(driver, storeEvent, serialNo, "確認画面");
            if (!this._model.IsConfirmStop)
            {
                // 入力内容送信ボタン押下
                driver.FindElement(By.XPath("//div[@id='sousin_btn']/a")).Click();
                if (IsDisplayTransition(prevUrl, driver.Url.ToString()))
                {
                    Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Info, serialNo + "応募完了画面に遷移");
                    this.AppliesEvent(driver, context, storeEvent, serialNo);                    
                }
                return;
            }
            Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Info, serialNo + "応募確認画面で停止");
            this.AddApplyHistory(context, storeEvent.StoreEventId, serialNo, (int)ApplieStatusType.応募未済);
        }

        /// <summary>
        /// 完了画面を表示し、応募履歴に登録
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="context"></param>
        /// <param name="storeEvent"></param>
        /// <param name="serialNo"></param>
        private void AppliesEvent(IWebDriver driver, IUnitOfWorks context, RequestAppliesModel.AppliesStore storeEvent, string serialNo)
        {
            Thread.Sleep(WAIT_PAGEVIEW_SECONDS);
            Logger.Write((int)CarryMultipleAppliesCommon.Log.LogLevel.Info, serialNo + "応募完了");
            this.TakeScreenShot(driver, storeEvent, serialNo, "完了画面");
            this.AddApplyHistory(context, storeEvent.StoreEventId, serialNo, (int)ApplieStatusType.応募済);                        
        }

        /// <summary>
        /// 画面遷移したか判定
        /// </summary>
        /// <param name="prevUrl"></param>
        /// <param name="currentUrl"></param>
        /// <returns></returns>
        private bool IsDisplayTransition(string prevUrl, string currentUrl)
        {
            if (!prevUrl.Equals(currentUrl) && !prevUrl.Contains(currentUrl))
            {
                return true;
            }

            this.retryCount++;
            if (this.retryCount < 3)
            {
                // 画面遷移されてない場合、5秒置いて再起処理
                Thread.Sleep(WAIT_PAGEVIEW_SECONDS);
                return this.IsDisplayTransition(prevUrl, currentUrl);
            }

            this.retryCount = 0;
            return false;

        }

        /// <summary>
        /// 応募履歴に登録
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeEventId"></param>
        /// <param name="serialNo"></param>
        /// <param name="ApplieStatusType"></param>
        /// <param name="message"></param>
        private void AddApplyHistory(IUnitOfWorks context, int storeEventId, string serialNo, int ApplieStatusType, string message = null)
        {

            var applyHistory = new T_ApplyHistories()
            {
                StoreEventId = storeEventId,
                UserName = Environment.UserName,
                SerialNo = serialNo,
                LastName = this._model.LastName,
                FirstName = this._model.FirstName,
                LastNameHiragana = this._model.LastNameHiragana,
                FirstNameHiragana = this._model.FirstNameHiragana,
                AgeId = this._model.AgeId.Value,
                Sex = this._model.SexId.Value,
                Zipcode = this._model.Zipcode,
                PrefectureId = this._model.PrefectureId.Value,
                City = this._model.City,
                StreetBunchName = this._model.StreetBunchName,
                BuildingName = this._model.BuildingName,
                PhoneNumber = this._model.PhoneNumber,
                JobId = this._model.JobId.Value,
                MailAddress = this._model.MailAddress,
                AppliesStatusType = ApplieStatusType,
                AppliesStatusMessage = message,
                InsertDate = this.now.ToString(),
                InsertUser = Environment.UserName,
                UpdateDate = this.now.ToString(),
                UpdateUser = Environment.UserName,
            };

            context.TApplyHistories.Add(applyHistory);
            context.Complete();
        }

        /// <summary>
        /// 最後の応募履歴と応募者情報が異なっていたら登録
        /// </summary>
        /// <param name="context"></param>
        private void AddApplyUsers(IUnitOfWorks context)
        {
            var applyUser = context.TApplyUsers.GetTAppliesUserByUserName(Environment.UserName);
            var usersAppliesHistory = context.TApplyHistories.GetTAppliesHistoryByUserName(Environment.UserName);
            if (!ObjectCompareHelper.Compare(applyUser, usersAppliesHistory))
            {
                var newApplyUser = new T_ApplyUsers()
                {
                    UserName = Environment.UserName,
                    LastName = this._model.LastName,
                    FirstName = this._model.FirstName,
                    LastNameHiragana = this._model.LastNameHiragana,
                    FirstNameHiragana = this._model.FirstNameHiragana,
                    AgeId = this._model.AgeId.Value,
                    Sex = this._model.SexId.Value,
                    Zipcode = this._model.Zipcode,
                    PrefectureId = this._model.PrefectureId.Value,
                    City = this._model.City,
                    StreetBunchName = this._model.StreetBunchName,
                    BuildingName = this._model.BuildingName,
                    PhoneNumber = this._model.PhoneNumber,
                    JobId = this._model.JobId.Value,
                    MailAddress = this._model.MailAddress,
                    InsertDate = this.now.ToString(),
                    InsertUser = Environment.UserName,
                    UpdateDate = this.now.ToString(),
                    UpdateUser = Environment.UserName,
                };

                context.TApplyUsers.Add(newApplyUser);
                context.Complete();
            }

        }


        /// <summary>
        /// スクリーンショット撮影
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="storeEvent"></param>
        /// <param name="serialNo"></param>
        /// <param name="diaplayName"></param>
        private void TakeScreenShot(IWebDriver driver, RequestAppliesModel.AppliesStore storeEvent, string serialNo, string diaplayName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            object[] productarray = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            SafeCreateDirectory(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), ((AssemblyProductAttribute)productarray[0]).Product, now.ToString("yyyyMMddHHmmss"), storeEvent.StoreEventName));
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), ((AssemblyProductAttribute)productarray[0]).Product, now.ToString("yyyyMMddHHmmss"), storeEvent.StoreEventName, serialNo + diaplayName + ".png");
            ss.SaveAsFile(file);
        }

        /// <summary>
        /// ディレクトリ作成
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static DirectoryInfo SafeCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }
            return Directory.CreateDirectory(path);
        }
    }
}
