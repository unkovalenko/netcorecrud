using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyASP.Models
{
    enum PlanDestination
    {
        PlanResource = 1,
        PlanPart = 2,
        PlanMultiUserHandMade = 3,
        PlanDesignRepro = 4,
        PlanMultiUserRC = 5
    }

    public static class DateTimeManipulator
    {
        public static string GetHourStrByMinute(int aminute)
        {
            if (aminute < 1)
            {
                return "0хв";
            }
            int ahour = Convert.ToInt32( Math.Floor(aminute / 60.0));
            int amin = aminute - ahour * 60;
            if (ahour > 0)
            {
                return String.Format("{0}г {1}хв", ahour, amin);
            }
            return String.Format("{0}хв",  amin);
        }
        public const string tmformat = "HH:mm";
        public const string dttmformat = "dd.MM.yyyy HH:mm";
        public const string dttmformatshort = "dd.MM HH:mm";
        public const string dtformat = "dd.MM.yyyy";
        public const string dttmformatfb = "MM\\/dd\\/yyyy HH:mm";//DateTime.Now.ToString(DateTimeManipulator.dttmformatfb));
        public const string dtformatfb = "MM\\/dd\\/yyyy";
        public const decimal onehour = 1 / 24;
        public const decimal onemin = 1/24/60;
        public const decimal onesec = 1 / 24 / 60/60;
    }

    public static class Constants
    {
        public const int IDUndefined = 0;
        public const int IDNotExists = -1;
        public const int ZERO = 0;
        public const int FACESIDE = 1;
        public const int BACKSIDE = 2;
        /*public const int PRINTTECHOPERGROUP = 4833;
        public const int POSTPRINTTECHOPERGROUP = 4817;
        public const int ENABLEDWORKEROPERTYPEID = 16777162;
        public const int HANDEMADEMACHINID = 5063;
        public const int RCDCMACHINID = 5211;
        public const int WSDayBefore = 1;
        public const int PREPRESSGROUPERID = 2;
        public const int DCGROUPOPERID = 3;
        public const int DESIGNPARTID = 4836;
        public const int REPROCENTRPARTID = 4837;
        public const int IDCuttingDepartment = 99203;
        public const int MINEXECWORKDURATION = 1;
        public const int CheckOrderForDCRCCount = 120;
        public const int ExecWorkHourBefore = 12;
        public const int ExecWorkHourAfter = 1;
        */
        public const int CookiesExpiresDay = 10;
        public const string MONITOR10 = "1";
        public const string MONITOR21 = "2";
        public const string MONITOR21TS = "3";

        public const int CHECKEDRESOURCE = 0;
        public const int CHECKEDPART = 1;
        public const int CHECKEDRESOURCEPERSONAL = 2;

        public const int PRINTTABLECOLUMNSET = 1;
        public const int RCDCCOLUMNSET = 3;
        public const int ANYTABLECOLUMNSET = 2;

        public const int ORDERINPLAN = -1;
        // state order TSTATEORDER
        public const int TSREDY = 255;//	Готов Готов		1	0		154	255	0	
        public const int TSPARTSTOREHOUSE = 260;//	Принят на склад частично			0	0		731	260	0	
        public const int TSSTOREHOUSE = 270;//	Принят на склад полностью			0	0		731	270	0	96113248
        public const int TSISOUTPART = 280;//	Выдан частично			0	0		731	280	0	
        public const int TSISOUT = 290;//	Выдан полностью			0	0		731	290	0	
        public const int TSBREAK = 300;//	Отказ / Снят
        public const int AUTOREFRPERIODDEFAULT = 300000; // 5 minut

        public const int WORKPERIODLASTYEAR = 2;
        public const int deflengthshift = 540;
        public const int maxlengthshift = 900;
        public const int startfirstshiftclock = 8;
        public const int startfirstshiftminutes = 0;




        //  SO StatesOpers
        public const int SORezerv = 125;//Резервировано время
        public const int SOInPlan = 130;//В Плане - запланирован
        public const int SOPartRedy = 135;//Частично готова. Операция планируется. В технологической цепочке рассматривается как готовая - не учитывается
        public const int SOInWork = 140;//В работе
        public const int SORedy = 150;//Готово
        public const int SORedyEdit = 155;//Готово - редактируется
        public const int SOStop = 160;//Приостановлен
        public const int SODel = 165;//Удален
        public const int SOBreak = 170;//Отказ*/

        // parts ArtPress
        public const int PaPrintId = 600;
        public const int PaPostPrintId = 601;

        // ScanCodeActions
        public const char scaSTARTWORK = '1';
        public const char scaFINWORK = '2';
        public const char scaFINOPER = '3';
        public const char scaSEARCHOPER = '4';
        public const char scaSEARCHORDER = '5';
        public const char scaFINPREPRESS = '6';

        // ScanCodeActionsName
        public const string scanSTARTWORK = "startwork";
        public const string scanFINWORK = "finwork";
        public const string scanFINOPER = "finoper";
        public const string scanSEARCHOPER = "searchoper";
        public const string scanSEARCHORDER = "searchorder";
        public const string scanFINPREPRESS = "finprepress";


        public const string MESTECHORDER = "Технологический заказ";
        public const string PERSONALSETTOBRIGADE = "Спiвпрацiвник увiйшов до бригади";
        public const string PAGEHEADERQUEUERC = "Черга до ресурсу";
        public const string PAGEHEADEREXECWEORK = "Зроблено";
        public const string PAGEHEADERQUEUEPART = "Черга по пiдроздiлу";
        public const string HANDMADEOPER = "Ручнi операцii";
        public const string EXECOPERCAPTION = "ПIДРОЗДIЛ:{0};    ВИКОНАВЕЦЬ:{1};";
        // Error message
        public const string ERRShift = "Помилка у змiнi";
        public const string ERRPartNotDefine = "Помилка. Пiдроздiл не обрано";
        public const string ERRResorceNotDefine = "Помилка. Ресурс не обрано";
        public const string ERRRExecutorNotDefine = "Помилка. Виконавця не обрано";
        public const string ERRBrigadeNotDefine = "Помилка. Бригаду  не створено";
        public const string ERRNOTWORKANMACHINE = "Це не ваш ресурс";
        public const string NONEDATE = " Не вказано";
        public const string RESOURCENOTSELECTED = "--Ресурс не обрано--";
        public const string OPERNOTSELECTED = "--Операцiю не обрано--";
        public const string RESOURCENOTDEFINE = "Ресурс не обрано";
        public const string ERROperNotFound = "Операцiю не знайдено";
        public const string ERROrderNotFound = "Замовлення не знайдено";
        public const string ERRTehnOperInsert = "Помилка при доданнi операцii";
        public const string ERRDelOperDisable = "Заборонено вилучать виробничи опер.";
        public const string ERRDelOper = "Помилка вилучення опер.";
        public const string ERROperbyExecutors = "Помилка встановлення часу опер. по факту";
        public const string ERRExecutorExist = "Иполнитель работ операции уже введеен";
        public const string ERRFinOperExec = "Помилка встановлення закiнчення операцii ";
        public const string ERRStartOperExec = "Помилка встановлення початку операцii ";
        public const string ERRFinWorkExec = "Помилка встановлення закiнчення роботи ";
        public const string ERRFinWorkExecIsRedy = "Помилка встановлення закiнчення роботи. Робота вже закінчена. ";
        public const string ERRStartWorkExec = "Помилка встановлення початку роботи ";
        public const string ERRDelWorkExec = "Помилка вилучення  роботи ";
        public const string ERRDelRecord = "Помилка вилучення  запису";
        public const string ERRDBOperExecute = "Помилка в роботi з БД";
        public const string ERRScanner = "Помилка в роботi зi сканером";
        public const string ERRScannerstring = "Помилка в роботi зi сканером.Невiдома команда.";

        public const string ERRDateStartOper =  "Неправильно введена дата початку";
        public const string ERRDateFinOper = "Неправильно введена дата закінчення";
        public const string ERRDateStartFinOper = "Неправильно введена дата. Закінчення повинно буте бiльше початку";
        public const string ERRPartRedyState = "Помилка встановлення операцii частково готово ";
        public const string ERRRedyState = "Помилка встановлення операцii готово. Помилка встановлення результату по роботам. Неправильно вказано кількість виконано або тривалість  ";
        public const string ERRMoveOper = "Помилка встановлення черги операц ";
        public const string ERRTOBRIGADE = "Помилка встановлення бригади ";
        public const string ERRSETSTATE = "Помилка встановлення статусу операцii ";
        public const string ERRBACKTOPLAN = "Помилка повернення опер до плану для редагування ";
        public const string ERRDISABLEEDITOPER = "Заборонено редагування виконаних операцiй. ";
        public const string ERRRECORDNOTSELECTED = "Не обран запис. Оберiть запис.";
        public const string ERREXISTSOPERINWORK = "Нельзя взять операцию в работу потому что уже есть операция в работе. ";
        public const string ERREXISTSOPERINWORKINSHIFT = "Закрити змiну неможливо тому що, не зупинена работа . Зупинiть роботу i зможете закрити змiну. Скористайтися фiльтром ПОТОЧНА ";
        public const string ERRRETURNTOPLANEXECUTOREXISTS = "Нельзя  вернуть операцию в план потому, что часть работ уже выполнена - введен факт по работам. ";
        public const string ERRAccessDenied = "Доступ заборонено.";
        public const string ERRUserNamePassword = "Помилка i`мя або пароль";
        public const string ERRRemNotUpdate = "Не вдалося змимнити коментар";
        public const string ERRThisOperHavenStartedWork = "У цій операції вже є розпочата вами робота. Завершіть цю роботу перш ніж почати нову.";
        public const string ERRONLYUANWORKTYPE = "Не допускається суміщення роботи типу 'Вся операція' з іншими типами робіт";
        public const string ERRThisResourceHavenStartedWork = "На цьому ресурсі є розпочата вами робота. Завершіть цю роботу перш ніж почати нову.";
        public const string ERRHavenStartedWork = "є розпочата вами робота. Завершіть цю роботу перш ніж почати нову.";
        public const string MSGForFindStartedOper = "Для пошуку розпочатой Вами роботи скористайтися кнопокой 'Поточна'  ";
        public const string ERRChenchResource = "Не вдалося змминити ресурс";
        public const string ERRNPPWORKZERONOTDEFINE = "Не вказана стартова №пп=0 операцiя в словнику типов операцiй";
        public const string ERRTABNUMNOTINPUT = "Не вказан табельний №";
        public const string ERRNOTFINDPERSONAL = "Персона не знайдена";
        public const string ERRNOTFINDPERSONAWORKL = "Роботи персони не знайдена";
        public const string WARNOUTFROMBRIGADE = "Ви пішли з бригади на ";
        public const string ERRLATESHIFT = "Запiздно для початку змiни";
        public const string ERRSHIFTISOPEN = "Смена уже открыта -начало смены введено";
        public const string ERRSHIFTISNOTOPEN = "Нельзя закончить смену. Не введено начало смены. ";
        public const string ERRSHIFTNOTDATE = "Не введено початок або закiнчення змiни. ";
        public const string ERRSHIFTPROBLEM = "Знайдени помилки зi змiною. ";
        public const string ERRFILTERAPP = "Не вдалося побудувати фiльтр";
        public const string ERRCLOSEWORKAUTO = "Не вдалося завершити работи автоматично";
        public const string ERRPREPRESSOPERFINISHED = "Не вдалося завершити препресс операцii";

        public const string WRTIMESHEETNEED = "Шановний {0}, Вам потрiбно зробити  позначку початку змiни у Табелi ";
        public const string WRMESINTIMESHEETENTRY = "{0} розпочав роботу у {1} змiну в {2}. Не забудьте відзначиться в табелі після закінчення зміни. ";

        public const string QUESTOUTFROMBRIGADE = "{0} ви уходите з бригади {1}?";
        public const string MSGOPERSTARTING = "Розпочатo операцiю ID=";
        public const string MSGOWORKSTARTING = "Розпочатo роботу";
        public const string MSGOPERSTOPED = "Зупинено операцiю ID=";
        public const string MSGOPERREDY = "Завершено операцiю ID=";
        public const string MSGOPERFINISHED = "Завершено операцiю ID=";
        public const string MSGOPERSEARCH = "Знайдено операцiю ID=";
        public const string MSGORDERSEARCH = "Знайдено заказ ID=";
        public const string MSGPREPRESSOPERFINISHED = "Завершенi препресс операцii";
        public const string MSGSHIFTCLOSED = "Змiну завершено";

        //Остановить работы пользователя pe_id. 
        public const string SQLSTOPWORKUSER = @"execute block as
declare variable eo_id integer ;
begin
   for select  e.eo_id from  executorsopr e
      left join factoperations f on f.fo_id=e.fo_id
      left join operations o on f.op_id = o.op_id
      left join typeoper t on o.ty_id = t.ty_id
      where e.pe_id ={0}  and  e.eo_dtstart > (current_date - {1})  and coalesce(e.eo_durationwithpause,0) < 0.9  --********  for all type oper abd state and  t.gr_id in ({2},{3}) and o.op_state={4}
      into :eo_id do
        update executorsopr   set  eo_durationwithpause  =  case   when datediff(minute,eo_dtstart,current_timestamp )>1 then datediff(minute,eo_dtstart,current_timestamp ) else 1 end,
        eo_dtfin = null, eo_count = case when eo_count<1 then 1 else 1 end , eo_productivity = 1
        where eo_id = :eo_id ;

end";
        //Остановить работы пользователя pe_id. Работы останавливаются для сотрудников  РЦ перед стартом работы
        // Продолжительность работы расчитывается и устнавливается по дате начала окончания работы
        // Если продолжительость больше 12 часовой смены - 720 мин , то устанавливается по расчетному времени.
        public const string SQLSTOPWORKFORPREPRESSUSER = @"execute block as
declare variable eo_id integer ;
declare variable eo_calcduration decimal(15,7);
declare variable eo_duration decimal(15,7);
declare variable eo_dtstart timestamp;
begin
   for select  e.eo_id,e.eo_calcduration,e.eo_dtstart  from  executorsopr e
      left join factoperations f on f.fo_id=e.fo_id
      left join operations o on f.op_id = o.op_id
      left join typeoper t on o.ty_id = t.ty_id
      where e.pe_id ={0}  and  e.eo_dtstart > (current_date - {1})  and coalesce(e.eo_durationwithpause,0) < 0.9 and  t.gr_id in ({2},{3}) and o.op_state={4}
      into :eo_id,:eo_calcduration,:eo_dtstart do
      begin
        eo_duration =  datediff(minute,eo_dtstart,current_timestamp );
        if (eo_duration>720.0) then  eo_duration = eo_calcduration;
        if (eo_duration<1) then eo_duration = 1;
        update executorsopr   set  eo_durationwithpause  =  :eo_duration,
        eo_duration  =  :eo_duration,
        eo_dtfin = dateadd(minute,:eo_duration,eo_dtstart), eo_count = 1 ,eo_productivity = 1
        where eo_id = :eo_id ;
      end
end";


        // закрыть( установить статус готово) препресс операциям указанного заказа
        //close (set the status to ready) prepress operations of the specified order
        public const string SQLFINPREPRESSOPERINORDER = @"execute block 
as
declare variable opid integer;
declare variable or_kod integer = {0};
declare variable pe_id  integer  = {1};
begin
  for select o.op_id from operations o
      left join typeoper t on o.ty_id = t.ty_id
      where o.or_kod=:or_kod and t.gr_id in (2,5) and  coalesce( o.op_state,0) != 150 into :opid do
        update operations set op_dtstartfact = current_timestamp,
          op_dtfinfact=  dateadd(minute, 1,current_timestamp), op_productivity = 1,op_durationfact=1,
          op_state = 150 
          where op_id=:opid ;
end";

        // Закончить начатую вовремя не закрытую смену для пользователя. Дата окончания вычисляется по времени окончания работ или определяется установленной продолжителностью 
        //End an unclosed shift started on time for the user
        public const string SQLFINTIMESHEET = @"execute block 
as

declare variable pe_id  integer  = {0};
declare variable  deflengthshift integer ={1} ;
declare variable  maxlengthshift integer =-{2};
declare variable  maxlengthshiftplus integer ;
declare variable lastworkdate timestamp;
declare variable startshiftdate timestamp;
declare variable ts_id  integer;
begin
  ts_id=0;
  maxlengthshiftplus = abs(maxlengthshift);
  select max( t.ts_id) from timesheet t where t.pe_id=:pe_id
     and   t.ts_start < dateadd(minute, :maxlengthshift,current_timestamp)
     and t.ts_fin is null into :ts_id;
   if (ts_id>0) then
   begin

     select max(e.eo_dtfin) from executorsopr e where e.pe_id =:pe_id  into :lastworkdate;
     lastworkdate = coalesce(lastworkdate, dateadd(year, -1,current_timestamp));
     select t.ts_start from timesheet t where t.ts_id=:ts_id  into startshiftdate;
     if ((lastworkdate<startshiftdate) or (lastworkdate>(dateadd(minute,maxlengthshiftplus,startshiftdate))) ) then
       lastworkdate = dateadd(minute,deflengthshift,startshiftdate);
     update timesheet set ts_fin = :lastworkdate where  ts_id=:ts_id;
     execute procedure TIMESHEETFACTSET(:ts_id);
   end
end
";

        // Закончить начатую  смену  пользователя по ребованию (кнопкой). Дата окончания текущее время
        //End an unclosed shift started on time for the user. Set Direct by button
        public const string SQLFINTIMESHEETDIRECT = @"execute block 
as
declare variable pe_id  integer  = {0};
declare variable ts_id  integer;
begin
  ts_id=0;
  select max( t.ts_id) from timesheet t where t.pe_id=:pe_id
     and   t.ts_start < dateadd(minute, -1,current_timestamp) and t.ts_start > dateadd(hour, -12,current_timestamp)
     and t.ts_fin is null into :ts_id;
   if (ts_id>0) then
   begin
     update timesheet set ts_fin = current_timestamp where  ts_id=:ts_id;
     execute procedure TIMESHEETFACTSET(:ts_id);
   end
end";


        // Закончить начатую вовремя не закрытую смену для  членов  бригады 
        //End an unclosed shift started on time for the personal brogade
        public const string SQLFINTIMESHEETBRIGADE = @"execute block 
as
declare variable  ws_id integer = {0};
declare variable pe_id  integer ;
declare variable  deflengthshift integer ={1} ;
declare variable  maxlengthshift integer =-{2};
declare variable  maxlengthshiftplus integer ;
declare variable lastworkdate timestamp;
declare variable startshiftdate timestamp;
declare variable ts_id  integer;
begin
  ts_id=0;
  maxlengthshiftplus = abs(maxlengthshift);
  for select pe_id from brigade where ws_id=:ws_id  and br_fin < current_date - 36500 into :pe_id do
  begin
      select max( t.ts_id) from timesheet t where t.pe_id=:pe_id
         and   t.ts_start < dateadd(minute, :maxlengthshift,current_timestamp)
         and t.ts_fin is null into :ts_id;
       if (ts_id>0) then
       begin
         select max(e.eo_dtfin) from executorsopr e where e.pe_id =:pe_id  into :lastworkdate;
         lastworkdate = coalesce(lastworkdate, dateadd(year, -1,current_timestamp));
         select t.ts_start from timesheet t where t.ts_id=:ts_id  into startshiftdate;
         if ((lastworkdate<startshiftdate) or (lastworkdate>(dateadd(minute,deflengthshift,startshiftdate))) ) then
           lastworkdate = dateadd(minute,deflengthshift,startshiftdate);
         update timesheet set ts_fin = :lastworkdate where  ts_id=:ts_id;
         execute procedure TIMESHEETFACTSET(:ts_id);
       end
  end
end
";

        // Закончить начатую  для  членов  бригады кнопкой
        //End an unclosed shift started on time for the personal brIgade Direct by button
        public const string SQLFINTIMESHEETBRIGADEDIRECT = @"execute block 
as
declare variable  ws_id integer = {0};
declare variable pe_id  integer ;
declare variable ts_id  integer;
declare variable curdt timestamp;
begin
  ts_id=0;
  curdt   = current_timestamp;
  for select pe_id from brigade where ws_id=:ws_id  and br_fin < current_date - 36500 into :pe_id do
  begin
      select max( t.ts_id) from timesheet t where t.pe_id=:pe_id
         and   t.ts_start < dateadd(minute,-1,:curdt)
         and t.ts_fin is null into :ts_id;
       if (ts_id>0) then
       begin
         update timesheet set ts_fin = :curdt where  ts_id=:ts_id;
         execute procedure TIMESHEETFACTSET(:ts_id);
       end
  end
end";

        public const string SQLSETREMTOEXECUTORS = @"execute block as
declare variable eo_id integer ;
begin
  select first(1) e.eo_id from  factoperations f
  left join executorsopr e on f.fo_id=e.fo_id
  where f.op_id =   {0}      and e.eo_durationwithpause = 0 into :eo_id;
 if (coalesce(eo_id,0)>0) then
   update executorsopr   set  eo_rem = '{1}' where eo_id=:eo_id;
end";

        public const string SQLSHIFTFINISH = "update timesheet set ts_fin = dateadd(hour,9,ts_start) where  ts_start < dateadd(hour,-14,current_timestamp) and  ts_fin is null    and  not (ts_start  is null)";

        //Возвращает Для указанного рабочего за указанный период суммарную расчетную и фактическую продолжительность работы со  списком машин на котором он их выполнил
        public const string SQLWORKTOMACHIN = @"select l.ml_id,max(m.mn_name),  sum( e.eo_duration/60.00 ) as Duration ,sum(e.eo_calcduration/60.00) as CalcDuration,count(e.eo_id) as cnt
      from executorsopr e
      left join factoperations f on f.fo_id=e.fo_id
      left join operations o on o.op_id=f.op_id
      left join machinlist l on l.ml_id=o.ml_id
      left join machins m on m.mn_id=l.mn_id
      left join typeoper y on y.ty_id=o.ty_id
      where e.pe_id={0}  and
      e.eo_dtstart>='{1}'
      and e.eo_dtfin <='{2}' and not(y.ty_id in(0))
      group by l.ml_id";

        //Для указанных основного рабочего  , машины , периода возвращает продолжительность работы расчетную и фактическую . 
        public const string SQLEXECWORKTOPERSONAL = @"select y.ty_id, max(y.ty_name) as ty_name,  sum( e.eo_duration/60.00 ) as Duration ,sum(e.eo_calcduration/60.00) as CalcDuration,count(e.eo_id) as cnt
      from executorsopr e
      left join factoperations f on f.fo_id=e.fo_id
      left join operations o on o.op_id=f.op_id

      left join typeoper y on y.ty_id=o.ty_id
      where e.pe_id={0}  and
      e.eo_dtstart>='{1}'
      and e.eo_dtfin <='{2}' and o.ml_id={3} and   not(y.ty_id in(0))
      group by y.ty_id";

    }


    
}
