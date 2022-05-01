using DataAbstraction.Models;

namespace DataAbstraction.Interfaces
{
    public interface ISFTPService
    {
        StringResponceModel CheckConnections();
        StringResponceModel BlockUserByUID(int uid);
        StringResponceModel BackUpFileCodesIni();
        StringResponceModel AddMAtrixCodesToFileCodesIni(CodesArrayModel model);
        StringResponceModel BackUpFileDealLibIni();
        StringResponceModel BackUpFileSpbfutlibIni();
        StringResponceModel BlockUserByMatrixClientCode(string code);
        StringResponceModel BlockUserByFortsClientCode(string code);
        StringResponceModel SetNewPubringKeyByMatrixClientCode(MatrixCodeAndPubringKeyModel model);
        StringResponceModel SetNewPubringKeyByFortsClientCode(FortsCodeAndPubringKeyModel model);
        StringResponceModel GetResultOfXMLFileUpload(string file);
        StringResponceModel RequestFileAllClients();
        StringResponceModel DownloadAllClients();
        StringResponceModel SendNewClientOptionWorkshop(NewClientOptionWorkShopModel model);
        StringResponceModel SendNewClient(NewClientModel model);
    }
}
