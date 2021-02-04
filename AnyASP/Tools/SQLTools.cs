	namespace AnyASP.Models
{
    using System;
	using Microsoft.EntityFrameworkCore;
	using AnyASP.Models;

	  public interface ISQLToolsRepository
    {
         int NextGenID( string genName, int defvalue = 0);

        /// <summary>
        /// Получение int значения SQL запроса
        /// <param name="dbContext"></param>
        /// <param name="SQLQuery   select   t.xx as intres from table t ....."></param>
        /// <param name="SQLQuery"></param>
        /// <returns>Получение int значения SQL запроса  select   t.xx as intres from table t .....</returns>
          int GetInt( string SQLQuery, int defresult = 0);
        /// <summary>
        /// Получение decimal значения SQL запроса
        /// <param name="dbContext"></param>
        /// <param name="SQLQuery   select   t.xx as decres from table t ....."></param>
        /// <param name="SQLQuery"></param>
        /// <returns>Получение decimal значения SQL запроса SQLQuery   select   t.xx as decres from table t ..... </returns>
          decimal GetDecimal(string SQLQuery,decimal defresult=0);
        /// <summary>
        /// Получение string значения SQL запроса
        /// <param name="dbContext"></param>
        /// <param name="SQLQuery   select   t.xx as strres from table t ....."></param>
        /// <param name="SQLQuery"></param>
        /// <returns>Получение string значения SQL запроса SQLQuery   select   t.xx as strres from table t ..... </returns>
          string GetString(string SQLQuery,string defresult="");

        /// <summary>
        /// Получение DateTime значения SQL запроса
        /// <param name="dbContext"></param>
        /// <param name="SQLQuery   select   t.xx as dtres from table t ....."></param>
        /// <param name="SQLQuery"></param>
        /// <returns>Получение DateTime значения SQL запроса SQLQuery   select   t.xx as dtres from table t ..... </returns>
          DateTime GetDateTime( string SQLQuery);

        /// <summary>

        /// <returns>Выплняет запрос изменяюший данные в БД - insert,update, delete , execute procedure </returns>
          void Execute(string SQLQuery);
        /// <summary>
        /// Возвращает текст сообщение об ошибке по переданному id инициированное в БД.
        /// </summary>
        /// <param name="id"> код ошибки переданный БД. Код должен быть в диапазоно от 1 до 10000</param>
        /// <param name="defmes">меторд Возвращает defmes в том случе если по указанному коду не найдено сообщение обошибке </param>
        /// <returns>Возвращает текст сообщение об ошибке по переданному id инициированное в БД</returns>
        string GetDBErrMesByCode(int id, string defmes);
        /// <summary>
        /// Возвращает текущую дату время из БД сервера
        /// </summary>
        /// <returns></returns>
        DateTime GetCurrentTimeStamp();
    }

	
	public class EFSQLToolsRepository : ISQLToolsRepository
    {
		private Model1 context;
		public EFSQLToolsRepository(Model1 _context)
		{
			context = _context;
		}
		public int NextGenID(string genName,int defvalue=0)
        {
			string sqlquery = String.Format("select gen_id({0},1) as intresult from rdb$database",genName);
			return GetInt(sqlquery, defvalue);
        }

        /// <summary>
        /// Получение int значения SQL запроса
        /// <param name="dbContext"></param>
        /// <param name="SQLQuery   select   t.xx as intres from table t ....."></param>
        /// <param name="SQLQuery"></param>
        /// <returns>Получение int значения SQL запроса  select   t.xx as intres from table t .....</returns>
        public int GetInt(string SQLQuery,int defresult=0)
        {
			using (var command = context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = SQLQuery;
				context.Database.OpenConnection();
				using (var result = command.ExecuteReader())
				{
					int intresult;
                    try
                    {
                        result.Read();
                        if (result.IsDBNull(0))
                        {
                            intresult = defresult;
                        }
                        else
                        {
                            intresult = result.GetInt32(0);
                        }
					}
					catch
					{
						intresult = defresult;
					}
					result.Close();
					command.ExecuteReader().Close();
					return intresult;
				}									
			}
			
        }
		/// <summary>
		/// Получение decimal значения SQL запроса
		/// <param name="dbContext"></param>
		/// <param name="SQLQuery   select   t.xx as decres from table t ....."></param>
		/// <param name="SQLQuery"></param>
		/// <returns>Получение decimal значения SQL запроса SQLQuery   select   t.xx as decres from table t ..... </returns>
		public decimal GetDecimal(string SQLQuery, decimal defresult = 0)
		{
			using (var command = context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = SQLQuery;
				context.Database.OpenConnection();
				using (var result = command.ExecuteReader())
				{
					decimal decresult;
					try
                    { 
                        result.Read();
                        if (result.IsDBNull(0))
                        {
                            decresult = defresult;
                        }
                        else
                        {
                            decresult = result.GetDecimal(0);
                        }
					}
					catch
					{
						decresult = defresult;
					}
					result.Close();
					command.ExecuteReader().Close();
					return decresult;
				}
			}
		}
        /// <summary>
        /// Получение string значения SQL запроса
        /// <param name="dbContext"></param>
        /// <param name="SQLQuery   select   t.xx as strres from table t ....."></param>
        /// <param name="SQLQuery"></param>
        /// <returns>Получение string значения SQL запроса SQLQuery   select   t.xx as strres from table t ..... </returns>
        public string GetString(string SQLQuery, string defresult = "")
        {
			using (var command = context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = SQLQuery;
				context.Database.OpenConnection();
				using (var result = command.ExecuteReader())
				{
					string strresult;
					try
                    { 
                        result.Read();
                        if (result.IsDBNull(0))
                        {
                            strresult = defresult;
                        }
                        else
                        {
                            strresult = result.GetString(0);
                        }
                        
					}
					catch
					{
						strresult = defresult;
					}
					result.Close();
					command.ExecuteReader().Close();
					return strresult;
				}
			}

		}

        /// <summary>
        /// Получение DateTime значения SQL запроса
        /// <param name="dbContext"></param>
        /// <param name="SQLQuery   select   t.xx as dtres from table t ....."></param>
        /// <param name="SQLQuery"></param>
        /// <returns>Получение DateTime значения SQL запроса SQLQuery   select   t.xx as dtres from table t ..... </returns>
        public DateTime GetDateTime(string SQLQuery)
        {
			using (var command = context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = SQLQuery;
				context.Database.OpenConnection();
                DateTime NullDateTime = new DateTime();

                using (var result = command.ExecuteReader())
				{
					DateTime dtresult;
                    if (result.HasRows)
                    {
                        result.Read();
                        if (result.IsDBNull(0))
                        {
                            dtresult = NullDateTime;
                        }
                        else
                        {
                            dtresult = result.GetDateTime(0);
                        }
                    }
                    else
                    {
                        dtresult = NullDateTime;
                    }
					result.Close();
					command.ExecuteReader().Close();
					return dtresult;
				}
			}
		}

        /// <summary>

        /// <returns>Выплняет запрос изменяюший данные в БД - insert,update, delete , execute procedure </returns>
        public void Execute(string SQLQuery)
        {
			context.Database.ExecuteSqlCommand(SQLQuery);
		}

        public string GetDBErrMesByCode(int id,string defmes="")
        {
            try
            {
                if (id > 0 && id < 1000)
                {
                    return GetString(string.Format("select e.ex_mes from  EXCEPTIONMES  e where  e.ex_id={0}", id), defmes);
                }
                else
                {
                    return defmes;
                }
            }
            catch
            {
                return Constants.ERRDBOperExecute + "GetDBErrMesByCode";
            }

        }

        public DateTime GetCurrentTimeStamp()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select current_timestamp from rdb$database";
                context.Database.OpenConnection();
                DateTime NullDateTime = new DateTime();

                using (var result = command.ExecuteReader())
                {
                    DateTime dtresult;
                    if (result.HasRows)
                    {
                        result.Read();
                        if (result.IsDBNull(0))
                        {
                            dtresult = NullDateTime;
                        }
                        else
                        {
                            dtresult = result.GetDateTime(0);
                        }
                    }
                    else
                    {
                        dtresult = NullDateTime;
                    }
                    result.Close();
                    command.ExecuteReader().Close();
                    return dtresult;
                }
            }
        }



    }

	
}