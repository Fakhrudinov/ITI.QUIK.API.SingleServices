SELECT ClientID,AccountNumber,Manager,Owner,Depositary,ContractNo,ContractDate FROM DepoClientAccounts t where t.ClientID in (@UniqueCodes);