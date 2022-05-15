namespace DataAbstraction.Models.DataBaseModels
{
    public class ClientInfoModel
    {
        public string ClientCode { get; set; }
        public string ? FullName { get; set; }
        public string ? EMail { get; set; }
        public string ClientType { get; set; }
        public string Resident { get; set; }
        public string ? Address { get; set; }
    }
}
/*
Таблица ClientInfo
Информация о клиентах

Структура
ClientCode varchar(20) NOT NULL,
FullName varchar(255) NULL,
Email varchar(128) NULL,
ClientType char(1) NOT NULL,
Resident char(1) NOT NULL,
Address varchar(255) NULL
PK_ClientInfo PRIMARY KEY (ClientCode)

Описание
ClientCode: Код клиента.
FullName: Имя (наименование) клиента.
Email: E-mail клиента.
ClientType: Тип клиента (физическое/юридическое лицо). Принимает значение «P» для физического лица, «O» для юридического лица, «?» для прочих типов.
Resident: Тип клиента(резидент/нерезидент). Принимает значения «R» для резидентов, «N» для нерезидентов.
Address: Адрес(местонахождение) клиента.
*/