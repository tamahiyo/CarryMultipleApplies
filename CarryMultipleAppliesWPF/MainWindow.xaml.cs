using CarryMultipleAppliesCommon.Log;
using CarryMultipleAppliesDataAccess;
using CarryMultipleAppliesDataAccess.DataTier.Core;
using CarryMultipleAppliesDataAccess.DataTier.Persistance;
using CarryMultipleAppliesDataAccess.Models;
using CarryMultipleAppliesService.Enum;
using CarryMultipleAppliesService.Models;
using CarryMultipleAppliesServices;
using CarryMultipleAppliesWPF.ViewModels.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace CarryMultipleAppliesWPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTable StoreEventDt = new DataTable();

        public DataTable AppliesHistoryDt = new DataTable();
        public List<ComboBoxSet> StoreEventList { get; set; }

        public int initSelectEventId { get; set; }

        public MainWindow()
        {
            new CarryMultipleAppliesService.Services.InitialData().InitData();
            InitializeComponent();
            Init();
            this.DataContext = this;
        }

        #region 初期化

        /// <summary>
        /// 各種初期化
        /// </summary>
        public void Init()
        {
            string user = Environment.UserName;
            this.InitStoreEventDataTable();
            this.InitAppliesHistoryDataTable();
            using (var context = new UnitOfWorks(new CarryMultipleAppliesModel()))
            {
                this.CreateEventComboBox(context);
                this.CreateJoxComboBox(context);
                this.CreateAgeComboBox(context);
                this.CreatePrefectureComboBox(context);
                this.SetAppliesUserInfo(context);
                this.SetAppliesHistories(GetAppliesHistories(context));
            }
        }

        /// <summary>
        /// 店舗別イベントのColumn定義
        /// </summary>
        private void InitStoreEventDataTable()
        {
            StoreEventDt.Columns.Add(new DataColumn("StoreEventId", typeof(int)));
            StoreEventDt.Columns.Add(new DataColumn("SerialNo", typeof(string)));
        }

        /// <summary>
        /// 応募履歴のColumn定義
        /// </summary>
        private void InitAppliesHistoryDataTable()
        {
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieDateTime", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieStoreEvent", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieSerialNo", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieStatus", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieErrorMessage", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieFullName", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieFullNameHiragana", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieAge", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieJob", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieSex", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieAddress", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("AppliePhoneNumber", typeof(string)));
            AppliesHistoryDt.Columns.Add(new DataColumn("ApplieMailAddress", typeof(string)));
        }

        #endregion

        #region Combobox作成

        /// <summary>
        /// イベント選択用ComboBox作成
        /// </summary>
        /// <param name="context"></param>
        private void CreateEventComboBox(IUnitOfWorks context)
        {
            EventComboBox.ItemsSource = context.MEvents.GetAll()
                                .OrderByDescending(o => o.EventId)
                                .ToDictionary(
                                    dict => dict.EventId,
                                    dict => dict.EventName
                                );
        }

        /// <summary>
        /// 職業選択用ComboBox作成
        /// </summary>
        /// <param name="context"></param>
        private void CreateJoxComboBox(IUnitOfWorks context)
        {
            JobComboBox.ItemsSource = context.MJobs.GetAll()
                                        .OrderBy(o => o.JobId)
                                        .ToDictionary(
                                            dict => dict.JobId,
                                            dict => dict.JobName
                                        );
        }

        /// <summary>
        /// 年代選択用ComboBox作成
        /// </summary>
        /// <param name="context"></param>
        private void CreateAgeComboBox(IUnitOfWorks context)
        {
            AgeComboBox.ItemsSource = context.MAges.GetAll()
                                        .OrderBy(o => o.AgeId)
                                        .ToDictionary(
                                            dict => dict.AgeId,
                                            dict => dict.AgeName
                                        );
        }

        /// <summary>
        /// 都道府県選択用ComboBox作成
        /// </summary>
        /// <param name="context"></param>
        private void CreatePrefectureComboBox(IUnitOfWorks context)
        {
            PrefectureComboBox.ItemsSource = context.MPrefectures.GetAll()
                                        .OrderBy(o => o.PrefectureId)
                                        .ToDictionary(
                                            dict => dict.PrefectureId,
                                            dict => dict.PrefectureName
                                        );
        }

        #endregion

        #region 各種イベント

        /// <summary>
        /// イベント選択変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StoreEventList = new List<ComboBoxSet>();
            int? selectEventId = this.EventComboBox.SelectedValue as int?;
            if (selectEventId.HasValue)
            {
                using (var context = new UnitOfWorks(new CarryMultipleAppliesModel()))
                {
                    var storeEventList = context.MStoreEvents.GetMStoreEventsByEventId(selectEventId.Value)
                                                            .OrderBy(o => o.StoreEventId)
                                                            .Select(s => new ComboBoxSet()
                                                            {
                                                                ItemText = s.StoreEventName,
                                                                ItemValue = s.StoreEventId
                                                            })
                                                            .ToList(); 
                    StoreEventComboBox.ItemsSource = storeEventList;

                    // DataGrid内の店舗イベントのSelectedItemが変更してしまうため、Gridが0件の時のみバインドを行う
                    if (this.StoreEventGrid.Items.Count == 0)
                    {
                        StoreEventDataGridComboBox.ItemsSource = storeEventList;
                    }
                    AppliseEventPossible(context);
                }
            }

        }

        /// <summary>
        /// ヘッダー部、店舗イベント選択変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreEventComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.StoreEventComboBox.SelectedItem != null && this.InputSerialNo.Text != "")
            {
                this.Submit.IsEnabled = true;
            }
        }

        /// <summary>
        /// ヘッダー部、シリアルNo変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputSerialNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.StoreEventComboBox.SelectedItem != null && this.InputSerialNo.Text != "")
            {
                this.Submit.IsEnabled = true;
            }
        }

        /// <summary>
        /// Submitボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MainWindowSubmitBtnModel submitBtnContent = (MainWindowSubmitBtnModel)Enum.Parse(typeof(MainWindowSubmitBtnModel), this.Submit.Content.ToString());

            if (submitBtnContent == MainWindowSubmitBtnModel.追加)
            {
                this.StoreEventDt.Rows.Add(this.StoreEventComboBox.SelectedValue, this.InputSerialNo.Text);
                this.StoreEventGrid.ItemsSource = this.StoreEventDt.DefaultView;
                this.StoreEventComboBox.SelectedItem = null;
                this.InputSerialNo.Text = "";
                this.Submit.IsEnabled = false;
                this.AppliesBtn.IsEnabled = true;

            }

        }

        /// <summary>
        /// 選択Tab変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.StoreEventComboBox.SelectedItem = null;
            this.InputSerialNo.Text = null;

            switch (this.TabControl.SelectedIndex)
            {
                case ((int)MainWindowTabItem.応募履歴):                    
                    this.AppliesBtn.IsEnabled = false;
                    break;
                default:
                    this.Submit.IsEnabled = false;
                    this.AppliesBtn.IsEnabled = (this.StoreEventGrid.Items.Count != 0);
                    break;
            }

        }

        /// <summary>
        /// 郵便番号入力Textのフォーカスが外れたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZipCode_LostFocus(object sender, RoutedEventArgs e)
        {
            string zipcode = this.ZipCode.Text;
            if (!string.IsNullOrWhiteSpace(zipcode))
            {
                string url = ConfigurationManager.AppSettings["ZipcodeApi"] + zipcode;
                WebRequest request = WebRequest.Create(url);
                using (var context = new UnitOfWorks(new CarryMultipleAppliesModel()))
                using (Stream response_stream = request.GetResponse().GetResponseStream())
                {
                    StreamReader reader = new StreamReader(response_stream);
                    var obj_from_json = JObject.Parse(reader.ReadToEnd());
                    if ((string)obj_from_json["code"] == "200")
                    {
                        string prefName = (string)obj_from_json["data"]["pref"];
                        this.PrefectureComboBox.Text = (string)obj_from_json["data"]["pref"];
                        this.City.Text = (string)obj_from_json["data"]["city"];
                        this.StreetBunchName.Text = (string)obj_from_json["data"]["town"];
                    }
                }                
            }



        }

        /// <summary>
        /// 応募ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppliesBtn_Click(object sender, RoutedEventArgs e)
        {
            RequestAppliesModel requestAppliesModel = new RequestAppliesModel();
            requestAppliesModel = this.SetAppliesUserInfo(requestAppliesModel);
            requestAppliesModel.IsConfirmStop = this.IsConfirm.IsChecked.Value;
            requestAppliesModel.AppliesStoreList = this.SetAppliesStoreEventList(requestAppliesModel);


            // 入力不備がある場合、メッセージBoxに表示
            if (requestAppliesModel.Errors.Count > 0)
            {
                string message = "";
                foreach (var tmpMessage in requestAppliesModel.Errors)
                {
                    message += tmpMessage + "\r\n";
                }
                MessageBox.Show(message);
                return;
            }


            Logger.Write((int)LogLevel.Info, Environment.UserName + "が応募を実施");

            // 応募完了しなかったシリアル番号
            List<string> serialNoList = new RequestCarryAppliesService(requestAppliesModel).SendAppliesInfo();
            this.ClearDataGrid(serialNoList);

            // 応募履歴の再取得
            using (var context = new UnitOfWorks(new CarryMultipleAppliesModel()))
            {
                this.SetAppliesHistories(this.GetAppliesHistories(context));
            }
        }

        #endregion

        /// <summary>
        /// 応募履歴の取得
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private List<AppliesHistories> GetAppliesHistories(IUnitOfWorks context)
        {
            var query = context.TApplyHistories.GetAppliesHistoriesByUserName(Environment.UserName);
            return context.TApplyHistories.GetList(query); ;
        }

        /// <summary>
        /// 応募履歴をセット
        /// </summary>
        /// <param name="context"></param>
        private void SetAppliesHistories(List<AppliesHistories> appliesHistoryList)
        {
            this.AppliesHistoryDt.Clear();
            if (appliesHistoryList.Count > 0)
            {
                foreach (var appliesHistory in appliesHistoryList)
                {
                    this.AppliesHistoryDt.Rows.Add(
                        appliesHistory.ApplieDateTime,
                        appliesHistory.StoreEventName,
                        appliesHistory.SerialNo,
                        Enum.GetName(typeof(ApplieStatusType), appliesHistory.ApplieStatus),
                        appliesHistory.ErrorMessage,
                        appliesHistory.FullName,
                        appliesHistory.FullNameHiragana,
                        appliesHistory.Age,
                        appliesHistory.Job,
                        Enum.GetName(typeof(Sex), appliesHistory.Sex),
                        appliesHistory.Address,
                        appliesHistory.PhoneNumber,
                        appliesHistory.MailAddress
                    ); ;
                }
            }

            this.ApplyHisroiesGrid.ItemsSource = this.AppliesHistoryDt.DefaultView;
        }

        /// <summary>
        /// 応募者情報をセット
        /// </summary>
        /// <param name="context"></param>
        private void SetAppliesUserInfo(IUnitOfWorks context)
        {
            var appliesUser = context.TApplyUsers.GetTAppliesUserByUserName(Environment.UserName);
            if (appliesUser != null)
            {
                this.LastName.Text = appliesUser.LastName;
                this.FirstName.Text = appliesUser.FirstName;
                this.LastNameHiragana.Text = appliesUser.LastNameHiragana;
                this.FirstNameHiragana.Text = appliesUser.FirstNameHiragana;
                this.AgeComboBox.SelectedIndex = appliesUser.AgeId - 1;
                this.JobComboBox.SelectedIndex = appliesUser.JobId - 1;
                if (appliesUser.Sex == (int)Sex.男性)
                {
                    this.MaleRadio.IsChecked = true;
                }
                else if (appliesUser.Sex == (int)Sex.女性)
                {
                    this.FemaleRadio.IsChecked = true;
                }
                this.ZipCode.Text = appliesUser.ZipCode;
                this.PrefectureComboBox.SelectedIndex = appliesUser.PrefectureId - 1;
                this.City.Text = appliesUser.City;
                this.StreetBunchName.Text = appliesUser.StreetBunchName;
                this.BuildingName.Text = appliesUser.BuildingName;
                this.PhoneNumber.Text = appliesUser.PhoneNumber;
                this.MailAddress.Text = appliesUser.MailAddress;
            }
        }

        /// <summary>
        /// 応募可否に応じ、ボタンの属性変更
        /// </summary>
        /// <param name="context"></param>
        private void AppliseEventPossible(IUnitOfWorks context)
        {
            int? selectEventId = this.EventComboBox.SelectedValue as int?;
            if (selectEventId.HasValue)
            {
                if (!context.MEvents.IsAppliesEvent(selectEventId.Value))
                {
                    if (this.TabControl.SelectedIndex == (int)MainWindowTabItem.店舗別イベント)
                    {
                        this.StoreEventGrid.IsReadOnly = true;
                        this.Submit.IsEnabled = false;
                        this.AppliesBtn.IsEnabled = false;
                        MessageBox.Show("このイベントは応募できません");
                        return;
                    }
                }

            }

            this.StoreEventGrid.IsReadOnly = false;
            if (this.StoreEventGrid.Items.Count > 0)
            {
                this.AppliesBtn.IsEnabled = true;
            }

        }

        /// <summary>
        /// リクエストデータ作成(応募者情報入力)
        /// </summary>
        /// <param name="requestAppliesModel"></param>
        /// <returns></returns>
        private RequestAppliesModel SetAppliesUserInfo(RequestAppliesModel requestAppliesModel)
        {
            requestAppliesModel.LastName = requestAppliesModel.StringValidate(this.LastName.Tag.ToString(), this.LastName.Text, true);
            requestAppliesModel.FirstName = requestAppliesModel.StringValidate(this.FirstName.Tag.ToString(), this.FirstName.Text, true);
            requestAppliesModel.LastNameHiragana = requestAppliesModel.StringValidate(this.LastNameHiragana.Tag.ToString(), this.LastNameHiragana.Text, true);
            requestAppliesModel.FirstNameHiragana = requestAppliesModel.StringValidate(this.FirstNameHiragana.Tag.ToString(), this.FirstNameHiragana.Text, true);
            requestAppliesModel.AgeId = requestAppliesModel.ComboAndRadioValidate(this.AgeComboBox.Tag.ToString(), Convert.ToInt32(this.AgeComboBox.SelectedValue), true);
            requestAppliesModel.AgeName = this.AgeComboBox.Text;
            requestAppliesModel.JobId = requestAppliesModel.ComboAndRadioValidate(this.JobComboBox.Tag.ToString(), Convert.ToInt32(this.JobComboBox.SelectedValue), true);
            requestAppliesModel.JobName = this.JobComboBox.Text;
            requestAppliesModel.SexId = this.MaleRadio.IsChecked.Value ? (int)Sex.男性 : (int)Sex.女性;
            requestAppliesModel.SexName = this.MaleRadio.IsChecked.Value ? this.MaleRadio.Content.ToString() : this.FemaleRadio.Content.ToString();
            requestAppliesModel.Zipcode = requestAppliesModel.ZipcodeValidate(this.ZipCode.Text);
            requestAppliesModel.PrefectureId = requestAppliesModel.ComboAndRadioValidate(this.PrefectureComboBox.Tag.ToString(), Convert.ToInt32(this.PrefectureComboBox.SelectedValue), true);
            requestAppliesModel.PrefectureName = this.PrefectureComboBox.Text;
            requestAppliesModel.City = requestAppliesModel.StringValidate(this.City.Tag.ToString(), this.City.Text, true);
            requestAppliesModel.StreetBunchName = requestAppliesModel.StringValidate(this.StreetBunchName.Tag.ToString(), this.StreetBunchName.Text, true);
            requestAppliesModel.BuildingName = requestAppliesModel.StringValidate(this.BuildingName.Tag.ToString(), this.BuildingName.Text);
            requestAppliesModel.PhoneNumber = requestAppliesModel.PhoneNumberValidate(this.PhoneNumber.Text);
            requestAppliesModel.MailAddress = requestAppliesModel.MaillAddressValidate(this.MailAddress.Text);

            return requestAppliesModel;
        }

        /// <summary>
        /// DataGridより、応募する店舗イベントのリクエストデータ作成
        /// </summary>
        /// <param name="requestAppliesModel"></param>
        /// <returns></returns>
        private List<RequestAppliesModel.AppliesStore> SetAppliesStoreEventList(RequestAppliesModel requestAppliesModel)
        {
            for (int i = 0; i < this.StoreEventDt.AsEnumerable().Count(); i++)
            {

                int storeEventId = Convert.ToInt32(this.StoreEventDt.Rows[i][0]);
                string serialNo = requestAppliesModel.SerialNoValdate(this.StoreEventDt.Rows[i][1].ToString());

                if (!requestAppliesModel.AppliesStoreList.AsEnumerable().Where(w => w.StoreEventId == storeEventId).Any())
                {
                    using (var context = new UnitOfWorks(new CarryMultipleAppliesModel()))
                    {
                        var storeEvent = context.MStoreEvents.Get(storeEventId);
                        if (storeEvent == null)
                        {
                            // storeEventがnullならデータ不正
                            continue;
                        }

                        requestAppliesModel.AppliesStoreList.Add(new RequestAppliesModel.AppliesStore
                        {
                            StoreEventId = storeEventId,
                            StoreEventName = storeEvent.StoreEventName,
                            AppliesUrl = storeEvent.ApplyUrl,
                            EventDateTime = storeEvent.EventDate,
                        });
                    }

                }

                requestAppliesModel.AppliesStoreList.Find(x => x.StoreEventId == storeEventId).SerialNoList.Add(serialNo);
            }

            return requestAppliesModel.AppliesStoreList;
        }

        /// <summary>
        /// シリアルが通ったDataGridRowをDataGrid上から削除
        /// </summary>
        /// <param name="serialNoList"></param>
        private void ClearDataGrid(List<string> serialNoList)
        {
            for (int i = 0; i < this.StoreEventDt.Rows.Count; i++)
            {
                if (!serialNoList.Contains(this.StoreEventDt.Rows[i]["SerialNo"].ToString()))
                {
                    this.StoreEventDt.Rows.RemoveAt(i);
                }
            }
            this.StoreEventGrid.ItemsSource = this.StoreEventDt.DefaultView;
        }

    }
}
