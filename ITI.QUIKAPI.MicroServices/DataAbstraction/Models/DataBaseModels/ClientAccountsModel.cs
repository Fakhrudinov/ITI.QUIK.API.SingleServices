namespace DataAbstraction.Models.DataBaseModels
{
    public class ClientAccountsModel
    {
        public string ClientID { get; set; }
        public string Account { get; set; }
        public string SubAccount { get; set; }
    }
}
/*
Таблица ClientAccounts
Лицевые счета клиента.
Структура
ClientID varchar(13) NOT NULL,
Account varchar(32) NOT NULL,
SubAccount varchar(32) NOT NULL
PK_ClientAccounts PRIMARY KEY (ClientID, Account, SubAccount)
Описание
ClientID: Код клиента.
Account: Лицевой счёт.
SubAccount: Субсчёт (пустая строка при отсутствии субсчёта).
*/
