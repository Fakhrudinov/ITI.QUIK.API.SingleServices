using System.ComponentModel;

namespace DataAbstraction.Models.DataBaseModels
{
    public class NewMNPClientModel
    {
        public ClientInformationModel Client { get; set; }  
        
        [DefaultValue(true)]
        public bool isClientPerson { get; set; }//P //O Тип клиента. «P» для физического лица, «O» для юридического лица, «?» для прочих типов.
        [DefaultValue(true)]
        public bool isClientResident { get; set; }//N //R Тип клиента(резидент/нерезидент). Принимает значения «R» для резидентов, «N» для нерезидентов.
        [DefaultValue("РФ, 129128, Москва, Бажова, 1, 69")]
        public string? Address { get; set; } //A35E3P1, Респ. Казахстан, г. Алматы, ул. Баймагамбетова, д. 206
        [DefaultValue(20220515)]
        public int RegisterDate { get; set; }//20160714 Дата заключения договора.Формат: ГГГГММДД. 

        public MatrixClientCodeModel[]? CodesMatrix { get; set; }
        public MatrixToFortsCodesMappingModel[]? CodesPairRF { get; set; }

        // not necessary:
        [DefaultValue(null)]
        public string? Manager { get; set; } = null;//NULL Содержит имя менеджера, соответствующего данному договору обслуживания.
        [DefaultValue("Дог.BP12345")]
        public string ? Number { get; set; } //Дог.BP17178  Номер договора.
        [DefaultValue("")]
        public string SubAccount { get; set; } = "";//   //SubAccount: Субсчёт(пустая строка при отсутствии субсчёта).

        [DefaultValue("НДЦ")]
        public string Depositary { get; set; } = "НДЦ";//НДЦ Депозитарий
        [DefaultValue(false)]
        public bool isClientDepo { get; set; } = false;//0  Тип договора: 0 – договор обслуживания, 1 – депозитарный договор.
        [DefaultValue("ITinvest")]
        public string DepoClientAccountsManager { get; set; } = "ITinvest"; //ITinvest Распорядитель.
    }
}
/*
Таблица Contracts.
    Клиентские договоры.
Описание
    ClientID: Код клиента.
    Type: Тип договора: 0 – договор обслуживания, 1 – депозитарный договор.
    Number: Номер договора.
    RegisterDate: Дата заключения договора.Формат: ГГГГММДД.
    Manager: Содержит имя менеджера, соответствующего данному договору обслуживания.

Таблица ClientInfo
    Информация о клиентах
Описание
    ClientCode: Код клиента.
    FullName: Имя (наименование) клиента.
    Email: E-mail клиента.
    ClientType: Тип клиента (физическое/юридическое лицо). Принимает значение «P» для физического лица, «O» для юридического лица, «?» для прочих типов.
    Resident: Тип клиента(резидент/нерезидент). Принимает значения «R» для резидентов, «N» для нерезидентов.
    Address: Адрес(местонахождение) клиента.

Таблица ClientAccounts
    Лицевые счета клиента.
Описание
    ClientID: Код клиента.
    Account: Лицевой счёт.
    SubAccount: Субсчёт (пустая строка при отсутствии субсчёта).

Таблица DepoClientAccounts.
    Депо счета клиента.
Описание
    ClientID: Код клиента.
    AccountNumber: Номер счета.
    Manager: Распорядитель.
    Owner: Владелец.
    Depositary: Депозитарий.
    ContractNo: Номер депозитарного договора.
    ContractDate: Дата заключения депозитарного договора. Формат: int[год][месяц][день].
*/