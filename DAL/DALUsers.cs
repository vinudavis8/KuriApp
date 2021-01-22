using DALHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DALUsers
    {
        AdoHelper _context = new AdoHelper();
        public int SaveAgents(int agentID, int areaID, string agentName,string phone,string address)
        {
            try
            {
                string str = "";

                if (agentID > 0) //update mode
                {
                    str = string.Format("UPDATE [dbo].[agents] SET [name] ='{2}',phone='{3}',address='{4}',area_id={1} WHERE agent_id={0} ", agentID, areaID, agentName, phone, address);
                }
                else
                {
                    str = string.Format("INSERT INTO [dbo].[agents]  (name,phone,address,area_id)  VALUES ('{0}','{1}','{2}',{3}) ", agentName, phone, address, areaID);
                }
                var dt = _context.ExecNonQuery(str);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SaveArea(int areaID,string areaName)
        {
            try
            {
                string str = "";

                if (areaID>0) //update mode
                {
                    str = string.Format("UPDATE [dbo].[area] SET [area_name] ='{1}' WHERE area_id={0} ", areaID, areaName);
                }
                else
                {
                    str = string.Format("INSERT INTO [dbo].[area]  ([area_name])  VALUES ('{0}') ", areaName);
                }
                var dt = _context.ExecNonQuery(str);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SaveDivision(int divisionID, string divisionName,int areaID)
        {
            try
            {
                string str = "";

                if (divisionID > 0) //update mode
                {
                    str = string.Format("UPDATE [dbo].[division] SET [division_name] ='{1}',area_id={2} WHERE division_id={0} ", divisionID, divisionName, areaID);
                }
                else
                {
                    str = string.Format("INSERT INTO [dbo].[division]  ([division_name],area_id)  VALUES ('{0}',{1}) ", divisionName, areaID);
                }
                var dt = _context.ExecNonQuery(str);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAgents()
        {
            try
            {
                string str = "select * from  [dbo].[agents]";

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public DataTable GetAreas()
        {
            try
            {
                string str = "select * from  [dbo].[area]";

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDivisions()
        {
            try
            {
                string str = "select * from  [dbo].[division]";

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public DataTable GetKuriInDivisions(int divisionID)
        {
            try
            {
                string str = "select * from  [dbo].[kuri_master] where division_id=" + divisionID;

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetUsers()
        {
            try
            {
                string str = "select * from  [dbo].[users]";

                var dt = _context.ExecDataSet(str);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveUser(string name, string phone, DateTime dob, string membershipNo, string residentialAddress, string shoAddress, int divisionId, bool status, int userId)
        {
            try
            {
                string str="";

                if (userId>0)//update
                {
                    str = string.Format(" UPDATE [dbo].[users] "+
		                            " SET [name] ='{0}',[phone] = '{1}',[dob] = '{2}',[membership_no] = '{3}',[residential_address] = '{4}' "+
                                   " ,[shop_address] = '{5}',[division_id] = {6},[status] = {7} WHERE user_id={8}", name, phone, DateHelper.convertDateToDBFormat(dob), membershipNo, residentialAddress, shoAddress, divisionId, Convert.ToInt32(status), userId);
                }
                else
                {
                    str = string.Format("INSERT INTO [dbo].[users] ([name] ,[phone],[dob],[membership_no],[residential_address] "+
                                        " ,[shop_address],[division_id],[status]) "+
                                        " VALUES ('{0}','{1}','{2}' ,'{3}','{4}','{5}',{6} ,{7})", name, phone, DateHelper.convertDateToDBFormat(dob), membershipNo, residentialAddress, shoAddress, divisionId, Convert.ToInt32(status));
                }
                var dt = _context.ExecNonQuery(str);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
