namespace CarryMultipleAppliesDataAccess
{
    using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
    using System.Data.Entity;
    using System.Data.SQLite;

    public class CarryMultipleAppliesModel : DbContext
    {
        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'CarryMultipleApplies' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'CarryMultipleAppliesDataAccess.CarryMultipleApplies' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'CarryMultipleApplies' 接続文字列を変更してください。
        public CarryMultipleAppliesModel()
            : base(new SQLiteConnection(@"data source=C:\workspace\CarryMultipleApplies\CarryMultipleAppliesDataAccess\CarryMultipleApplies.db"), false)
        {
        }

        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。


        public virtual DbSet<M_Ages> MAges { get; set; }

        public virtual DbSet<M_ChooseableDomains> MChooseableDomains { get; set; }

        public virtual DbSet<M_Events> MEvents { get; set; }

        public virtual DbSet<M_Jobs> MJobs { get; set; }

        public virtual DbSet<M_Prefectures> MPrefectures { get; set; }

        public virtual DbSet<M_StoreEventDisplays> MStoreEventDisplays { get; set; }

        public virtual DbSet<M_StoreEvents> MStoreEvents { get; set; }

        public virtual DbSet<M_Users> MUsers { get; set; }

        public virtual DbSet<T_ApplyHistories> TApplyHistories { get; set; }

        public virtual DbSet<T_ApplyUsers> TApplyUsers { get; set; }
    }

}