using CarryMultipleAppliesDataAccess;
using CarryMultipleAppliesDataAccess.DataTier.Core;
using CarryMultipleAppliesDataAccess.DataTier.Persistance;
using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CarryMultipleAppliesCommon.Log;

namespace CarryMultipleAppliesService.Services
{
    public class InitialData
    {
        private DateTime now = DateTime.Now;
        private string inseertUser = "system";

        /// <summary>
        /// マスタデータ初期化
        /// </summary>
        public void InitData()
        {
            using (var context = new UnitOfWorks(new CarryMultipleAppliesModel()))
            {
                try
                {
                    this.MEventsData(context);
                    this.MStoreEventsData(context);
                    this.MAgesData(context);
                    this.MJobssData(context);
                    this.MPrefecturesData(context);
                    this.MDomainsData(context);
                }
                catch (Exception ex)
                {
                    Logger.Write((int)LogLevel.Error, "マスタデータ登録失敗" + ex.Message);
                }

            }
        }

        /// <summary>
        /// イベントマスタ初期化
        /// </summary>
        /// <param name="context"></param>
        private void MEventsData(IUnitOfWorks context)
        {
            var mEvent = context.MEvents.GetAll();
            if (mEvent.Count() == Convert.ToInt32(ConfigurationManager.AppSettings["MEventsData"]))
            {
                Logger.Write((int)LogLevel.Info, "イベントの更新はありません");
                return;
            }
            context.MEvents.DeleteAll(mEvent);
            var data = new List<M_Events>();
            data.Add(new M_Events { EventId = 1, EventName = "石原夏織 1st LIVE TOUR Face To FACE Bli-ray&DVD発売記念イベント", ApplyFrom = "2020/06/01 00:00:00", ApplyTo = "2020/06/29 00:00:00", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            context.MEvents.AddRange(data);
            context.Complete();
            Logger.Write((int)LogLevel.Info, "イベントのレコードを刷新しました");
        }

        /// <summary>
        /// 店舗別イベント初期化
        /// </summary>
        /// <param name="context"></param>
        private void MStoreEventsData(IUnitOfWorks context)
        {
            var mStoreEvent = context.MStoreEvents.GetAll();
            if (mStoreEvent.Count() == Convert.ToInt32(ConfigurationManager.AppSettings["MStoreEventsData"]))
            {
                Logger.Write((int)LogLevel.Info, "店舗別イベントの更新はありません");
                return;
            }
            context.MStoreEvents.DeleteAll(mStoreEvent);
            var data = new List<M_StoreEvents>();
            data.Add(new M_StoreEvents { StoreEventId = 1, EventId = 1, StoreEventName = "8月1日(土) 15時 アニメイト", ApplyUrl = "http://pc-ent.jp/entry/tj67eww5g/", EventDate = null, InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_StoreEvents { StoreEventId = 2, EventId = 1, StoreEventName = "8月1日(土) 18時 ゲーマーズ", ApplyUrl = "http://pc-ent.jp/entry/tj67eww50/", EventDate = null, InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_StoreEvents { StoreEventId = 3, EventId = 1, StoreEventName = "8月1日(土) 18時 とらのあな", ApplyUrl = "http://pc-ent.jp/entry/tj67eww50/", EventDate = null, InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            context.MStoreEvents.AddRange(data);
            context.Complete();
            Logger.Write((int)LogLevel.Info, "店舗別イベントのレコードを刷新しました");
        }

        /// <summary>
        /// 年代マスタ初期化
        /// </summary>
        /// <param name="context"></param>
        private void MAgesData(IUnitOfWorks context)
        {
            var mAges = context.MAges.GetAll();
            if (mAges.Count() == Convert.ToInt32(ConfigurationManager.AppSettings["MAgesData"]))
            {
                Logger.Write((int)LogLevel.Info, "年代の更新はありません");
                return;
            }
            context.MAges.DeleteAll(mAges);
            var data = new List<M_Ages>();
            data.Add(new M_Ages { AgeId = 1, AgeName = "0～6", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 2, AgeName = "7～8", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 3, AgeName = "9～10", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 4, AgeName = "11～12", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 5, AgeName = "13～15", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 6, AgeName = "16～18", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 7, AgeName = "19～20", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 8, AgeName = "21～24", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 9, AgeName = "25～29", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 10, AgeName = "30～34", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 11, AgeName = "35～39", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 12, AgeName = "40～44", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 13, AgeName = "45～49", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 14, AgeName = "50～54", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 15, AgeName = "55～59", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 16, AgeName = "60～64", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 17, AgeName = "65～69", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Ages { AgeId = 18, AgeName = "70以上", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            context.MAges.AddRange(data);
            context.Complete();
            Logger.Write((int)LogLevel.Info, "年代のレコードを刷新しました");
        }

        /// <summary>
        /// 職業マスタ初期化
        /// </summary>
        /// <param name="context"></param>
        private void MJobssData(IUnitOfWorks context)
        {
            var mJobs = context.MJobs.GetAll();
            if (mJobs.Count() == Convert.ToInt32(ConfigurationManager.AppSettings["MJobsData"]))
            {
                Logger.Write((int)LogLevel.Info, "職業の更新はありません");
                return;
            }
            context.MJobs.DeleteAll(mJobs);
            var data = new List<M_Jobs>();
            data.Add(new M_Jobs { JobId = 1, JobName = "学生", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Jobs { JobId = 2, JobName = "経営者・役員", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Jobs { JobId = 3, JobName = "会社員", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Jobs { JobId = 4, JobName = "自営業", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Jobs { JobId = 5, JobName = "専門・自由業(医師、弁護士等)", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Jobs { JobId = 6, JobName = "主婦専業", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Jobs { JobId = 7, JobName = "アルバイト・フリーター", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Jobs { JobId = 8, JobName = "その他", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            context.MJobs.AddRange(data);
            context.Complete();
            Logger.Write((int)LogLevel.Info, "職業のレコードを刷新しました");

        }

        /// <summary>
        /// 都道府県マスタ初期化
        /// </summary>
        /// <param name="context"></param>
        private void MPrefecturesData(IUnitOfWorks context)
        {
            var mPrefecturess = context.MPrefectures.GetAll();
            if (mPrefecturess.Count() == Convert.ToInt32(ConfigurationManager.AppSettings["MPrefectureData"]))
            {
                Logger.Write((int)LogLevel.Info, "都道府県の更新はありません");
                return;
            }
            context.MPrefectures.DeleteAll(mPrefecturess);
            var data = new List<M_Prefectures>();
            data.Add(new M_Prefectures { PrefectureId = 1, PrefectureName = "北海道", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 2, PrefectureName = "青森県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 3, PrefectureName = "岩手県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 4, PrefectureName = "宮城県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 5, PrefectureName = "秋田県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 6, PrefectureName = "山形県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 7, PrefectureName = "福島県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 8, PrefectureName = "茨城県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 9, PrefectureName = "栃木県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 10, PrefectureName = "群馬県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 11, PrefectureName = "埼玉県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 12, PrefectureName = "千葉県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 13, PrefectureName = "東京都", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 14, PrefectureName = "神奈川県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 15, PrefectureName = "新潟県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 16, PrefectureName = "富山県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 17, PrefectureName = "石川県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 18, PrefectureName = "福井県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 19, PrefectureName = "山梨県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 20, PrefectureName = "長野県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 21, PrefectureName = "岐阜県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 22, PrefectureName = "静岡県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 23, PrefectureName = "愛知県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 24, PrefectureName = "三重県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 25, PrefectureName = "滋賀県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 26, PrefectureName = "京都府", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 27, PrefectureName = "大阪府", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 28, PrefectureName = "兵庫県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 29, PrefectureName = "奈良県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 30, PrefectureName = "和歌山県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 31, PrefectureName = "鳥取県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 32, PrefectureName = "島根県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 33, PrefectureName = "岡山県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 34, PrefectureName = "広島県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 35, PrefectureName = "山口県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 36, PrefectureName = "徳島県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 37, PrefectureName = "香川県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 38, PrefectureName = "愛媛県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 39, PrefectureName = "高知県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 40, PrefectureName = "福岡県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 41, PrefectureName = "佐賀県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 42, PrefectureName = "長崎県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 43, PrefectureName = "熊本県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 44, PrefectureName = "大分県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 45, PrefectureName = "宮崎県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 46, PrefectureName = "鹿児島県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_Prefectures { PrefectureId = 47, PrefectureName = "沖縄県", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            context.MPrefectures.AddRange(data);
            context.Complete();
            Logger.Write((int)LogLevel.Info, "都道府県のレコードを刷新しました");
        }

        /// <summary>
        /// ドメイン初期化
        /// </summary>
        /// <param name="context"></param>
        private void MDomainsData(IUnitOfWorks context)
        {
            var mDomains = context.MChooseableDomains.GetAll();
            if (mDomains.Count() == Convert.ToInt32(ConfigurationManager.AppSettings["MDomainsData"]))
            {
                Logger.Write((int)LogLevel.Info, "選択するドメインの更新はありません");
                return;
            }
            context.MChooseableDomains.DeleteAll(mDomains);
            var data = new List<M_ChooseableDomains>();
            data.Add(new M_ChooseableDomains { DomainId = 1, DomainName = "docomo.ne.jp", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 2, DomainName = "ezweb.ne.jp", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 3, DomainName = "i.softbank.jp", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 4, DomainName = "softbank.ne.jp", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 5, DomainName = "gmail.com", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 6, DomainName = "yahoo.co.jp", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 7, DomainName = "hotmail.co.jp", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 8, DomainName = "hotmail.com", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            data.Add(new M_ChooseableDomains { DomainId = 9, DomainName = "icloud.com", InsertDate = this.now.ToString(), InsertUser = this.inseertUser, UpdateDate = this.now.ToString(), UpdateUser = this.inseertUser, });
            context.MChooseableDomains.AddRange(data);
            context.Complete();
            Logger.Write((int)LogLevel.Info, "選択するドメインのレコードを刷新しました");
        }
    }
}
