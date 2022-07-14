using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface ISFTPService
    {
        ListStringResponseModel CheckConnections();
        ListStringResponseModel BlockUserByUID(int uid);
        ListStringResponseModel BackUpFileCodesIni();
        ListStringResponseModel AddMAtrixCodesToFileCodesIni(CodesArrayModel model);
        ListStringResponseModel BackUpFileDealLibIni();
        ListStringResponseModel BackUpFileSpbfutlibIni();
        ListStringResponseModel BlockUserByMatrixClientCode(string code);
        ListStringResponseModel BlockUserByFortsClientCode(string code);
        ListStringResponseModel SetNewPubringKeyByMatrixClientCode(MatrixCodeAndPubringKeyModel model);
        ListStringResponseModel SetNewPubringKeyByFortsClientCode(FortsCodeAndPubringKeyModel model);
        ListStringResponseModel GetResultOfXMLFileUpload(string file);
        ListStringResponseModel RequestFileCurrClnts();
        ListStringResponseModel DownloadCurrClnts();
        ListStringResponseModel SendNewClientOptionWorkshop(NewClientOptionWorkShopModel model);
        ListStringResponseModel SendNewClient(NewClientModel model);
        ListStringResponseModel GetUIDByMatrixCode(string matrixClientCode);
        ListStringResponseModel GetUIDByFortsCode(string fortsClientCode);
        ListStringResponseModel SetStartMessage(StartMessageModel model);
        ListStringResponseModel DeleteStartMessageForUID(int uid);
        ListStringResponseModel DeleteStartMessageForAll();
        ListStringResponseModel GetStartMessageforAll();
        ListStringResponseModel GetStartMessageforUID(int uid);
        ListStringResponseModel SetAllTradesByMatrixClientCode(MatrixClientPortfolioModel model);
        ListStringResponseModel SetAllTradesByFortsClientCode(FortsClientCodeModel model);
        ListStringResponseModel GetUIDByMatrixClientAccount(string matrixClientAccount);
    }
}
