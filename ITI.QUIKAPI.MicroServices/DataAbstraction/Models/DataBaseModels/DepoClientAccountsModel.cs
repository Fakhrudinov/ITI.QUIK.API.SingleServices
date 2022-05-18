namespace DataAbstraction.Models.DataBaseModels
{
    public class DepoClientAccountsModel
    {
        public string ClientID { get; set; }
        public string AccountNumber { get; set; }
        public string Manager { get; set; }
        public string Owner { get; set; }
        public string Depositary { get; set; }
        public string ContractNo { get; set; }
        public int ContractDate { get; set; }
    }
}
/*
Таблица DepoClientAccounts.
Депо счета клиента.

Структура
ClientID varchar(13) NOT NULL,
AccountNumber varchar(32) NOT NULL,
Manager varchar(192) NOT NULL,
Owner varchar(192) NOT NULL,
Depositary varchar(64) NOT NULL,
ContractNo varchar(32) NOT NULL,
ContractDate int NOT NULL
pk_depo_client_accounts PRIMARY KEY (ClientID, AccountNumber)

Описание
ClientID: Код клиента.
AccountNumber: Номер счета.
Manager: Распорядитель.
Owner: Владелец.
Depositary: Депозитарий.
ContractNo: Номер депозитарного договора.
ContractDate: Дата заключения депозитарного договора. Формат: int[год][месяц][день].
*/