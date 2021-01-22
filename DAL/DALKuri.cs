using DALHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALKuri
    {
        AdoHelper _context = new AdoHelper();
        public int SaveKuriMaster(int divisionID, string kuriName, decimal kuriAmount, int terms, DateTime startDate, int kuriID, decimal termAmount, bool reschedule)
        {
            try
            {
                string str = "";

                if (kuriID > 0) //update mode
                {
                    str = string.Format("UPDATE [dbo].[kuri_master] " +
                      " SET [division_id] = {0},[kuri_name] ='{1}'  ,[kuri_amount] ={2},[terms] ={3}  ,[start_date] ='{4}',term_amount={6}  " +
                      " WHERE kuri_id={5}  select {5} ", divisionID, kuriName, kuriAmount, terms, DateHelper.convertDateToDBFormat(startDate), kuriID, termAmount);
                }
                else
                {
                    str = string.Format(" INSERT INTO [dbo].[kuri_master]([division_id],[kuri_name],[kuri_amount],[terms],[start_date],term_amount) " +
                          " VALUES ({0},'{1}',{2},{3},'{4}',{5} )  SELECT SCOPE_IDENTITY()",
                          divisionID, kuriName, kuriAmount, terms, DateHelper.convertDateToDBFormat(startDate), termAmount);
                }
                var dt = _context.ExecScalar(str);
                kuriID = Convert.ToInt32(dt);
                if (reschedule)
                    SaveKuriSchedule(kuriID);
                return kuriID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SaveKuriAuctionHistory(long auctionID, int kuriID, int userID, decimal auctionAmount, DateTime auctionAmountPaymentDate, decimal newTermPaymentAmount)
        {
            try
            {
                string str = "";

                if (auctionID > 0) //update mode
                {
                    str = string.Format(" UPDATE [dbo].[kuri_auction_history] set [auction_amount_payment_date] ='{1}', " +
                                      " [new_term_amount] = {2} WHERE auction_id={0}  ", auctionID, DateHelper.convertDateToDBFormat(auctionAmountPaymentDate), newTermPaymentAmount);
                }
                else
                {
                    str = string.Format(" INSERT INTO [dbo].[kuri_auction_history] ([kuri_id],[auction_user_id],[auction_amount] " +
                                      ",[auction_date] ,[auction_amount_payment_date] ,[new_term_amount]) " +
                                      " VALUES({0},{1},{2},GETDATE(),'{3}',{4})", kuriID, userID, auctionAmount, DateHelper.convertDateToDBFormat(auctionAmountPaymentDate), newTermPaymentAmount);
                }
                var dt = _context.ExecNonQuery(str);
                //if (auctionID <= 0) //update mode
                //{
                //    SaveKuriSchedule(kuriID);
                //}
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SaveKuripayments(int division_id, int kuri_id, int user_id, int agent_id, decimal received_amount, DateTime received_date, long ID)
        {
            try
            {
                string str = "";

                if (ID > 0) //update mode
                {
                    str = string.Format(" UPDATE [kuri_payments] set [received_amount]={0},[received_date]='{1}' where id={2}", received_amount, DateHelper.convertDateToDBFormat(received_date), ID);
                }
                else
                {
                    str = string.Format("INSERT INTO [dbo].[kuri_payments] ([division_id],[kuri_id],[user_id],[agent_id],[received_amount],[received_date]) " +
                                          " VALUES ({0},{1},{2},{3},{4},'{5}')", division_id, kuri_id, user_id, agent_id, received_amount, DateHelper.convertDateToDBFormat(received_date));
                }
                var dt = _context.ExecNonQuery(str);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SaveKuriSchedule(int kuriID)
        {
            try
            {
                string str = "";


                str = string.Format("DECLARE @startDate datetime " +
                      " DECLARE @kuri_id int ={0}" +
                      " DECLARE @endDate datetime  " +
                      " DECLARE @termAmount decimal(18,0)  " +
                      " DELETE FROM [kuri_payment_schedule] where kuri_id=@kuri_id " +
                      " SELECT @startDate=start_date,@termAmount=term_amount from [dbo].[kuri_master] where kuri_id=@kuri_id " +
                      " SELECT @endDate=DATEADD(day, 9, @startDate)  " +
                      " ;with cte(Date) as  ( " +
                      " select @startDate " +
                      " union all " +
                      " select Date+1 from cte where Date < @endDate ) " +
                      " insert into [kuri_payment_schedule] select @kuri_id, Date,@termAmount from cte option (MAXRECURSION 400) ",
                      kuriID);

                var dt = _context.ExecNonQuery(str);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int AddUsersToKuri(List<int> users, int kuriID)
        {
            try
            {
                string str = "";

                //if (kuriID > 0) //update mode
                //{
                //    str = string.Format("UPDATE [dbo].[kuri_master] " +
                //      " SET [division_id] = {0},[kuri_name] ='{1}'  ,[kuri_amount] ={2},[terms] ={3}  ,[start_date] ='{4}'  " +
                //      " WHERE kuri_id={5} ", divisionID, kuriName, kuriAmount, terms, startDate, kuriID);
                //}
                //else
                //{

                foreach (var item in users)
                {
                    str = " declare @index int=0 " +
                              " declare @kuriname nvarchar(10)='' " +
                              " declare @username nvarchar(20)='' " +
                              " declare @kuriUserName nvarchar(20)='' " +
                            "  set  @index =(select count(*)+1 from [dbo].[kuri_users] where kuri_id=" + kuriID + ") " +
                              " set @kuriname= (select kuri_name from [dbo].[kuri_master] where kuri_id=" + kuriID + ")  " +
                                  " set @username=(select name from [dbo].[users] where user_id=" + item + ") " +
                                  " set @kuriUserName=@kuriname+'.'+cast(@index as nvarchar(6))+'.'+@username " +
                                  " INSERT INTO [dbo].[kuri_users]([kuri_id],[user_id],[kuri_user_name]) " +
                                  " VALUES (" + kuriID + "," + item + ",@kuriUserName)";
                    var dt = _context.ExecNonQuery(str);
                }
                // }

                return Convert.ToInt32(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetKuriList()
        {
            try
            {
                string str = "select * from  [dbo].[kuri_master]";

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetKuriData(int kuriID)
        {
            try
            {
                string str = "select * from  [dbo].[kuri_master] where kuri_id=" + kuriID;

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetUsertsInDivision(int kuriID)
        {
            try
            {
                string str = " select  user_id,name  from [dbo].[users] where division_id= " +
                    "(select division_id from [kuri_master] where kuri_id=" + kuriID + ")";

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetKuriUsers(int kuriID)
        {
            try
            {
                string str = "select ku.user_id, u.name,ku.kuri_user_name from  [dbo].[kuri_users] ku join users u on u.user_id=ku.user_id  where kuri_id=" + kuriID + "";


                var dt = _context.ExecDataSet(str);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetKuriAuctionHistory(int kuriID)
        {
            try
            {
                string str = "select  u.name,kh.* from  [kuri_auction_history] kh join users u on kh.auction_user_id=u.user_id where kh.kuri_id=" + kuriID + "";
                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetKuriPaymentsByUser(int userID, int kuriID)
        {
            try
            {
                string str = "SELECT [id] ,[division_id] ,[kuri_id],[user_id],[agent_id],[received_amount] ,CAST([received_date] AS date) FROM [dbo].[kuri_payments]  where user_id=" + userID + " and kuri_id=" + kuriID;

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetKuriUserName(int userID, int kuriID)
        {
            try
            {
                string str = string.Format("select top 1  u.name from  [dbo].[kuri_users] ku join users u on u.user_id=ku.user_id where  ku.user_id={0}  and  ku.kuri_id={1}", userID, kuriID);

                var dt = _context.ExecScalar(str);
                return dt.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataTable GetKuriDueuesByUser(int userID,int kuriID)
        //{
        //    try
        //    {
        //        string str = string.Format(" SELECT sh.kuri_id, sh.payment_due_date, py.received_date, sh.amount_tobe_paid,sum( py.received_amount)received_amount " +
        //                  " FROM   dbo.kuri_payment_schedule AS sh LEFT OUTER JOIN  " +
        //                  " dbo.kuri_payments AS py ON sh.kuri_id = py.kuri_id AND sh.payment_due_date = CAST(py.received_date AS date)  " +
        //                  " and py.user_id={0}  and sh.payment_due_date<=CAST(GETDATE() AS date)  where sh.kuri_id={1} group by  CAST(py.received_date AS date),sh.kuri_id, sh.payment_due_date, py.received_date, sh.amount_tobe_paid  " +
        //                  " order by sh.payment_due_date desc ", userID, kuriID);

        //        var dt = _context.ExecDataSet(str);
        //        return dt.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet GetKuriUserSummary(int kuriID, int userID)
        {
            try
            {
                string str = string.Format(
                                          " DECLARE @amount decimal(18,0) " +
                                          " set @amount=(select top 1 new_term_amount from [dbo].[kuri_auction_history] where kuri_id={0} order by auction_id desc) " +
                                          " if(@amount is null) " +
                                          " select  @amount=term_amount from  [dbo].[kuri_master] where kuri_id={0} " +
                                          " select @amount " +
              " select sum(received_amount) from [dbo].[kuri_payments] where kuri_id={0} and user_id={1} " +

                "SELECT sh.kuri_id, sh.payment_due_date, py.received_date, sh.amount_tobe_paid,sum( isnull(py.received_amount,0))received_amount " +
                          " FROM   dbo.kuri_payment_schedule AS sh LEFT OUTER JOIN  " +
                          " dbo.kuri_payments AS py ON sh.kuri_id = py.kuri_id AND sh.payment_due_date = CAST(py.received_date AS date)  " +
                          " and py.user_id={1}  and sh.payment_due_date<=CAST(GETDATE() AS date)  where sh.kuri_id={0} group by  CAST(py.received_date AS date),sh.kuri_id, sh.payment_due_date, py.received_date, sh.amount_tobe_paid  " +
                          " order by sh.payment_due_date desc ", kuriID, userID);

                var dt = _context.ExecDataSet(str);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// report data
        /// 

        public DataTable GetRptUserData(int userID, int kuriID)
        {
            try
            {
                string str = string.Format("  select v.*,v.Expr1 As received_date from [dbo].[View_Kuri_division_user] v where user_id={0} and kuri_id={1}", userID, kuriID);

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetRptAuctionData(int kuriID)
        {
            try
            {
                string str = string.Format("  select v.*,v.Expr1 As auction_date,v.Expr2 as auction_amount_payment_date from [dbo].[View_aution_history] v where kuri_id={0} ", kuriID);

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
