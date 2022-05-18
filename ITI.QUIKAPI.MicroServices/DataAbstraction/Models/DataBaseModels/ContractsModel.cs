namespace DataAbstraction.Models.DataBaseModels
{
    public class ContractsModel
    {
        public string ClientID { get; set; }
        public string Number { get; set; }
        public int RegisterDate { get; set; }
        public int Type { get; set; }
        public string ? Manager { get; set; }
    }
}
/*
Таблица Contracts.
Клиентские договоры.

Структура
ClientID varchar(13) NOT NULL,
Type int NOT NULL,
Number varchar(32) NOT NULL,
RegisterDate int NOT NULL,
Manager varchar(255) NULL
pk_contracts PRIMARY KEY (ClientID, Type, Number)

Описание
ClientID: Код клиента.
Type: Тип договора: 0 – договор обслуживания, 1 – депозитарный договор.
Number: Номер договора.
RegisterDate: Дата заключения договора.Формат: ГГГГММДД.
Manager: Содержит имя менеджера, соответствующего данному договору обслуживания.
*/