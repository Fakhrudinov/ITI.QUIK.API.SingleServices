// � ��� ����������, ��� ��������� �������� <���� �������>, ��� ��������� ���������� ���������
//   ������������ � �������� <���� �������> �������� NULL. �������� <��� �������> ������ ""
//   ����� ���������������, ��������� ������� �������� �� ������ ��� ������� �� ���������.
#pragma once

#ifndef QDEALERAPI_H
#define QDEALERAPI_H

#ifdef __GNUC__
#define DEPRECATED(spec, func, message) spec func __attribute__ ((deprecated))
#elif _MSC_VER >= 1900
#define DEPRECATED(spec, func, message) spec [[deprecated(message)]] func
#elif _MSC_VER < 1900
#define DEPRECATED(spec, func, message) __declspec(deprecated(message)) spec func
#else
#pragma message("WARNING: You need to implement DEPRECATED for this compiler")
#define DEPRECATED(spec, func, message) func
#endif

#ifdef QDEALERAPI_EXPORTS
#define QDEALERAPI_API extern "C" __declspec(dllexport)
#else
#define QDEALERAPI_API extern "C" __declspec(dllimport)
#endif

static const char* ALL_CLASSES = "<ALL>";
static const char* ALL_INSTRUMENTS = "<ALL>";
static const char* ALL_CLIENTS = "<ALL>";
static const char* ALL_REPO = "<ALL_REPO>";
static const char* ALL_NDM = "<ALL_NDM>";
static const char* ALL_REPO_CCP = "<ALL_REPO_CCP>";
static const char* ALL_NDM_CCP = "<ALL_NDM_CCP>";

enum QDAPI_Errors {
	QDAPI_ERROR_SUCCESS                            = 0    // �������� ����������.
	, QDAPI_ERROR_QADMINSRV                        = 1    // ������ �� ������� ������� QAdminSrv
	, QDAPI_ERROR_NOT_INITIALIZED                  = 2    // �������� ������ ����� �������� ����������. ������ �� ��� ���������, ����������� ��� ������� � ������� QA.
	, QDAPI_ERROR_CONNECT_FAILED                   = 3    // ���������� �� ����� ���� �����������. ������ ������������ ����������.
	, QDAPI_ERROR_CONNECT_ALREADYUSE               = 4    // ���������� �� ����� ���� �����������. �������������� UID ��� ������������ � ������ ����������.
	, QDAPI_ERROR_NOT_CONNECTED                    = 5    // ���������� �� �����������. ���������� �� ���� �����������. ������ ����������.
	, QDAPI_ERROR_TIMEOUT                          = 6    // ����� �� �������. ��������� ��� ���������� �������� ������ �� ������� QA � ���������� �������� �� ����� ��������.
	, QDAPI_ERROR_CONNECTION_LOST                  = 7    // ���������� ��������. ��������� ��� ������� ���������� � �������� QA. ������ ���������� ��������� ������� �� ��������.
	, QDAPI_ERROR_NO_RIGHTS                        = 8    // �������� ���� �� ������ ��������.
	, QDAPI_ERROR_DL_NOT_FOUND                     = 9    // �� ������ ����� ����������� ��������� ���.
	, QDAPI_ERROR_DL_READ_PROHIBITED               = 10   // ������ � ���������� ��� ��������. ���������� ���� �� ������ � ���������� ���.
	, QDAPI_ERROR_DL_WRITE_PROHIBITED              = 11   // ������ �� ������ � ���������� ��� ��������. ���������� ���� �� ��������� �� ������ � ���������� ���.
	, QDAPI_ERROR_DL_WRITE_NOT_AVAILABLE           = 12   // ������� ������ � ���������� ��� �� ��������� �� ���������.
	, QDAPI_ERROR_UPDATE_FILE                      = 13   // ������ ���������� �����.

	, QDAPI_ERROR_UNCLASSIFIED                     = 1001 // ����� ������.
	, QDAPI_ERROR_NOT_LOADED_SETTINGS_FOR_FIRM     = 1002 // ������������ ��� ����� ��� ������� � ���������� ���.
	, QDAPI_ERROR_INCORRECT_PARAMETER              = 1003 // ������������ �������� �������.
	, QDAPI_ERROR_DATA_NOT_FOUND                   = 1004 // ������ �� �������.
	, QDAPI_ERROR_FAILED_RELEASE_MEMORY            = 1005 // ������ ������������ ������.
	, QDAPI_ERROR_IMPOSSIBLE_ALLOCATE_MEMORY       = 1006 // ������ ��������� ������.
	, QDAPI_ERROR_IMPOSSIBLE_OPEN_FILE             = 1007 // ������ �������� �����.
	, QDAPI_ERROR_IMPOSSIBLE_CLOSE_FILE            = 1008 // ������ ���������� �����.
	, QDAPI_ERROR_NO_VALID_LENGTH_CLASS_CODE       = 1009 // ������������ ����� ���� ������.
	, QDAPI_ERROR_NO_VALID_LENGTH_CLIENT_CODE      = 1010 // ������������ ����� ���� �������.
	, QDAPI_ERROR_NO_VALID_LENGTH_CURR_CODE        = 1011 // ������������ ����� ���� ������.
	, QDAPI_ERROR_NO_VALID_LENGTH_FIRM_CODE        = 1012 // ������������ ����� ���� �����.
	, QDAPI_ERROR_NO_VALID_LENGTH_SEC_CODE         = 1013 // ������������ ����� ���� �����������.
	, QDAPI_ERROR_NO_VALID_LENGTH_TRADE_ACCOUNT    = 1014 // ������������ ����� ���� ��������� �����.
	, QDAPI_ERROR_TEMPLATE_NOT_FOUND               = 1015 // ������ �� ������.
	, QDAPI_ERROR_DATA_ALREADY_EXIST               = 1016 // ����� ������ ��� ����������.
	, QDAPI_ERROR_NO_VALID_LENGTH_PARTNER_CODE     = 1017 // ������������ ����� ���� �����������.
	, QDAPI_ERROR_NO_VALID_LENGTH_SETTLE_CODE      = 1018 // ������������ ����� ���� ��������.
	, QDAPI_ERROR_NOT_SUPPORTED                    = 1019 // ������ ��������� �� ��������������.
	, QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND        = 1020  // ���������� ��������� �� �������.
	, QDAPI_ERROR_NO_VALID_LENGTH_TEMPLATE_CODE    = 1021  // ������������ ����� ���� �������.
	, QDAPI_ERROR_NO_VALID_LENGTH_TAG_CODE         = 1022  // ������������ ����� ���-����.
};

enum QDAPI_SettingsScope {
	QDAPI_SETTINGS_SCOPE_MAIN = 0
	, QDAPI_SETTINGS_SCOPE_ADDITIONAL = 1
};

#pragma pack(push)
#pragma pack(4)
//==============================================================================
// ���������� �����
//==============================================================================
// ������ �����
struct QDAPI_ArrayStrings {
	size_t count;
	char** elems;
};
//==============================================================================
// ������ ����� �����
struct QDAPI_ArrayIntNumbers {
	size_t count;
	int* elems;
};
//==============================================================================
// ���� (������, ������)
struct QDAPI_StringToString {
	char* fst;
	char* snd;
};
//==============================================================================
// ����������� �������� ���������
struct QDAPI_RestrictOptionOrdersBody {
	int day;                                                                    // ���� ��������� ���� ����������
	int month;                                                                  // ����� ��������� ���� ����������
	int year;                                                                   // ��� ��������� ���� ����������
	double max_dev_strike;                                                      // ������������ ���������� �������
};
// ����������� �������� ��������� �� ������� �����
struct QDAPI_RestrictOptionOrders {
	char* base_asset;
	QDAPI_RestrictOptionOrdersBody restrBody;
};
// ������ ����������� �������� ��������� �� ������� ������
struct QDAPI_ArrayRestrictOptionOrders {
	size_t count;
	QDAPI_RestrictOptionOrders* elems;
};
//==============================================================================
// ��������
struct QDAPI_Discounts {
	double KLong;
	double KShort;
	double DLong;
	double DShort;
	double DLong_min;
	double DShort_min;
};
//==============================================================================
enum QDAPI_PriceType {                                                            // �������������� ����� ���
	QDAPI_PRICE_TYPE__DEFAULT = 0                                                 // �� �����
	, QDAPI_PRICE_TYPE__WAPRICE = 1                                               // ������� ����������������
	, QDAPI_PRICE_TYPE__LAST = 2                                                  // ���� ��������� ������
	, QDAPI_PRICE_TYPE__OPEN = 3                                                  // ���� ��������
	, QDAPI_PRICE_TYPE__MARKETPRICE = 4                                           // �������� ���� ���������� ���
	, QDAPI_PRICE_TYPE__PREVPRICE = 5                                             // ���� ��������
	, QDAPI_PRICE_TYPE__THEORPRICE = 6                                            // ������������� ���� �������
	, QDAPI_PRICE_TYPES_COUNT
};
// ��������� ��� �������� ���������� ���������� ��� �� ������� ��� ������������
struct QDAPI_PriceTypeAndPercent {
	QDAPI_PriceType priceType;                                                  // ��� ����
	double deviationPercent;                                                    // ���������� ���� � ���������
};
struct QDAPI_PriceLimit {
	char activeCode[13];                                                        // ��� ������ ��� ����������� (� ����������� �� ���������)
	QDAPI_PriceType priceType;                                                  // ��� ����
	double deviationPercent;                                                    // ���������� ���� � ���������
};
struct QDAPI_ArrayPriceLimit {
	size_t count;
	QDAPI_PriceLimit* elems;
};
// ��������� ��� �������� ���������� ���������� ��� �� ������� ��� ������������
struct QDAPI_VolumeRestrictionByAvgTurnover {
	QDAPI_ArrayStrings classList;                                               // ������ �������
	QDAPI_ArrayStrings instrList;                                               // ������ ������������
	double restPercent;                                                         // �����������, %
	double alertPercent;                                                        // ��������������, %
	char valuationClass[13];                                                    // ����� ������
};
struct QDAPI_ArrayVolumeRestrictionByAvgTurnover {
	size_t count;
	QDAPI_VolumeRestrictionByAvgTurnover* elems;
};
struct QDAPI_VolumeRestriction {
	char classCode[13];                                                         // ��� ������
	double restPercent;                                                         // �����������, %
	double alertPercent;                                                        // ��������������, %
	char valuationClass[13];                                                    // ����� ������
};
struct QDAPI_ArrayVolumeRestriction {
	size_t count;
	QDAPI_VolumeRestriction* elems;
};
// ��������� ��� �������� �������������� ��������
enum QDAPI_OperationSide {
	QDAPI_SIDE_NOT_CONSIDERED = 0                                               // �������������� �� �����
	, QDAPI_SIDE_ANY = 1                                                        // ����� ��������������
	, QDAPI_SIDE_BUY = 2                                                        // �������
	, QDAPI_SIDE_SELL = 3                                                       // �������
};
// ��������� ��� �������� ������ ������������ (� ������ ��������������)
struct QDAPI_SecurityBySide {
	char secCode[13];
	QDAPI_OperationSide side;
};
struct QDAPI_ArraySecurityBySide {
	size_t count;
	QDAPI_SecurityBySide* elems;
};
// ��������� ��� �������� ������ ������� (� ������ ��������������)
struct QDAPI_ClassBySide {
	char classCode[13];
	QDAPI_OperationSide side;
};
struct QDAPI_ArrayClassBySide {
	size_t count;
	QDAPI_ClassBySide* elems;
};
// ��� API
// ��������� ��� �������� ������ ��� - ����-�����/����������� ��������
struct QDAPI_AdditionalSpotActive {
	char spotCode[13];                                                          // ��� ����-������
	double lotRatio;                                                            // ����������� ��������. �������� 0 ������������� ���������� �������� ������������ �������� � ����������
};
struct QDAPI_ArraySpotListForBaseAsset {
	size_t count;
	QDAPI_AdditionalSpotActive* elems;
};
enum QDAPI_PortfolioValueMode {
	QDAPI_PORTFOLIO_VALUE_MODE_NO_VARMARGIN = 0
	, QDAPI_PORTFOLIO_VALUE_MODE_ADD_POSITIVE_VARMARGIN = 1
	, QDAPI_PORTFOLIO_VALUE_MODE_ADD_NEGATIVE_VARMARGIN = 2
	, QDAPI_PORTFOLIO_VALUE_MODE_ADD_ALL_VARMARGIN = 3
};
struct QDAPI_MainSettingsOfPortfolioRiskConfigGlobal {
	QDAPI_MainSettingsOfPortfolioRiskConfigGlobal() {
		boardTag[0] = '\0';
		currency[0] = '\0';
		isLimitKind = false;
		isPortfolioValueMode = false;
		optionLiquidationValueByTheoreticalPrice = 0;
		useFullPortfolioValue = 0;
	}
	char boardTag[13];                                                          // ���, ������ ������ ������������� ���������� ���������
	char currency[4];                                                           // ������, ������ ������ ������������� ���������� ���������
	bool isLimitKind;                                                           // ����� �� ��� ������
	int limitKind;                                                              // ��� ������
	int optionLiquidationValueByTheoreticalPrice;                               // ���� ����. ���� ��� ������� ����. �����. ��������. ��������� �������� 0 � 1.
	bool isPortfolioValueMode;                                                  // ����� �� ����� ����� ������������ �����
	QDAPI_PortfolioValueMode portfolioValueMode;                                // ����� ����� ������������ �����
	int useFullPortfolioValue;                                                  // ������������� ������ ��������� ��������. ��������� �������� 0 (������������� ���������� ��������) � 1.
};
struct QDAPI_SpreadTier {
	char tierName[13];                                                          // ������������ ����
	int tierTerm;                                                               // ����������� �����
};
struct QDAPI_ArrayOfSpreadTiers {
	size_t count;
	QDAPI_SpreadTier* elems;
};
enum QDAPI_VolatilityType {
	QDAPI_VOLATILITY_TYPE_FROM_SETTINGS = 0
	, QDAPI_VOLATILITY_TYPE_FROM_TS = 1
};
enum QDAPI_OptionDeltaType {
	QDAPI_OPTION_DELTA_TYPE_AVERAGE = 0
	, QDAPI_OPTION_DELTA_TYPE_BY_MAX_RISK_SCENARIO = 1
};
enum QDAPI_OrderLimitationMode {
	QDAPI_ORDER_LIMITATION_MODE_WITHOUT_NETTING = 0
	, QDAPI_ORDER_LIMITATION_MODE_ACCOUNT_SPREAD_LIQUIDATION = 1
	, QDAPI_ORDER_LIMITATION_MODE_ACCOUNT_SPREAD_FORMATION = 2
};
enum QDAPI_PriceScanRangeType {
	QDAPI_PRICE_SCAN_RANGE_TYPE_CLEARING_PRICE_PERCENT = 0
	, QDAPI_PRICE_SCAN_RANGE_TYPE_MONEY = 1
	, QDAPI_PRICE_SCAN_RANGE_TYPE_FUTURE_COLLATERAL = 2
};
enum QDAPI_OptionType {
	QDAPI_OPTION_TYPE_LONG_CALL = 0
	, QDAPI_OPTION_TYPE_SHORT_CALL = 1
	, QDAPI_OPTION_TYPE_LONG_PUT = 2
	, QDAPI_OPTION_TYPE_SHORT_PUT = 3
};
struct QDAPI_SpreadRatio {
	char firstTier[13];                                                         // ������ ����
	char secondTier[13];                                                        // ������ ����
	double longRate;                                                            // ����������� ����
	double shortRate;                                                           // ����������� ����, �������� 0 ������������� ���������� ��������
};
struct QDAPI_InterSpread {
	char baseAsset[13];                                                         // ������� �����
	QDAPI_SpreadRatio spreadRatio;                                              // ����������� ��� ���� �����
};
struct QDAPI_ArrayInterSpread {
	size_t count;
	QDAPI_InterSpread* elems;
};
struct QDAPI_ArrayIntraSpread {
	size_t count;
	QDAPI_SpreadRatio* elems;
};
struct QDAPI_VolatilitySlope {
	QDAPI_OptionType optionType;                                                // ��� �������
	double strikeDeviation;                                                     // ���������� �������
	double volatilityRatio;                                                     // ����������� �������������
};
struct QDAPI_ArrayVolatilitySlope {
	size_t count;
	QDAPI_VolatilitySlope* elems;
};
struct QDAPI_PortfolioRiskConfigSettings {
	QDAPI_PortfolioRiskConfigSettings() {
		isBoundaryImpliedRisk = false;
		boundaryImpliedRisk = 35;
		isBoundaryPriceChange = false;
		boundaryPriceChange = 200;
		isExpMatDateTerm = false;
		expMatDateTerm = 1;
		isFuturesLiquidityFactor = false;
		futuresLiquidityFactor = 100;
		isKGO = false;
		KGO = 1.0;
		isMinShortOptionsIM = false;
		minShortOptionsIM = 100;
		isOptionDeltaType = false;
		optionDeltaType = QDAPI_OPTION_DELTA_TYPE_AVERAGE;
		isOrderKGO = false;
		orderKGO = KGO;
		isOrderLimitationMode = false;
		orderLimitationMode = QDAPI_ORDER_LIMITATION_MODE_WITHOUT_NETTING;
		isPriceScanRange = false;
		priceScanRange = 100;
		isPriceScanRangeType = false;
		priceScanRangeType = QDAPI_PRICE_SCAN_RANGE_TYPE_CLEARING_PRICE_PERCENT;
		isRestrictMaxVolatility = false;
		restrictMaxVolatility = 100;
		isRiskFreeRate = false;
		riskFreeRate = 100;
		isSpotVarMarginNeg = false;
		spotVarMarginNeg = 0;
		isSpotVarMarginPos = false;
		spotVarMarginPos = 0;
		interSpread = QDAPI_ArrayInterSpread();
		interSpread.count = 0;
		intraSpread = QDAPI_ArrayIntraSpread();
		intraSpread.count = 0;
		isUseSpotNetting = false;
		useSpotNetting = 0;
		isVolatility = false;
		volatility = 100;
		isVolatilityChange = false;
		volatilityChange = 0;
		volatilitySlope = QDAPI_ArrayVolatilitySlope();
		volatilitySlope.count = 0;
		isVolatilityType = false;
		volatilityType = QDAPI_VOLATILITY_TYPE_FROM_SETTINGS;
	}
	bool isBoundaryImpliedRisk;                                                 // ����� �� ��� ������� ���������
	double boundaryImpliedRisk;                                                 // ��� ������� ���������
	bool isBoundaryPriceChange;                                                 // ����� �� ������� ��������� ���� ��� ������� ���������
	double boundaryPriceChange;                                                 // ������� ��������� ���� ��� ������� ���������
	bool isExpMatDateTerm;                                                      // ������ �� ���������� ���� �� ���������� �������
	double expMatDateTerm;                                                      // ���������� ���� �� ���������� �������
	bool isFuturesLiquidityFactor;                                              // ������ �� ������ ����������� �� ���������
	double futuresLiquidityFactor;                                              // ������ ����������� �� ���������
	bool isKGO;                                                                 // ����� �� ����������� ����������� ��
	double KGO;                                                                 // ����������� ����������� ��
	bool isMinShortOptionsIM;                                                   // ������ �� ������ ������������ �� �� �������� ��������
	double minShortOptionsIM;                                                   // ������ ������������ �� �� �������� ��������
	bool isOptionDeltaType;                                                     // ����� �� ������ ����� ������
	QDAPI_OptionDeltaType optionDeltaType;                                      // ������ ����� ������
	bool isOrderKGO;                                                            // ������ �� ��� ��� ������
	double orderKGO;                                                            // ��� ��� ������
	bool isOrderLimitationMode;                                                 // ����� �� ������� ����� ������
	QDAPI_OrderLimitationMode orderLimitationMode;                              // ������� ����� ������
	bool isPriceScanRange;                                                      // ������ �� ������� ������������
	double priceScanRange;                                                      // ������� ������������
	bool isPriceScanRangeType;                                                  // ����� �� ������ ����������� ������� ������������
	QDAPI_PriceScanRangeType priceScanRangeType;                                // ������ ����������� ������� ������������
	bool isRestrictMaxVolatility;                                               // ������ �� ����������� ������������ �������������
	double restrictMaxVolatility;                                               // ����������� ������������ �������������
	bool isRiskFreeRate;                                                        // ������ �� ����������� ������
	double riskFreeRate;                                                        // ����������� ������
	bool isSpotVarMarginNeg;                                                    // ������ �� ������������� �������� ����-������
	double spotVarMarginNeg;                                                    // ������������� �������� ����-������
	bool isSpotVarMarginPos;                                                    // ������ �� ������������� �������� ����-������
	double spotVarMarginPos;                                                    // ������������� �������� ����-������
	QDAPI_ArrayInterSpread interSpread;                                         // ������ ��������������� ���������� ��
	QDAPI_ArrayIntraSpread intraSpread;                                         // ������ ������������ � ������������� ���������� �� ������ ��������
	bool isUseSpotNetting;                                                      // ����� �� �������� ������� ����-������� � ���������
	int useSpotNetting;                                                         // �������� ������� ����-������� � ���������
	bool isVolatility;                                                          // ������ �� �������������
	double volatility;                                                          // �������������
	bool isVolatilityChange;                                                    // ������ �� ��������� �������������
	double volatilityChange;                                                    // ��������� �������������
	QDAPI_ArrayVolatilitySlope volatilitySlope;                                 // ������������� �� �������� ��������
	bool isVolatilityType;                                                      // ����� �� ������ ������� ������������� ��������
	QDAPI_VolatilityType volatilityType;                                        // ������ ������� ������������� ��������
};
struct QDAPI_PortfolioRiskConfigTemplateIdentifier {
	char* templateCode;                                                         // ������������ �������
	char mainAsset[13];                                                         // ��� �������� ������
};
struct QDAPI_ArrayPortfolioRiskConfigTemplateIdentifier {
	size_t count;
	QDAPI_PortfolioRiskConfigTemplateIdentifier* elems;
};
struct QDAPI_BaseAssetsSpreadOrder {
	char firstBaseAsset[13];                                                    // ������ ������� �����
	char secondBaseAsset[13];                                                   // ������ ������� �����
	int seqNumber;                                                              // ���������� ����� ���������� ���������� ��
};
struct QDAPI_ArrayBaseAssetsSpreadOrder {
	size_t count;
	QDAPI_BaseAssetsSpreadOrder* elems;
};
struct QDAPI_TranoutTag {
	char nonTradeInstrument[13];                                                // ���������� ���
	char classCode[13];                                                         // �����
	char currency[5];                                                           // ������
};
struct QDAPI_ArrayTranoutTag {
	size_t count;
	QDAPI_TranoutTag* elems;
};
struct QDAPI_ArrayDoubleNumbers {
	size_t count;
	double* elems;
};
struct QDAPI_MaxPositionLimit {
	QDAPI_ArrayStrings lsInstruments;                                           // ������ ������������
	bool isLongPosLimit;                                                        // ������� ������� ����������� ������������� ������� ������� �������
	long long longPosLimit;                                                     // ����������� ������������� ������� ������� �������
	bool isShortPosLimit;                                                       // ������� ������� ����������� ������������� ������� �������� �������
	long long shortPosLimit;                                                    // ����������� ������������� ������� �������� �������
};
struct QDAPI_ArrayMaxPositionLimit {
	size_t count;
	QDAPI_MaxPositionLimit* elems;
};
// ��������� ��� �������� ���������� �� ������ (� ������ �������� ������ � ��������� �������)
struct QDAPI_RestrictSecurityByClass {
	QDAPI_ArrayStrings lsTradeAccounts;                                         // ������ �������� ������ (����� ���� ����)
	bool isPeriodExists;                                                        // ����� �� ��������� ������
	int FromTimeHours;                                                          // ������ �������: ����
	int FromTimeMinutes;                                                        // ������ �������: ������
	int TillTimeHours;                                                          // ����� �������: ����
	int TillTimeMinutes;                                                        // ����� �������: ������
};
struct QDAPI_ArrayRestrictSecurityByClass {
	size_t count;
	QDAPI_RestrictSecurityByClass* elems;
};
// ��������� ��� �������� �������� �����������/����������� ������������ � ����� ��������
struct QDAPI_PartnersAndSettleCodesRestrictions {
	char classCode[15];                                                         // ��� ������
	QDAPI_ArrayStrings lsSettleCodes;                                           // ������ ����� ��������
	QDAPI_OperationSide operationSide;                                          // �������������� ��������
	long long maxTerm;                                                          // ������������ ���� ����
	QDAPI_ArrayStrings lsCP;                                                    // ������ ����� ������������
};
struct QDAPI_ArrayPartnersAndSettleCodesRestrictions {
	size_t count;
	QDAPI_PartnersAndSettleCodesRestrictions* elems;
};
// ����������� �� ����������� �����
struct QDAPI_MinOrderQty {
	QDAPI_ArrayStrings lsClasses;                                               // ������ �������
	QDAPI_ArrayStrings lsInstruments;                                           // ������ ������������
	long long qty;                                                              // ����������� ������������ ����������
};
struct QDAPI_ArrayMinOrderQty {
	size_t count;
	QDAPI_MinOrderQty* elems;
};
struct QDAPI_MinOrderValue {
	QDAPI_ArrayStrings lsClasses;                                               // ������ �������
	QDAPI_ArrayStrings lsInstruments;                                           // ������ ������������
	double value;                                                               // ����������� ������������ ������
	char currency[5];                                                           // ������
};
struct QDAPI_ArrayMinOrderValue {
	size_t count;
	QDAPI_MinOrderValue* elems;
};
struct QDAPI_ClassMinOrderQty {
	char classCode[13];                                                         // �����
	long long qty;                                                              // ����������� ������������ ����������
};
struct QDAPI_ArrayClassMinOrderQty {
	size_t count;
	QDAPI_ClassMinOrderQty* elems;
};
struct QDAPI_ClassMinOrderValue {
	char classCode[13];                                                         // �����
	double value;                                                               // ����������� ������������ ����������
	char currency[5];                                                           // ������
};
struct QDAPI_ArrayClassMinOrderValue {
	size_t count;
	QDAPI_ClassMinOrderValue* elems;
};

enum QDAPI_CommissionType {
	QDAPI_COMMISSION_TYPE_FIXED = 0                                             // ������� �� ������, �������� �� ���������
	, QDAPI_COMMISSION_TYPE_TRADE_MAX = 1                                       // �������� �� �������� �� ������ � ����� �� ������
	, QDAPI_COMMISSION_TYPE_TRADE_MIN = 2                                       // ������� �� �������� �� ������ � ����� �� ������
	, QDAPI_COMMISSION_TYPE_COUNT
};

struct QDAPI_ClassListForCurrency {
	char currency[5];
	QDAPI_ArrayStrings lsClasses;
};
struct QDAPI_ArrayClassListForCurrency {
	size_t count;
	QDAPI_ClassListForCurrency* elems;
};

enum QDAPI_BrokCommType {
	QDAPI_BROK_COMM_TYPE_NO = 0                                                 // �� ������
	, QDAPI_BROK_COMM_TYPE_FIXED = 1                                            // ������������� �������� � % �� ������
	, QDAPI_BROK_COMM_TYPE_TURNOVER_SCALE = 2                                   // ����� �������� �� �������
	, QDAPI_BROK_COMM_TYPE_TRADE = 3                                            // �������� �� ������
	, QDAPI_BROK_COMM_TYPE_TRADE_FIXED_MAX = 4                                  // �������� ����� ��������� �� ������ � ������������� ��������� � % �� ������
	, QDAPI_BROK_COMM_TYPE_ONESEC = 5                                           // �������� �� ���� ������
	, QDAPI_BROK_COMM_TYPE_LOT = 6                                              // �������� �� ���� ���
	, QDAPI_BROK_COMM_TYPE_TRADE_LOT_MAX = 7                                    // �������� ����� ��������� �� ������ � ��������� �� ���� ������
	, QDAPI_BROK_COMM_TYPE_COUNT
};

// ��� �������� ��� �������, ����� ��� ��� ��� ������� �� ���������� �������� ��������
enum QDAPI_BrokCommTypeByClasses {
	QDAPI_BROK_COMM_TYPE_BY_CLASSES_NO = 0                                      // �� ������
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_FIXED = 1                                 // ������������� �������� � % �� ������
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE = 2                                 // �������� �� ������
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_FIXED_MAX = 3                       // �������� ����� ��������� �� ������ � ������������� ��������� � % �� ������
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_ONESEC = 4                                // �������� �� ���� ������
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_LOT = 5                                   // �������� �� ���� ���
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_LOT_MAX = 6                         // �������� ����� ��������� �� ������ � ��������� �� ���� ������
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_COUNT
};

struct QDAPI_CommissionTypeAndRate {
	QDAPI_BrokCommType commissionType;                                          // ��� �������
	char TPName[13] = {};                                                       // �������� ��������� �����
	double brokerCommissionRate = -1;                                           // ������ ������������� �������� � % �� ������
	double tradeCommissionRate = -1;                                            // ������ �������� �� ������ � �������� ��
	double tradeLotCommissionRate = -1;                                         // ������ �������� �� ���� ���
	double oneSecCommissionRate = -1;                                           // ������ �������� �� ������
	double repoBrokerRate = -1;                                                 // ������ �������� ���� % �� ������ �� ������ ����
};

struct QDAPI_ClassCommissionType {
	char classCode[13] = {};                                                    // ��� ������
	QDAPI_BrokCommTypeByClasses commissionType;                                 // ��� �������
	double rate1 = -1;                                                          // �������� ���������� �������� ��� ����� �������� FIXED, TRADE, TRADELOT, 1SEC. ��� �������� � ������� ��������� (TRADE_MAX � TRADE_MAX_1SEC) � �������� ���������� �������� �� ������.
	double rate2 = -1;                                                          // ������ ��� ����� �������� � ������� ���������: ��� TRADE_MAX � ������������� �������� ���������� ��������. ��� TRADE_MAX_1SEC � �������� ���������� �������� �� ������.
};

struct QDAPI_ArrayClassCommissionType {
	size_t count;
	QDAPI_ClassCommissionType* elems;
};

struct QDAPI_BaseAssetCommissionRate {
	char baseAsset[13];                                                         // ��� �������� ������
	double rate = -1;                                                           // ������ ��������
};

struct QDAPI_ArrayBaseAssetCommissionRate {
	size_t count;
	QDAPI_BaseAssetCommissionRate* elems;
};

struct QDAPI_ArrayOfStringArrays {
	size_t count;
	QDAPI_ArrayStrings* elems;
};

struct QDAPI_ScaleCommExParams {
	double minValue = 0;                                                        // ����������� �������� ���������� �������� �� ����
	double maxValue = 0;                                                        // ������������ �������� ���������� �������� �� ����
	double minTurnover = 0;                                                     // ����������� ������� ������, � �������� ����������� �������� �� �����
};

struct QDAPI_ScaleRate {
	double volume;                                                              // �����
	double rate;                                                                // ������ ��������
};

struct QDAPI_ArrayOfScaleRates {
	size_t count;
	QDAPI_ScaleRate* elems;
};

struct QDAPI_VolumeBasedCommissionRates {
	double volume;
	QDAPI_OperationSide side;
	QDAPI_CommissionType commissionType;
	double rate1;
	double rate2;
};
struct QDAPI_ArrayOfVolumeBasedCommissionRates {
	size_t count;
	QDAPI_VolumeBasedCommissionRates* elems;
};

struct QDAPI_GroupWithDependentPrices {
	char groupName[256];	//��� ���������
	char baseIndicator[13]; //������� ����������
};

struct  QDAPI_ArrayGroupsWithDependentPrices {
	size_t count;
	QDAPI_GroupWithDependentPrices* elems;
};

struct QDAPI_Instrument {
	char secCode[13]; // ������������ �����������
	double relativeRiskRate; //����
	int dependencyTrend; //�����
};

struct QDAPI_ArrayInstruments {
	size_t	count;
	QDAPI_Instrument* elems;
};

struct QDAPI_SecWithWeightAndRestrictions {
	char secCode[13];                                                           // ��� �����������
	double longCoeff;                                                           // �������������� ����������� ��� ������ ������� [0;1]
	double shortCoeff;                                                          // �������������� ����������� ��� �������� ������� [1;?]
	double longRestriction;                                                     // ����������� ������ ������� �� ����������� [0;?]
	double shortRestriction;                                                    // ����������� �������� ������� �� ����������� [0;?]
	double maxVariancePercent;                                                 // ������������ ������� ���������� �������� �������� ����-� �� ������� �������� ��� �������� ������� � �� �������� �������� ��� ��������  �������. [0;100?]
};

struct QDAPI_WeightAndRestrictionForSec { 
	double longCoeff;                                                           // �������������� ����������� ��� ������ ������� [0;1]
	double shortCoeff;                                                          // �������������� ����������� ��� �������� ������� [1;?]
	double longRestriction;                                                     // ����������� ������ ������� �� ����������� [0;?]
	double shortRestriction;                                                    // ����������� �������� ������� �� ����������� [0;?]
	double maxVariancePercent;                                                 // ������������ ������� ���������� �������� �������� ����-� �� ������� �������� ��� �������� ������� � �� �������� �������� ��� ��������  �������. [0;100?]
};

struct QDAPI_SecsWithWeightAndRestrictionsList {
	size_t  count;
	QDAPI_SecWithWeightAndRestrictions* elems;
};

struct QDAPI_SecWithVariance {
	char secCode[13];                                                           // ��� �����������
	double maxVariancePercent;                                                 // ������������ ������� ���������� �������� �������� ����-� �� ������� �������� ��� �������� ������� � �� �������� �������� ��� ��������  �������. [0;100?]
};

struct QDAPI_SecsWithVarianceList {
	size_t  count;
	QDAPI_SecWithVariance* elems;
};

struct QDAPI_SecWithRestrictions {
	char secCode[13];                                                           // ��� �����������
	double longRestriction;                                                     // ����������� ������ ������� �� ����������� [0;?]
	double shortRestriction;                                                    // ����������� �������� ������� �� ����������� [0;?]
};

struct QDAPI_SecsWithRestrictionsList {
	size_t  count;
	QDAPI_SecWithRestrictions* elems;
};

struct QDAPI_SecWithCoeffs {
	char secCode[13];                                                           // ��� �����������
	double longCoeff;                                                           // �������������� ����������� ��� ������ ������� [0;1]
	double shortCoeff;                                                          // �������������� ����������� ��� �������� ������� [1;?]
};

struct QDAPI_SecsWithCoeffsList {
	size_t  count;
	QDAPI_SecWithCoeffs* elems;
};

enum QDAPI_ClientLagType {
	QDAPI_LAG_BY_LIMIT = 1                                                      // �� ������
	, QDAPI_LAG_BY_LEVERAGE = 2                                                 // �� �����
	, QDAPI_LAG_LIMIT_ON_OPEN_POSITION = 3                                      // ����� �� �������� �������
	, QDAPI_LAG_BY_DISCOUNTS = 4                                                // �� ��������� 
	, QDAPI_LAG_MDPLUS = 5                                                      // ��+
	, QDAPI_LAG_COUNT
};

struct QDAPI_ClientLag {
	char clientCode[13];                                                        // ��� �������
	QDAPI_ClientLagType clientLag;                                              // ��� ������������
};

struct QDAPI_ArrayClientLag {
	size_t count = 0;
	QDAPI_ClientLag* elems;
};

struct QDAPI_ClientCodeToTrdAcc {
	char clientCode[13];                                                        // ��� �������
	char tradeAcc[13];                                                          // �������� ����
};

struct QDAPI_ArrayClientCodeToTrdAcc {
	size_t count;
	QDAPI_ClientCodeToTrdAcc* elems;
};


struct QDAPI_ProhibitedCPAndSettlementCurrency {
	char cP[13];                                                                // ��� �����������
	char settlementCurrency[5];                                                 // ��� ������ ��������
	QDAPI_ArrayStrings lsClassCodes;                                            // ������ �������
	QDAPI_ArrayStrings lsInstrumentCodes;                                       // ������ ������������
};

struct QDAPI_ArrayProhibitedCPAndSettlementCurrency {
	size_t count;
	QDAPI_ProhibitedCPAndSettlementCurrency* elems;
};

struct QDAPI_ProhibitedSettlementCurrency {
	char settlementCurrency[5];                                                 // ��� ������ ��������
	QDAPI_ArrayStrings lsClassCodes;                                            // ������ �������
	QDAPI_ArrayStrings lsInstrumentCodes;                                       // ������ ������������
};

struct QDAPI_ArrayProhibitedSettlementCurrency {
	size_t count;
	QDAPI_ProhibitedSettlementCurrency* elems;
};

struct QDAPI_RestrictREPOWithCPBasedOnTerm {
	char cP[13];                                                                // ��� �����������
	char settlementCurrency[5];                                                 // ��� ������ ��������
	char faceValueCurrency[5];                                                  // ��� ������ ��������
	QDAPI_ArrayStrings lsClassCodes;                                            // ������ �������
	int maxTerm;                                                                // ����������� ���� ����
};

struct QDAPI_ArrayRestrictREPOWithCPBasedOnTerm {
	size_t count;
	QDAPI_RestrictREPOWithCPBasedOnTerm* elems;
};

struct QDAPI_RestrictREPOBasedOnTerm {
	char settlementCurrency[5];                                                 // ��� ������ ��������
	char faceValueCurrency[5];                                                  // ��� ������ ��������
	QDAPI_ArrayStrings lsClassCodes;                                            // ������ �������
	int maxTerm;                                                                // ����������� ���� ����
};

struct QDAPI_ArrayRestrictREPOBasedOnTerm {
	size_t count;
	QDAPI_RestrictREPOBasedOnTerm* elems;
};

struct QDAPI_RestrictMaxValueForSettlementCurrency {
	char settlementCurrency[5];                                                 // ��� ������ ��������
	QDAPI_ArrayStrings lsClassCodes;                                            // ������ �������
	QDAPI_OperationSide side;                                                   // ����������� ��������
	double maxValue;                                                            // ������������ ��������
};

struct QDAPI_ArrayRestrictMaxValueForSettlementCurrency {
	size_t count;
	QDAPI_RestrictMaxValueForSettlementCurrency* elems;
};

struct QDAPI_RestrictMaxValue {
	QDAPI_ArrayStrings lsClassCodes;                                            // ������ �������
	QDAPI_OperationSide side;                                                   // ����������� ��������
	double maxValue;                                                            // ������������ ��������
};

struct QDAPI_ArrayRestrictMaxValue {
	size_t count;
	QDAPI_RestrictMaxValue* elems;
};

struct QDAPI_REPOBySideToTerm {
	bool isSideUsed = false;           // ������ �� ��� ������� �����������
	QDAPI_ArrayIntNumbers maxTerms;    // ������ ������������ ������ ����
};

struct  QDAPI_ProhibitREPOByFirstPartSideAndTerm {
	char secCode[13];
	QDAPI_REPOBySideToTerm TermByAny;
	QDAPI_REPOBySideToTerm TermByBuy;
	QDAPI_REPOBySideToTerm TermBySell;
};

struct QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm {
	size_t count;
	QDAPI_ProhibitREPOByFirstPartSideAndTerm* elems;
};

struct QDAPI_ClassGroupWithScale {
	QDAPI_ArrayStrings lsClassCodes;        // ������ �������
	QDAPI_ScaleCommExParams scaleParams;    // minValue, maxValue, MinVolume
	QDAPI_ArrayOfScaleRates scaleRates;     // ����� ��������
};

struct QDAPI_ArrayClassGroups {
	size_t count;
	QDAPI_ClassGroupWithScale* elems;
};

struct QDAPI_ComplexInstruments {
	char complexityType[13];                                                    // ��� ��������� 
	QDAPI_ArrayStrings lsClasses;                                               // ������ �������
	QDAPI_ArrayStrings lsInstruments;                                           // ������ ������������
};

struct QDAPI_ArrayComplexInstruments {
	size_t count;
	QDAPI_ComplexInstruments* elems;
};

struct QDAPI_ClientFIApproves {
	char clientCode[13];                                                        // ��� �������
	QDAPI_ArrayStrings lsApproves;                                              // ����� ����������
};
struct QDAPI_ArrayClientFIApproves {
	size_t count;
	QDAPI_ClientFIApproves* elems;
};
#pragma pack(pop)

// ���������� ��������� ���������� � �������� QA
// � ������ ������ ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_Connect(
		const char* lpszIniFile                                                 // (in) ���� ��������
		, const char* lpszUserName                                              // (in) �����
		, const char* lpszUserPassword                                          // (in) ������
		, char** lpszError );                                                   // (out) ��������� �� ������, � ������� ��������� ����� ���������

// ��������� ������ � ��������� ����������
QDEALERAPI_API int _stdcall QDAPI_Disconnect();

// ��������� ������ ����, �� ������� ������� ��������� ���
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_DLGetFirmList(
	    QDAPI_ArrayStrings** ppFirmCodes );                                     // (out) ������ ����� ���� ��������� ���������, � ������� ��������� ����� ���������

// ������ ������ � ����������� ���
QDEALERAPI_API int _stdcall QDAPI_DLOpenFile(
		const char* lpszFirmCode                                                // (in) ��� �����
		, int nMode );                                                          // ����� �������� �����; 0 - ������/������, 1 - ������ ������

// ���������� ��������� ��������
QDEALERAPI_API int _stdcall QDAPI_DLUpdateFile(
		const char* lpszFirmCode );                                             // (in) ��� �����

// �������� ����� �������� ��� ��� ���������� ���������
QDEALERAPI_API int _stdcall QDAPI_DLCloseFile(
		const char* lpszFirmCode );                                             // (in) ��� �����

// ������������ ������
QDEALERAPI_API int _stdcall QDAPI_FreeMemory(
		void** pMem );                                                          // (in-out) ����� ��������� �� ������������� ������� ������

//ClientTemplate
#pragma region //======================== AllowedPartnersAndSettleCodes =======================
// ���������� ��������� "���� ������� ����/���" � "���� �����������" � ��������� �� �����
// � ������ ������������� ���������� ������ "���� ������� ����/���", �������� "��� �����������" ������� ��� NULL ��� ""
// � ������ ������������� ���������� ������ "���� �����������", �������� "��� ������� ����/���" ������� ��� NULL ��� ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode );                                             // (in) ��� ������� ����/���
, "'QDAPI_AddItemToGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode );                                             // (in) ��� ������� ����/���
, "'QDAPI_AddItemToClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToClientSettingsAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode );                                             // (in) ��� ������� ����/���
, "'QDAPI_AddItemToClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToClientTemplateAllowedPartnersAndSettleCodes'. ");

// ��������� "������ ����� �������� ����/���" � "������ ����� ������������" �� �������� �� �����
// � ������ ������������� ��������� ������ "������ ����� �������� ����/���", �������� "������ ����� ������������" ������� ��� NULL
// � ������ ������������� ��������� ������ "������ ����� ������������", �������� "������ ����� �������� ����/���" ������� ��� NULL
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) ������ ����� ������������, � ������� ��������� ����� ���������
	, QDAPI_ArrayStrings** lsSettleCodes );                                 // (out) ������ ����� �������� ����/���, � ������� ��������� ����� ���������
, "'QDAPI_GetItemFromGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) ������ ����� ������������, � ������� ��������� ����� ���������
	, QDAPI_ArrayStrings** lsSettleCodes );                                 // (out) ������ ����� �������� ����/���, � ������� ��������� ����� ���������
, "'QDAPI_GetItemFromClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromClientSettingsAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) ������ ����� ������������, � ������� ��������� ����� ���������
	, QDAPI_ArrayStrings** lsSettleCodes );                                 // (out) ������ ����� �������� ����/���, � ������� ��������� ����� ���������
, "'QDAPI_GetItemFromClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromClientTemplateAllowedPartnersAndSettleCodes'. ");

// �������� ��������� "���� ������� ����/���" � "���� �����������" �� �������� �� �����
// � ������ ���������� ������������� �������� "���� ������� ����/���" ��� "���� �����������" ��������������� �������� ������� ��� NULL ��� ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode );                                             // (in) ��� ������� ����/���
, "'QDAPI_RemoveItemFromGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode );                                             // (in) ��� ������� ����/���
, "'QDAPI_RemoveItemFromClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromClientSettingsAllowedPartnersAndSettleCodes'. ");


DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode );                                             // (in) ��� ������� ����/���
, "'QDAPI_RemoveItemFromClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromClientTemplateAllowedPartnersAndSettleCodes'. ");

// ��������� "������ ����� �������� ����/���" � "������ ����� ������������" � ��������� �� �����
// � ������ ���������� ������������� ��������� "������ ����� �������� ����/���" ��� "������ ����� ������������",
// � ����������� ������� ������ ����������, ��������������� �������� ������� ��� NULL
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) ������ ����� ������������
	, const QDAPI_ArrayStrings* lsSettleCodes );                            // (in) ������ ����� �������� ����/���
, "'QDAPI_SetItemToGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) ������ ����� ������������
	, const QDAPI_ArrayStrings* lsSettleCodes );                            // (in) ������ ����� �������� ����/���
, "'QDAPI_SetItemToClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToClientSettingsAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) ������ ����� ������������
	, const QDAPI_ArrayStrings* lsSettleCodes );                            // (in) ������ ����� �������� ����/���
, "'QDAPI_SetItemToClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToClientTemplateAllowedPartnersAndSettleCodes'. ");
#pragma endregion
#pragma region //================================ PriceLimit ==================================
// ����������� �� ���� ������ (�� �������)
QDEALERAPI_API int _stdcall QDAPI_AddClassSettingsToGlobalPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, double deviationPercent                                               // (in) ���������� ���� � ���������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_AddClassSettingsToClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, double deviationPercent                                               // (in) ���������� ���� � ���������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_AddClassSettingsToClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, double deviationPercent                                               // (in) ���������� ���� � ���������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����

QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromGlobalPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_PriceType* priceType);                                          // (out) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, QDAPI_PriceType* priceType);                                          // (out) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_PriceType* priceType);                                          // (out) ������������� ���� ����

// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromGlobalPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) ������ �������� �� ���� �������, � ������� ��������� ����� ���������
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) ������ �������� �� ���� �������, � ������� ��������� ����� ���������
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) ������ �������� �� ���� �������, � ������� ��������� ����� ���������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromGlobalPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode);                                               // (in) ��� ������
QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode);                                               // (in) ��� ������
QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode);                                               // (in) ��� ������

QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToGlobalPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingListToGlobalPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) ������ �������� �� ���� �������
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) ������ �������� �� ���� �������
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) ������ �������� �� ���� �������
#pragma endregion
#pragma region //=============================== ClientTemplate ===============================
// ���������� ������ ���� ������� � ���������� ������
QDEALERAPI_API int _stdcall QDAPI_AddClientToClientTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, const char* clientCode );                                             // (in) ��� �������

// ��������� ������� ������ �������� � ���������� �������
// ���� �������� ����������� �����������������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientsListOfClientTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, QDAPI_ArrayStrings** lsClientCodes );                                 // (out) ������ ����� ��������, � ������� ��������� ����� ���������

// ����������� ������ ���� ������� �� ����������� ������� � ������ ���������� ������
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenClientTemplates(
		const char* firmCode                                                    // (in) ��� �����
		, const char* fromTemplateCode                                          // (in) �������� �������, �� �������� �������� ������
		, const char* toTemplateCode                                            // (in) �������� �������, � ������� ����������� ������
		, const char* clientCode );                                             // (in) ��� �������

// �������� ������ ���� ������� �� ����������� �������
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromClientTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, const char* clientCode );                                             // (in) ��� �������

// ��������� ������� ������ �������� � ���������� �������
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfClientTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, const QDAPI_ArrayStrings* lsClientCodes );                            // (in) ������ ����� ��������
#pragma endregion
#pragma region //====================== ProhibitedPartnersAndSettleCodes ======================
// ���������� ��������� "���� ������� ����/���" � "���� �����������" � ��������� �� �����
// � ������ ������������� ���������� ������ "���� ������� ����/���", �������� "��� �����������" ������� ��� NULL ��� ""
// � ������ ������������� ���������� ������ "���� �����������", �������� "��� ������� ����/���" ������� ��� NULL ��� ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode);                                              // (in) ��� ������� ����/���
, "'QDAPI_AddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToGlobalProhibitedPartnersAndSettleCodes'.");

QDEALERAPI_API int _stdcall QDAPI_AddPartnerAndSettleCodeToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode);                                              // (in) ��� ������� ����/���

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddPartnerAndSettleCodeToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode);                                              // (in) ��� ������� ����/���
, "'QDAPI_AddPartnerAndSettleCodeToClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToClientTemplateProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* classCode, const char* partnerCode, const char* settleCode);
, "'QDAPI_AddItemToGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AAddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* clientCode, const char* classCode, const char* partnerCode, const char* settleCode);
, "'QDAPI_AddItemToClientSettingsProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToClientSettingsProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* templateCode, const char* classCode, const char* partnerCode, const char* settleCode);
, "'QDAPI_AddItemToClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddPartnerAndSettleCodeToClientTemplateProhibitedPartnersAndSettleCodes'.");

// ��������� "������ ����� �������� ����/���" � "������ ����� ������������" �� �������� �� �����
// � ������ ������������� ��������� ������ "������ ����� �������� ����/���", �������� "������ ����� ������������" ������� ��� NULL
// � ������ ������������� ��������� ������ "������ ����� ������������", �������� "������ ����� �������� ����/���" ������� ��� NULL
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) ������ ����� ������������, � ������� ��������� ����� ���������
	, QDAPI_ArrayStrings** lsSettleCodes);                                  // (out) ������ ����� �������� ����/���, � ������� ��������� ����� ���������
, "'QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromGlobalProhibitedPartnersAndSettleCodes'.");
QDEALERAPI_API int _stdcall QDAPI_GetPartnerAndSettleCodeListFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) ������ ����� ������������, � ������� ��������� ����� ���������
	, QDAPI_ArrayStrings** lsSettleCodes);                                  // (out) ������ ����� �������� ����/���, � ������� ��������� ����� ���������
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetPartnerAndSettleCodeListFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) ������ ����� ������������, � ������� ��������� ����� ���������
	, QDAPI_ArrayStrings** lsSettleCodes);                                  // (out) ������ ����� �������� ����/���, � ������� ��������� ����� ���������
, "'QDAPI_GetPartnerAndSettleCodeListFromClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromClientTemplateProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* classCode, QDAPI_ArrayStrings** lsPartnerCodes, QDAPI_ArrayStrings** lsSettleCodes);
, "'QDAPI_GetItemFromGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* clientCode, const char* classCode, QDAPI_ArrayStrings** lsPartnerCodes, QDAPI_ArrayStrings** lsSettleCodes);
, "'QDAPI_GetItemFromClientSettingsProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromClientSettingsProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* templateCode, const char* classCode, QDAPI_ArrayStrings** lsPartnerCodes, QDAPI_ArrayStrings** lsSettleCodes);
, "'QDAPI_GetItemFromClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetPartnerAndSettleCodeListFromClientTemplateProhibitedPartnersAndSettleCodes'.");

// �������� ��������� "���� ������� ����/���" � "���� �����������" �� �������� �� �����
// � ������ ���������� ������������� �������� "���� ������� ����/���" ��� "���� �����������" ��������������� �������� ������� ��� NULL ��� ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode);                                              // (in) ��� ������� ����/���
, "'QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromGlobalProhibitedPartnersAndSettleCodes'.");

QDEALERAPI_API int _stdcall QDAPI_RemovePartnerAndSettleCodeFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode);                                              // (in) ��� ������� ����/���

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemovePartnerAndSettleCodeFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* partnerCode                                               // (in) ��� �����������
	, const char* settleCode);                                              // (in) ��� ������� ����/���
, "'QDAPI_RemovePartnerAndSettleCodeFromClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromClientTemplateProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* classCode, const char* partnerCode, const char* settleCode);
, "'QDAPI_RemoveItemFromGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* clientCode, const char* classCode, const char* partnerCode, const char* settleCode);
, "'QDAPI_RemoveItemFromClientSettingsProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromClientSettingsProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* templateCode, const char* classCode, const char* partnerCode, const char* settleCode);
, "'QDAPI_RemoveItemFromClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemovePartnerAndSettleCodeFromClientTemplateProhibitedPartnersAndSettleCodes'.");

// ��������� "������ ����� �������� ����/���" � "������ ����� ������������" � ��������� �� �����
// � ������ ���������� ������������� ��������� "������ ����� �������� ����/���" ��� "������ ����� ������������",
// � ����������� ������� ������ ����������, ��������������� �������� ������� ��� NULL
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) ������ ����� ������������
	, const QDAPI_ArrayStrings* lsSettleCodes);                             // (in) ������ ����� �������� ����/���
, "'QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToGlobalProhibitedPartnersAndSettleCodes'.");

QDEALERAPI_API int _stdcall QDAPI_SetPartnerAndSettleCodeListToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) ������ ����� ������������
	, const QDAPI_ArrayStrings* lsSettleCodes);                             // (in) ������ ����� �������� ����/���

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetPartnerAndSettleCodeListToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) ������ ����� ������������
	, const QDAPI_ArrayStrings* lsSettleCodes);                             // (in) ������ ����� �������� ����/���
, "'QDAPI_SetPartnerAndSettleCodeListToClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToClientTemplateProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* classCode, const QDAPI_ArrayStrings* lsPartnerCodes, const QDAPI_ArrayStrings* lsSettleCodes);
, "'QDAPI_SetItemToGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* clientCode, const char* classCode, const QDAPI_ArrayStrings* lsPartnerCodes, const QDAPI_ArrayStrings* lsSettleCodes);
, "'QDAPI_SetItemToClientSettingsProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToClientSettingsProhibitedPartnersAndSettleCodes'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode, const char* templateCode, const char* classCode, const QDAPI_ArrayStrings* lsPartnerCodes, const QDAPI_ArrayStrings* lsSettleCodes);
, "'QDAPI_SetItemToClientTemplateProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetPartnerAndSettleCodeListToClientTemplateProhibitedPartnersAndSettleCodes'.");
#pragma endregion
#pragma region //=============================== SecPriceLimit ================================
// ����������� �� ���� ������ (�� ������������)
QDEALERAPI_API int _stdcall QDAPI_AddSecuritySettingsToGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, double deviationPercent                                               // (in) ���������� ���� � ���������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_AddSecuritySettingsToClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* secCode                                                   // (in) ��� �����������
	, double deviationPercent                                               // (in) ���������� ���� � ���������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_AddSecuritySettingsToClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, double deviationPercent                                               // (in) ���������� ���� � ���������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����

QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_PriceType* priceType);                                          // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, QDAPI_PriceType* priceType);                                          // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_PriceType* priceType);                                          // (in) ������������� ���� ����

// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) ������ �������� �� ���� ������������, � ������� ��������� ����� ���������
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) ������ �������� �� ���� ������������, � ������� ��������� ����� ���������
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) ������ �������� �� ���� ������������, � ������� ��������� ����� ���������

QDEALERAPI_API int _stdcall QDAPI_RemoveSecuritySettingsFromGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode);                                                 // (in) ��� �����������
QDEALERAPI_API int _stdcall QDAPI_RemoveSecuritySettingsFromClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const char* secCode);                                                 // (in) ��� �����������
QDEALERAPI_API int _stdcall QDAPI_RemoveSecuritySettingsFromClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode);                                                 // (in) ��� �����������

QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_PriceType priceType);                                           // (in) ������������� ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingListToGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) ������ �������� �� ���� �������
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� �������
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) ������ �������� �� ���� �������
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) ������ �������� �� ���� �������
#pragma endregion
//PGO
#pragma region //============================== ������ [General] ==============================
// ���������� �������� ���������� ��������� UsePGO
QDEALERAPI_API int _stdcall QDAPI_GetUsePGOFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int* usePGO);                                                         // (out) �������� ���������

// ���������� �������� �������������� ��������� UsePGO �� ��� �������
QDEALERAPI_API int _stdcall QDAPI_GetUsePGOFromClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int* usePGO);                                                         // (out) �������� ���������

// ���������� �������� ��������� UsePGO � ������������ �������
QDEALERAPI_API int _stdcall QDAPI_GetUsePGOFromMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� �������
	, int* usePGO);                                                         // (out) �������� ���������

// ������������� �������� ���������� ��������� UsePGO
QDEALERAPI_API int _stdcall QDAPI_SetUsePGOToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int usePGO);                                                          // (in) �������� ���������

// ������������� �������� �������������� ��������� UsePGO �� ��� �������
QDEALERAPI_API int _stdcall QDAPI_SetUsePGOToClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int usePGO);                                                          // (in) �������� ���������

// ������������� �������� ���������� ��������� UsePGO � ������������ �������
QDEALERAPI_API int _stdcall QDAPI_SetUsePGOToMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� �������
	, int usePGO);                                                          // (in) �������� ���������

#pragma endregion
#pragma region //============================= ������ [BaseAssets] ============================
// ���������� ������ ������� �������, ��� ������� ������ ������������
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsListFromBaseAssetsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsBaseAssets);                                   // (out) ������ ������� �������

// ���������� ��������� ��� ���������� �������� ������
QDEALERAPI_API int _stdcall QDAPI_GetSpotListForBaseAssetFromBaseAssetsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, QDAPI_ArraySpotListForBaseAsset** lsSpotCodes);                       // (out) ������ ����-�������

// ������������� (�������������� ��� �������) ��������� ��� ���������� �������� ������
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToBaseAssetsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, const QDAPI_ArraySpotListForBaseAsset* lsSpotCodes);                  // (in) ������

#pragma endregion
#pragma region //================= ������ [BaseAssets_Template_<TemplateName>] ================
// ��������� ������ ���� �������� �������� ������������ ������� �������
QDEALERAPI_API int _stdcall QDAPI_GetListOfBaseAssetsTemplates(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsBaseAssetsTemplateCodes);                      // (out) ������ ������������ ��������

// ���������� (��������) ������� �������� ������������ ������� �������. ���� ��������� ������ ��� ���������� � ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_AddBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) �������� �������

// �������� ������� �������� ������������ ������� �������
QDEALERAPI_API int _stdcall QDAPI_RemoveBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) �������� �������

// ���������� ������� � ������
QDEALERAPI_API int _stdcall QDAPI_AddClientToBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* clientCode);                                              // (in) ��� �������

// ��������� ������ �������� � �������
QDEALERAPI_API int _stdcall QDAPI_GetClientsListFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_ArrayStrings** lsClientCodes);                                  // (out) ������ ����� ��������

// ����������� ������� ����� ���������
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenBaseAssetsTemplates(
	const char* firmCode                                                    // (in) ��� �����
	, const char* fromTemplateCode                                          // (in) �������� �������, �� �������� �������� ������
	, const char* toTemplateCode                                            // (in) �������� �������, � ������� ����������� ������
	, const char* clientCode);                                              // (in) ��� �������

// �������� ������� �� �������
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* clientCode);                                              // (in) ��� �������

// ������� (���������) ������ �������� � �������
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const QDAPI_ArrayStrings* lsClientCodes);                             // (in) ������ ����� ��������

// ���������� ������ ������� ������� ����������� �������
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsListFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayStrings** lsBaseAssets);                                   // (out) ������ ������� �������

// ���������� ��������� ��� ���������� �������� ������ � ���������� �������
QDEALERAPI_API int _stdcall QDAPI_GetSpotListForBaseAssetFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ������������ �������
	, const char* baseAsset                                                 // (in) ������� �����
	, QDAPI_ArraySpotListForBaseAsset** lsSpotCodes);                       // (out) ������ ����-�������

// ������������� (�������������� ��� �������) ��������� ��� ���������� �������� ������ � ���������� �������
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToBaseAssetsTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ������������ �������
	, const char* baseAsset                                                 // (in) ������� �����
	, const QDAPI_ArraySpotListForBaseAsset* lsSpotCodes);                  // (in) ������ ������������

#pragma endregion
#pragma region //======================== ������ [PortfolioRiskConfig] ========================
// ���������� �������� ���� �������� ������
QDEALERAPI_API int _stdcall QDAPI_GetMainSettingsFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_MainSettingsOfPortfolioRiskConfigGlobal** settings);            // (out) ������ ��������

// ������ �������� �������� ������, � ����� ��������� ������� ����� �� �������� ����� ������� ���������������� �������� ����� ��������� ��� ������������ �����
QDEALERAPI_API int _stdcall QDAPI_SetMainSettingsToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const QDAPI_MainSettingsOfPortfolioRiskConfigGlobal* settings);       // (in) ������ ��������

// ���������� �������� ��������� ��������� �����
QDEALERAPI_API int _stdcall QDAPI_GetSpreadTiersFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayOfSpreadTiers** lsTiers);                                  // (out) ������ ����������������� �����

// ������ ��������� ��������� �����
QDEALERAPI_API int _stdcall QDAPI_SetSpreadTiersToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const QDAPI_ArrayOfSpreadTiers* lsTiers);                             // (in) ������ ����������������� �����

// ���������� �������� ���� �������� ������
QDEALERAPI_API int _stdcall QDAPI_GetCommonSettingsFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) ����� ��������� ���

// ������ ����� �������� �������� ������
QDEALERAPI_API int _stdcall QDAPI_SetCommonSettingsToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) ����� ��������� ���

// ���������� ������ ������, ��� ������� ������ ���� �� ���� �������������� ���������
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccListFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsTrdAccs);                                      // (out) ������ ������, ��� ������� ������ ���� �� ���� �������������� ���������

// ���������� �������� ���� �������� ������, �������� �� �������� ����. ���� ��������� ����������� � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_GetIndividualSettingsFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* tradingAccount                                            // (in) �������� ����
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) ��������� ��� �� �������� ����

// ������ �������� �������� ������ �� �������� ����. ��� ������� ������ �������� � ������������� ������ � ����� ������ ���������
QDEALERAPI_API int _stdcall QDAPI_SetIndividualSettingsToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* tradingAccount                                            // (in) �������� ����
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) ��������� ��� �� �������� ����

#pragma endregion
#pragma region //================== ������ [PortfolioRiskConfig_<BaseAsset>] ==================
// ���������� ������ ������� �������, ��� ������� ������ ������ �������� �� ������� �����. ��������� ������ � ������� �� ��������
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsListWithPortfolioRiskConfigOnBaseAssetSection(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsBaseAssets);                                   // (out) ������ ������� �������, ��� ������� ������ ������ � ��������� ����� �������� ������

// ��������� ������ � ��������� ����������� �������� ������. ���� ��������� ������ ��� ���������� � ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_AddPortfolioRiskConfigOnBaseAssetSection(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset);                                               // (in) ������� �����;

// ������� ������, �������� �� ���������� ������� �����. ���������� ������, ��� ��� ������ ������ �� ������� �����. ��� �������� �������� ������, ��� �������� ��� ������, ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_RemovePortfolioRiskConfigOnBaseAssetSection(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset);                                               // (in) ������� �����;

// ���������� ������ �������������� ������� �������
QDEALERAPI_API int _stdcall QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, QDAPI_ArrayStrings** lsAdditionalBaseAssets);                         // (out) ������ �������������� ������� �������

// ������ ������ �������������� ������� �������, � ����� ��������� ������� ���������
QDEALERAPI_API int _stdcall QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, const QDAPI_ArrayStrings* lsAdditionalBaseAssets);                    // (in) ������ �������������� ������� �������

// ���������� �������� ��������� ��������� �����
QDEALERAPI_API int _stdcall QDAPI_GetSpreadTiersFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, QDAPI_ArrayOfSpreadTiers** lsTiers);                                  // (out) ������ ����������������� �����

// ������ ��������� ��������� ����� (�.�. �������).
QDEALERAPI_API int _stdcall QDAPI_SetSpreadTiersToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, const QDAPI_ArrayOfSpreadTiers* lsTiers);                             // (in) ������ ����������������� �����

// ���������� �������� ���� �������� ������
QDEALERAPI_API int _stdcall QDAPI_GetCommonSettingsFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) ����� ��������� ���

// ������ �������� �������� ������, � ����� ��������� ������� ���������
QDEALERAPI_API int _stdcall QDAPI_SetCommonSettingsToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) ����� ��������� ���

// ���������� ������ ������, ��� ������� ������ ���� �� ���� �������������� ���������
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccListFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, QDAPI_ArrayStrings** lsTrdAccs);                                      // (out) ������ ������, ��� ������� ������ ���� �� ���� �������������� ���������

// ���������� �������� ���� �������� ������, �������� �� �������� ����. ���� ��������� ����������� (�� ������ � ����������� ������ �������) � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_GetIndividualSettingsFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, const char* tradingAccount                                            // (in) �������� ����
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) ��������� ��� �� �������� ����

// ������ �������� �������� ������ �� �������� ����
QDEALERAPI_API int _stdcall QDAPI_SetIndividualSettingsToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) ��� �����
	, const char* baseAsset                                                 // (in) ������� �����
	, const char* tradingAccount                                            // (in) �������� ����
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) ��������� ��� �� �������� ����

#pragma endregion
#pragma region //================= ������ [PortfolioRiskConfig_<TemplateName>] ================
// ���������� ������ ���������� ��������� ������ �������� ��� (� ���� ��������� ��� ���� ������� � ��� �������� ������ MainAsset�). ������ �� ������� ����� � ������� �� ��������
QDEALERAPI_API int _stdcall QDAPI_GetPortfolioRiskConfigTemplatesList(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayPortfolioRiskConfigTemplateIdentifier** lsTemplates);      // (out) ������ �������� �������� ���

// ��������� (�������) ��������� ������ �������� ���. ���������� ������, ��� ��� ������ ��������� ������, � �� ������  �� ������� �����. ���� ��������� ��������� ������ ��� ���������� � ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_AddPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const QDAPI_PortfolioRiskConfigTemplateIdentifier* templateId);       // (in) ������;

// ������� ��������� ������ �������� ���. ���������� ������, ��� ��� ������ ��������� ������, � �� ������  �� ������� �����
QDEALERAPI_API int _stdcall QDAPI_RemovePortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName);                                            // (in) ������;

// ���������� ������� � ������
QDEALERAPI_API int _stdcall QDAPI_AddClientToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char*	templateName                                            // (in) ������;
	, const char* clientCode);                                              // (in) ��� �������

// ��������� ������ �������� � �������
QDEALERAPI_API int _stdcall QDAPI_GetClientsListFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, QDAPI_ArrayStrings** lsClientCodes);                                  // (out) ������ ����� ��������

// ����������� ������� ����� ���������
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenPortfolioRiskConfigTemplates(
	const char* firmCode                                                    // (in) ��� �����
	, const char* fromTemplate                                              // (in) ������, �� �������� �������� ������
	, const char* toTemplate                                                // (in) ������, � ������� ����������� ������
	, const char* clientCode);                                              // (in) ��� �������

// �������� ������� �� �������
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, const char* clientCode);                                              // (in) ��� �������

// ������� (���������) ������ �������� � �������
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, const QDAPI_ArrayStrings* lsClientCodes);                             // (in) ������ ����� ��������

// ���������� ���, �� ������� ����������� �������� �������� �������
QDEALERAPI_API int _stdcall QDAPI_GetBoardTagFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, char** tag);                                                          // (out) ���

// ������������� (� ����� �������������� ��� �������) �������� ����, �� ������� ����������� �������� �������� �������
QDEALERAPI_API int _stdcall QDAPI_SetBoardTagToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, const char* tag);                                                     // (in) ���

// ������������� (��������������) ������� ����� �������. ���� � ���������� ��������� �������� ������ ���������� ������������ ������������� ������� � ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_SetMainAssetToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, const char* baseAsset);                                               // (in) ������� �����

// ���������� ������ �������������� ������� �������
QDEALERAPI_API int _stdcall QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, QDAPI_ArrayStrings** lsAdditionalBaseAssets);                         // (out) ������ �������������� ������� �������

// ������ ������ �������������� ������� �������, � ����� ��������� ������� ���������
QDEALERAPI_API int _stdcall QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, const QDAPI_ArrayStrings* lsAdditionalBaseAssets);                    // (in) ������ �������������� ������� �������

// ���������� �������� ��������� ��������� �����
QDEALERAPI_API int _stdcall QDAPI_GetSpreadTiersFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, QDAPI_ArrayOfSpreadTiers** lsTiers);                                  // (out) ������ ����������������� �����

// ������ ��������� ��������� �����, � ����� ��������� ������� ���������
QDEALERAPI_API int _stdcall QDAPI_SetSpreadTiersToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, const QDAPI_ArrayOfSpreadTiers* lsTiers);                             // (in) ������ ����������������� �����

// ���������� �������� ���� �������� ������
QDEALERAPI_API int _stdcall QDAPI_GetCommonSettingsFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) ����� ��������� ���

// ������ �������� �������� ������, � ����� ��������� ������� ���������
QDEALERAPI_API int _stdcall QDAPI_SetCommonSettingsToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������;
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) ����� ��������� ���

// ���������� ������ ������, ��� ������� ������ ���� �� ���� �������������� ���������. ������ � �������� ������ � ������� �� �������������
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccListFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������
	, QDAPI_ArrayStrings** lsTrdAccs);                                      // (out) ������ ������, ��� ������� ������ ���� �� ���� �������������� ���������

// ���������� �������� ���� �������� ������, �������� �� �������� ����. ���� ��������� ����������� (�� ������ � ����������� ������ �������) � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_GetIndividualSettingsFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������
	, const char* tradingAccount                                            // (in) �������� ����
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) ��������� ��� �� �������� ����

// ������ �������� �������� ������ �� �������� ����, � ����� ��������� ������� ����� ���������
QDEALERAPI_API int _stdcall QDAPI_SetIndividualSettingsToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������
	, const char* tradingAccount                                            // (in) �������� ����
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) ��������� ��� �� �������� ����

#pragma endregion
#pragma region //======================== ������ [PortfolioSpreadOrder] =======================
// ���������� ��� ��������� ������������������ ���������� �������������� �������
QDEALERAPI_API int _stdcall QDAPI_GetSettingsListFromPortfolioSpreadOrder(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayBaseAssetsSpreadOrder** lsSpreadOrderSettings);            // (out) ������ ��������

// ������(�������������� ��� �������) �������� ��� ���� ������� �������. ��� ������� ������ �������� � ������������� ������ � ����� ������ ���������
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToPortfolioSpreadOrder(
	const char* firmCode                                                    // (in) ��� �����
	, const QDAPI_BaseAssetsSpreadOrder* lsSpreadOrderSettings);            // (in) ������ ������������

#pragma endregion
//Global
#pragma region //================= Global -> General -> AddSubClientDelimiter  ================
QDEALERAPI_API int _stdcall QDAPI_GetAdditionalSubClientDelimiterFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, char* value);                                                         // (out) �������� ���������

QDEALERAPI_API int _stdcall QDAPI_SetAdditionalSubClientDelimiterToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, char newValue);                                                       // (in) ����� �������� ���������
#pragma endregion
#pragma region //===================== Global -> General -> SecPricePrior =====================
QDEALERAPI_API int _stdcall QDAPI_GetSecPricePriorityFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int* secPricePriority);                                               // (out) �������� ���������

QDEALERAPI_API int _stdcall QDAPI_SetSecPricePriorityToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int secPricePriority);                                                // (int) ����� �������� ���������
#pragma endregion
#pragma region //============================ ChangeFutClientCodes ============================
// ���� �������� �������� �����->������������� ����� �������� �����
// ���� ���� ��������������� �����������������.
// ���� �������� �������� �����->������������ ���������� �����
// ������������ "��� �������"->"�������� ���� �� ������� �����" ��������������� ����������������� �� ���� �������.
// [ChangeFutClientCodes_FirmCode]
// <��� ������� 1> = <�������� ���� 1>
// <��� ������� 2> = <�������� ���� 2>
// ...
// <��� ������� N> = <�������� ���� N>

// �������� ������ ���� �������� �����
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetListOfFirmsGlobalChangeFutClientCodes(
		const char* firmCode                                                    // (in) ��� �����
		, QDAPI_ArrayStrings** lsFirmCodesOnDerivMarket );                      // (out) ������ ����� ���� �� ������� �����, � ������� ��������� ����� ���������

// �������� ���� ������������ ���������� ����� ��� �������� ����� �������� �����
QDEALERAPI_API int _stdcall QDAPI_AddCorrespToGlobalChangeFutClientCodes(
		const char* firmCode                                                    // (in) ��� �����
		, const char* firmCodeOnDerivMarket                                     // (in) ��� ����� �� ������� �����
		, const QDAPI_StringToString* clientCodeToTrdAcc );                     // (in) ���� {��� �������, �������� ���� �� ������� �����}

// �������� ��� ������� �� �������� ����� �������� ����� � ��������� �����
// ������������ ��������: ��������� �� ��� �������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientCodeGlobalChangeFutClientCodesByTrdAcc(
		const char* firmCode                                                    // (in) ��� �����
		, const char* firmCodeOnDerivMarket                                     // (in) ��� ����� �� ������� �����
		, const char* trdAcc                                                    // (in) �������� ���� �� ������� �����
		, char** clientCode );                                                  // (out) ��� �������, � ������� ��������� ����� ���������

// �������� �������� ���� �� ������� ����� �� �������� ����� �������� ����� � ���� �������
// ������������ ��������: ��������� �� �������� ����
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccGlobalChangeFutClientCodesByClientCode(
		const char* firmCode                                                    // (in) ��� �����
		, const char* firmCodeOnDerivMarket                                     // (in) ��� ����� �� ������� �����
		, const char* clientCode                                                // (in) ��� �������
		, char** trdAcc );                                                      // (out) �������� ���� �� ������� �����, � ������� ��������� ����� ���������

// ������� ��� ������������ ���������� ����� ��� �������� ����� �������� �����
QDEALERAPI_API int _stdcall QDAPI_RemoveAllCorrespsFromGlobalChangeFutClientCodes(
		const char* firmCode                                                    // (in) ��� �����
		, const char* firmCodeOnDerivMarket );                                  // (in) ��� ����� �� ������� �����

// ������� ���� ������������ ���������� ����� �� �������� ����� �������� ����� � ���� �������
QDEALERAPI_API int _stdcall QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByClientCode(
		const char* firmCode                                                    // (in) ��� �����
		, const char* firmCodeOnDerivMarket                                     // (in) ��� ����� �� ������� �����
		, const char* clientCode );                                             // (in) ��� �������

// ������� ���� ������������ ���������� ����� �� �������� ����� �������� ����� � ��������� �����
QDEALERAPI_API int _stdcall QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByTrdAcc(
		const char* firmCode                                                    // (in) ��� �����
		, const char* firmCodeOnDerivMarket                                     // (in) ��� ����� �� ������� �����
		, const char* trdAcc );                                                 // (in) �������� ���� �� ������� �����
#pragma endregion
#pragma region //============================ GlobalProhibedTrdAcc ============================
// ������ ���������->�������� �����, ����������� ��� �������� ��������
// �������� ����� ��������������� �����������������.
// [GlobalProhibedTrdAcc]
// GlobalProhibedTrdAcc = <�������� ���� 1>, <�������� ���� 2>, ..., <�������� ���� N>

// �������� �������� ���� � "�������� ������, ����������� ��� �������� ��������"
QDEALERAPI_API int _stdcall QDAPI_AddTrdAccToGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) ��� �����
		, const char* tradeAccount );                                           // (in) �������� ����

// �������� ������ �������� ������, ����������� ��� �������� ��������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) ��� �����
		, QDAPI_ArrayStrings** tradeAccounts );                                 // (out) ������ �������� ������, � ������� ��������� ����� ���������

// ������� �������� ���� �� "�������� ������, ����������� ��� �������� ��������"
QDEALERAPI_API int _stdcall QDAPI_RemoveTrdAccFromGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) ��� �����
		, const char* tradeAccount );                                           // (in) �������� ����

// ���������� ������ �������� ������, ����������� ��� �������� ��������
QDEALERAPI_API int _stdcall QDAPI_SetGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) ��� �����
		, const QDAPI_ArrayStrings* tradeAccounts );                            // (in) ������ �������� ������
#pragma endregion
#pragma region //=============================== ProhibitOrders ===============================
// ������ ���������->�������, ��� ������� ��������� ���������� �������� ��������
// ���� �������� ��������������� �����������������.
// [ProhibitOrders]
// Clients = <��� ������� 1>, <��� ������� 2>, ..., <��� ������� N>

// �������� �������, ��� �������� ��������� ���������� �������� ��������
QDEALERAPI_API int _stdcall QDAPI_AddClientToGlobalProhibitOrders(
		const char* firmCode                                                    // (in) ��� �����
		, const char* clientCode );                                             // (in) ��� �������

// �������� ���� ������ ��������, ��� ������� ��������� ���������� �������� ��������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetGlobalProhibitOrders(
		const char* firmCode                                                    // (in) ��� �����
		, QDAPI_ArrayStrings** clientCodes );                                   // (out) ������ ����� ��������, � ������� ��������� ����� ���������

// ������� ������ ���������� �������� �������� ��� ��������� �������
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromGlobalProhibitOrders(
		const char* firmCode                                                    // (in) ��� �����
		, const char* clientCode );                                             // (in) ��� �������

// ���������� ������ ��������, ��� ������� ��������� ���������� �������� ��������
QDEALERAPI_API int _stdcall QDAPI_SetGlobalProhibitOrders(
		const char* firmCode                                                    // (in) ��� �����
		, const QDAPI_ArrayStrings* clientCodes );                              // (in) ������ ����� ��������
#pragma endregion
#pragma region //========================= RestOrdVolumeByAvgTurnover =========================
// ������ RestOrdVolumeByAvgTurnover
QDEALERAPI_API int _stdcall QDAPI_GetBasePeriodFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, int* basePeriod);                                                     // (out) ������� ������

// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
// ��������� lsClasses � lsInstruments ��������� ���� ��������� � ����� ���� ������ ��� NULL. � ���� ������, ��������������,
// ������ ���� �������� ����������� �� ���� ������� ��� �� ���� ������������. ���� ����� lsClasses ��� lsInstruments �� NULL, �� � count = 0, �� ���������� QDAPI_ERROR_INCORRECT_PARAMETER
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnoverEx(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) ������ ������������
	, QDAPI_ArrayVolumeRestrictionByAvgTurnover** restrs);                  // (out) ������ �����������, �������� �� ���� �������. � ������� ��������� ����� ���������

// ��������� lsClasses � lsInstruments ��������� ���� ��������� � ����� ���� ������ ��� NULL. � ���� ������, ��������������,
// ������ ���� �������� ����������� �� ���� ������� ��� �� ���� ������������. ���� ����� lsClasses ��� lsInstruments �� NULL, �� � count = 0, �� ���������� QDAPI_ERROR_INCORRECT_PARAMETER
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) ������ ������������
	, QDAPI_ArrayVolumeRestrictionByAvgTurnover** restrs);                  // (out) ������ �����������, �������� �� ���� �������. � ������� ��������� ����� ���������);

// ������ RestOrdVolumeByAvgTurnover
QDEALERAPI_API int _stdcall QDAPI_SetBasePeriodToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, int basePeriod);                                                      // (in) ������� ������

QDEALERAPI_API int _stdcall QDAPI_SetSettingToGlobalRestOrdVolumeByAvgTurnoverEx(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const QDAPI_ArrayVolumeRestrictionByAvgTurnover* restrs);	            // (in) ������

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode									                // (in) ��� �����
	, QDAPI_SettingsScope settingsScope   					                // (in) ��� ��������
	, const char* templateCode            				                    // (in) �������� �������
	, const QDAPI_ArrayVolumeRestrictionByAvgTurnover* restrs);	            // (in) ������ �����������

QDEALERAPI_API int _stdcall QDAPI_AddSettingsToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode									                // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings* classList                                         // (in) ������ �������
	, QDAPI_ArrayStrings* instrList                                         // (in) ������ ������������
	, double restPercent                                                    // (in) �����������, %
	, double alertPercent                                                   // (in) ��������������, %
	, const char* valuationClass);                                          // (in) ��� ������ ������

QDEALERAPI_API int _stdcall QDAPI_AddSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode									                // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_ArrayStrings* classList                                         // (in) ������ �������
	, QDAPI_ArrayStrings* instrList                                         // (in) ������ ������������
	, double restPercent                                                    // (in) �����������, %
	, double alertPercent                                                   // (in) ��������������, %
	, const char* valuationClass);                                          // (in) ��� ������ ������

// �������� RestOrdVolumeByAvgTurnover
QDEALERAPI_API int _stdcall QDAPI_RemoveSettingsFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings* classList                                         // (in) ������ �������
	, QDAPI_ArrayStrings* instrList);                                       // (in) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode            				                    // (in) �������� �������
	, QDAPI_ArrayStrings* classList                                         // (in) ������ �������
	, QDAPI_ArrayStrings* instrList);                                       // (in) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSettingsFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode				                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope);   	                            // (in) ��� ��������

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode				                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope  	                                // (in) ��� ��������
	, const char* templateCode); 	                                        // (in) �������� �������

// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� FreeMemory
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayVolumeRestriction** restrs)                                // (out) ������ �����������, �������� �� ���� �������. � ������� ��������� ����� ���������
	, "'QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnoverEx'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddClassSettingsToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������ �����������
	, double restPercent                                                    // (in) �����������, %
	, double alertPercent                                                   // (in) ��������������, %
	, const char* valuationClass)                                           // (in) ��� ������ ������
	, "'QDAPI_AddClassSettingsToGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_AddSettingsToGlobalRestOrdVolumeByAvgTurnover'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveClassSettingsFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode)                                                // (in) ��� ������ �����������
	, "'QDAPI_RemoveClassSettingsFromGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_RemoveSettingsFromGlobalRestOrdVolumeByAvgTurnover'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetSettingListToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const QDAPI_ArrayVolumeRestriction* restrs)                           // (in) ������ �����������, �������� �� ���� �������
	, "'QDAPI_SetSettingListToGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_SetSettingToGlobalRestOrdVolumeByAvgTurnoverEx'.");
#pragma endregion
#pragma region //============================ RestrictOptionOrders ============================
// ����������� �� ...->��������� ������->����������� �������� ���������
// ����������� ����������������� ��������������� �� �������� ������.
// [RestrictOptionOrders]
// <������� ����� 1> = <��������� ���� ���������� 1>, <������������ ���������� ������� 1>
// <������� ����� 2> = <��������� ���� ���������� 2>, <������������ ���������� ������� 2>
// ...
// <������� ����� N> = <��������� ���� ���������� N>, <������������ ���������� ������� N>
// <��������� ���� ����������> �������� � ������� <����>.<�����>.<���>
// ������:
// BaseAsset1 = 01.07.2018, 134.7

// �������� ����������� � ������������ �������� ���������
QDEALERAPI_API int _stdcall QDAPI_AddRestrictToGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) ��� �����
		, const QDAPI_RestrictOptionOrders* restr );                            // (in) ����������� �������� ���������

// �������� ������ ������� ������� �� ������� ������ ����������� �������� ���������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) ��� �����
		, QDAPI_ArrayStrings** baseAssets );                                    // (out) ������ ������� �������, � ������� ��������� ����� ���������

// �������� ����������� �������� ��������� �� �������� ������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetRestrictionGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) ��� �����
		, const char* baseAsset                                                 // (in) ������� �����
		, QDAPI_RestrictOptionOrdersBody** restrBody );                         // (out) ����������� �������� ���������, � ������� ��������� ����� ���������

// �������� ��� ����������� �������� ���������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetAllRestrictionsGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) ��� �����
		, QDAPI_ArrayRestrictOptionOrders** restrsList );                       // (out) ������ ����������� �������� ���������, � ������� ��������� ����� ���������

// ������� ����������� �� ����������� �������� ���������
QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictFromGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) ��� �����
		, const char* baseAsset );                                              // (in) ������� �����
#pragma endregion
#pragma region //=================== RestrictSecuritiesPropotionInCollateral ==================
// �����������->����������� � ������������ ���� � �����������
// ����������� ��������������� �����������������.
// [RestrictSecuritiesPropotionInCollateral]
// <���������� 1> =
// <���������� 2> =
// ...
// <���������� N> =

// �������� ���������� � ������������ ���� � �����������
QDEALERAPI_API int _stdcall QDAPI_AddSecurityToGlobalRestrictSecuritiesProportionInCollateral(
		const char* firmCode                                                    // (in) ��� �����
		, const char* secCode );                                                // (in) ��� �����������

// �������� ���� ������ ������������ � ������������ ���� � �����������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetGlobalRestrictSecuritiesProportionInCollateral(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_ArrayStrings** secCodes );                                          // (out) ������ ����� ������������, � ������� ��������� ����� ���������

// ������� ���������� �� ������ ������������ � ������������ ���� � �����������
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityFromGlobalRestrictSecuritiesProportionInCollateral(
		const char* firmCode                                                    // (in) ��� �����
		, const char* secCode );                                                // (in) ��� �����������

// ���������� ������ ������������ � ������������ ���� � �����������
QDEALERAPI_API int _stdcall QDAPI_SetGlobalRestrictSecuritiesProportionInCollateral(
		const char* firmCode                                                    // (in) ��� �����
		, const QDAPI_ArrayStrings* secCodes );                                 // (in) ������ ����� ������������
#pragma endregion
#pragma region //========================= Global -> RestrictSecurity =========================
// ������ ���������� �� ��������� ������������
// ����������� �� � ��������� ������ � �� ������� � ���������� �� ��������� ������������
// � �������� �������� ��������� settingsScope �������� QDAPI_SETTINGS_SCOPE_ADDITIONAL �� ��������������.
// ������ ������������ ������� �� ���������� ����������: �����, ������ �������� ������ (����� ���� ����),
//   ������� ���������� ������� (����� ���� �� �����). � �������� ������ ������������ ����� ���� �������
//   ������ �<ALL>�, ��� �������� ���������� �������� �� ���� ������������ ������, � ������ ������
//   �������� ������ � ������ �������.
// [RestrictSecurity]
// INDX_TIME_11:19,11:03_TRDACC_AC3,Ac7=Sc2, Sc4                                ; ������ ��� ��������� ���������
// GAZ_TIME_15:18,16:24_TRDACC_Ac2=<ALL>                                        ; ������ ������������ ����� ��� "��� �����������"
// GTS=Sc8                                                                      ; ��������� ������ ������ �� �����, ��� �������� ���������� ��������� � ������ �������� ������
// GTS_TIME_13:00,13:17=Sc1                                                     ; ��������� ������ �� <�����, �������� �������>, ��� �������� ������ �������� ������
// GTS_TIME_13:00,13:19=Sc1                                                     ; ��������� ������ �� <�����, �������� �������>, ��� �������� ������ �������� ������

// ��������� ������ �������, �� ������� ������ ��������� ������� ����
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) ������ �������, � ������� ��������� ����� ���������

// ��������� ������ ���������� �� ��������� �� �����
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayRestrictSecurityByClass** restrictions);                   // (out) ������ ����������, � ������� ��������� ����� ���������

// ���������� ����������� ������������ � ��������� �� <�����, ������ �������� ������, �������� �������>
QDEALERAPI_API int _stdcall QDAPI_AddSecurityListToGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) ������ �������� ������, � ������� ��������� ����� �������
	, bool isPeriodExists                                                   // (in) ����� �� ��������� ������
	, int fromTimeHours                                                     // (in) ������ �������: ����
	, int fromTimeMinutes                                                   // (in) ������ �������: ������
	, int tillTimeHours                                                     // (in) ����� �������: ����
	, int tillTimeMinutes                                                   // (in) ����� �������: ������
	, const QDAPI_ArrayStrings* lsSecurityCodes);                           // (in) ������ ������������, � ������� ��������� ����� �������

// ��������� ������ ����������� ������������ �� ��������� �� <�����, ������ �������� ������, �������� �������>
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) ������ �������� ������, � ������� ��������� ����� �������
	, bool isPeriodExists                                                   // (in) ����� �� ��������� ������
	, int fromTimeHours                                                     // (in) ������ �������: ����
	, int fromTimeMinutes                                                   // (in) ������ �������: ������
	, int tillTimeHours                                                     // (in) ����� �������: ����
	, int tillTimeMinutes                                                   // (in) ����� �������: ������
	, QDAPI_ArrayStrings** lsSecurityCodes);                                // (out) ������ ������������, � ������� ��������� ����� ���������

// �������� ����������� ������������ �� ��������� �� <�����, ������ �������� ������, �������� �������>
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) ������ �������� ������, � ������� ��������� ����� �������
	, bool isPeriodExists                                                   // (in) ����� �� ��������� ������
	, int fromTimeHours                                                     // (in) ������ �������: ����
	, int fromTimeMinutes                                                   // (in) ������ �������: ������
	, int tillTimeHours                                                     // (in) ����� �������: ����
	, int tillTimeMinutes                                                   // (in) ����� �������: ������
	, const QDAPI_ArrayStrings* lsSecurityCodes);                           // (in) ������ ������������, � ������� ��������� ����� �������

// ������ ������ ������������ � ��������� �� <�����, ������ �������� ������, �������� �������>
QDEALERAPI_API int _stdcall QDAPI_SetSecurityListToGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) ������ �������� ������, � ������� ��������� ����� �������
	, bool isPeriodExists                                                   // (in) ����� �� ��������� ������
	, int fromTimeHours                                                     // (in) ������ �������: ����
	, int fromTimeMinutes                                                   // (in) ������ �������: ������
	, int tillTimeHours                                                     // (in) ����� �������: ����
	, int tillTimeMinutes                                                   // (in) ����� �������: ������
	, const QDAPI_ArrayStrings* lsSecurityCodes);                           // (in) ������ ������������, � ������� ��������� ����� �������
#pragma endregion
#pragma region //============================ Global -> SubBrokers ============================
// ���������� ������ �� ������� �����������
// �������� ������ �����������
// ��� "������ ����� �����������" ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSubBrokerListFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** subBrokers);                                     // (out) ������ ����� �����������. � ������� ��������� ����� ���������

// ������� ���������� � ��� ��������� �� ����, ������� ������ ��� �����������.
QDEALERAPI_API int _stdcall QDAPI_RemoveSubBrokerFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* subBroker);                                               // (in) ��� ����������

// �������� ���������� ��������� ����������
QDEALERAPI_API int _stdcall QDAPI_AddSubClientToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* subBroker                                                 // (in) ��� ����������
	, const char* subClient);                                               // (in) ��� ����������

// �������� ������ ����������� ��������� ����������
// ��� "������ ����� �����������" ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSubClientListFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* subBroker                                                 // (in) ��� ����������
	, QDAPI_ArrayStrings** subClientList);                                  // (out) ������ ����� �����������. � ������� ��������� ����� ���������

QDEALERAPI_API int _stdcall QDAPI_RemoveSubClientFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* subBroker                                                 // (in) ��� ����������
	, const char* subClient);                                               // (in) ��� ����������

QDEALERAPI_API int _stdcall QDAPI_SetSubClientListToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* subBroker                                                 // (in) ��� ����������
	, const QDAPI_ArrayStrings* subClientList);                             // (in) ������ ����� �����������

// �������� ��������� ����������
// ��� ������������ �������� "globalLimit" ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSubBrokerSettingsFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* subBroker                                                 // (in) ��� ����������
	, int* flagNotAffectedOnGlobalLimit                                    // (out) ������� ����, ��� �������� ���������� �� ������ �� ���������� ����� �����
	, int* flagAffectedOnGlobalLimit                                       // (out) ������� ����, ��� �������� ���������� ������ �� ���������� ����� �����. ���������� � ������ [SubBrokerYesGlobals]
	, int* flagWithoutNetting                                              // (out) ������� ����, ��� �� ����������� ������ �����������. ���������� � ������ [SubBrokerWithoutNetting]
	, char** globalLimit);                                                  // (out) ���������� ����� ����������. � ������� ��������� ����� ���������

// ���������� ��������� ����������
QDEALERAPI_API int _stdcall QDAPI_SetSubBrokerSettingsToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* subBroker                                                 // (in) ��� ����������
	, const int flagNotAffectedOnGlobalLimit                               // (in) ������� ����, ��� �������� ���������� �� ������ �� ���������� ����� �����
	, const int flagAffectedOnGlobalLimit                                  // (in) ������� ����, ��� �������� ���������� ������ �� ���������� ����� �����. ���������� � ������ [SubBrokerYesGlobals]
	, const int flagWithoutNetting                                         // (in) ������� ����, ��� �� ����������� ������ �����������. ���������� � ������ [SubBrokerWithoutNetting]
	, const char* globalLimit);                                             // (in) ���������� ����� ����������. � ������� ��������� ��������� �� ������ ������
#pragma endregion
//MarginTemplate
#pragma region //=============================== MarginTemplate ===============================
// ���������� ������ ���� ������� � ������������ ������
QDEALERAPI_API int _stdcall QDAPI_AddClientToMarginTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, const char* clientCode );                                             // (in) ��� �������

// ��������� ������� ������ �������� � ������������ �������
// ���� �������� ����������� �����������������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientsListOfMarginTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, QDAPI_ArrayStrings** lsClientCodes );                                 // (out) ������ ����� ��������, � ������� ��������� ����� ���������

// ����������� ������ ���� ������� �� ������������� ������� � ������ ������������ ������
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenMarginTemplates(
		const char* firmCode                                                    // (in) ��� �����
		, const char* fromTemplateCode                                          // (in) �������� �������, �� �������� �������� ������
		, const char* toTemplateCode                                            // (in) �������� �������, � ������� ����������� ������
		, const char* clientCode );                                             // (in) ��� �������

// �������� ������ ���� ������� �� ������������� �������
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromMarginTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, const char* clientCode );                                             // (in) ��� �������

// ��������� ������� ������ �������� � ������������ �������
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfMarginTemplate(
		const char* firmCode                                                    // (in) ��� �����
		, const char* templateCode                                              // (in) �������� �������
		, const QDAPI_ArrayStrings* lsClientCodes );                            // (in) ������ ����� ��������
#pragma endregion
#pragma region //============================== SecurityDiscounts =============================
// �������� ��������� "��������" (���������� ���������)
// ������: [SecurityDiscounts]
QDEALERAPI_API int _stdcall QDAPI_GetSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* secCode                                                   // (in) ��� ������
	, QDAPI_Discounts* discounts );                                         // (out) ��������, � ������� ��������� ����� �������

// �������� ��������� "��������" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, const char* secCode                                                   // (in) ��� ������
	, QDAPI_Discounts* discounts);                                          // (out) ��������, � ������� ��������� ����� �������

// �������� ��������� "��������" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, const char* secCode                                                   // (in) ��� ������
	, QDAPI_Discounts* discounts);                                          // (out) ��������, � ������� ��������� ����� �������

// ������� ��������� "��������" �� �������� ������ (���������� ���������)
// ������: [SecurityDiscounts]
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* secCode);                                                 // (in) ��� ������

// ������� ��������� "��������" �� �������� ������ (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, const char* secCode);                                                 // (in) ��� ������

// ������� ��������� "��������" �� �������� ������ (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, const char* secCode);                                                 // (in) ��� ������


// ���������� ��������� "��������" (���������� ���������)
// ������: [SecurityDiscounts], [General]
QDEALERAPI_API int _stdcall QDAPI_SetSecurityDiscountsToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, const char* secCode                                                   // (in) ��� ������
	, const QDAPI_Discounts* discounts );                                   // (in) ��������


// ���������� ��������� "��������" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetSecurityDiscountsToClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, const char* secCode                                                   // (in) ��� ������
	, const QDAPI_Discounts* discounts );                                   // (in) ��������



// ���������� ��������� "��������" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetSecurityDiscountsToMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, const char* secCode                                                   // (in) ��� ������
	, const QDAPI_Discounts* discounts );                                   // (in) ��������
#pragma endregion
#pragma region //============================== UseDiscountsType ==============================
// �������� ��������� "������� ������ ��������� �����" (���������� ���������)
// ������: [General]
QDEALERAPI_API int _stdcall QDAPI_GetUseDiscountsTypeFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int* useDiscountsType );                                              // (out) ������� ������ ��������� �����, � ������� ��������� ����� �������

// �������� ��������� "������� ������ ��������� �����" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetUseDiscountsTypeFromClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, int* useDiscountsType );                                              // (out) ������� ������ ��������� �����, � ������� ��������� ����� �������

// �������� ��������� "������� ������ ��������� �����" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetUseDiscountsTypeFromMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, int* useDiscountsType );                                              // (out) ������� ������ ��������� �����, � ������� ��������� ����� �������

// ���������� ��������� "������� ������ ��������� �����" (���������� ���������)
// ������: [General]
QDEALERAPI_API int _stdcall QDAPI_SetUseDiscountsTypeToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int useDiscountsType );                                               // (in) ������� ������ ��������� �����

// ���������� ��������� "������� ������ ��������� �����" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetUseDiscountsTypeToClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, int useDiscountsType );                                               // (in) ������� ������ ��������� �����

// ���������� ��������� "������� ������ ��������� �����" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetUseDiscountsTypeToMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, int useDiscountsType );                                               // (in) ������� ������ ��������� �����
#pragma endregion
#pragma region //=========================== UseCHSecurityDiscounts ===========================
// �������� ��������� "������������ �������� ��" (���������� ���������)
// ������: [General]
QDEALERAPI_API int _stdcall QDAPI_GetUseCHSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int* useCHSecurityDiscounts );                                        // (out) ������������ �������� ��, � ������� ��������� ����� �������

// �������� ��������� "������������ �������� ��" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetUseCHSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, int* useCHSecurityDiscounts );                                        // (out) ������������ �������� ��, � ������� ��������� ����� �������

// �������� ��������� "������������ �������� ��" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetUseCHSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, int* useCHSecurityDiscounts );                                        // (out) ������������ �������� ��, � ������� ��������� ����� �������

// ���������� ��������� "������������ �������� ��" (���������� ���������)
// ������: [General]
QDEALERAPI_API int _stdcall QDAPI_SetUseCHSecurityDiscountsToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int useCHSecurityDiscounts );                                         // (in) ������������ �������� ��

// ���������� ��������� "������������ �������� ��" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetUseCHSecurityDiscountsToClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, int useCHSecurityDiscounts );                                         // (in) ������������ �������� ��

// ���������� ��������� "������������ �������� ��" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetUseCHSecurityDiscountsToMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, int useCHSecurityDiscounts );                                         // (in) ������������ �������� ��
#pragma endregion
#pragma region //============================ UseSecurityDiscounts ============================
// �������� ��������� "������������ ����������� ��������" (���������� ���������)
// ������: [General]
QDEALERAPI_API int _stdcall QDAPI_GetUseSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int* useSecurityDiscounts );                                          // (out) ������������ ����������� ��������, � ������� ��������� ����� �������

// �������� ��������� "������������ ����������� ��������" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetUseSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, int* useSecurityDiscounts );                                          // (out) ������������ ����������� ��������, � ������� ��������� ����� �������

// �������� ��������� "������������ ����������� ��������" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_GetUseSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, int* useSecurityDiscounts );                                          // (out) ������������ ����������� ��������, � ������� ��������� ����� �������

// ���������� ��������� "������������ ����������� ��������" (���������� ���������)
// ������: [General]
QDEALERAPI_API int _stdcall QDAPI_SetUseSecurityDiscountsToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, int useSecurityDiscounts );                                           // (in) ������������ ����������� ��������

// ���������� ��������� "������������ ����������� ��������" (�������������� ��������� �� �������)
// ������: [cl<��� �������>_Margin], [cl<��� �������>_Margin_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetUseSecurityDiscountsToClientSettings(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, int useSecurityDiscounts );                                           // (in) ������������ ����������� ��������

// ���������� ��������� "������������ ����������� ��������" (��������� ������������� �������)
// ������: [cl<��� �������>_Margin_Template], [cl<��� �������>_Margin_Template_LimitKind_<��� ������>]
QDEALERAPI_API int _stdcall QDAPI_SetUseSecurityDiscountsToMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, int limitKind                                                         // (in) ��� ������
	, int useSecurityDiscounts );                                           // (in) ������������ ����������� ��������

#pragma endregion
//RestrictionTemplate
#pragma region //============================= RestrictionTemplate ============================
// ���������� ������� ��� ������������
QDEALERAPI_API int _stdcall QDAPI_AddRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) �������� �������

// ��������� ������ �������� ��� ������������
QDEALERAPI_API int _stdcall QDAPI_GetListOfRestrictionTemplates(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsRestrictionTemplateCodes);                     // (out) ������ ������������ ��������

// �������� ������� ��� ������������
QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) �������� �������

// ���������� ������ ���� ������� � ������ �� ������������
QDEALERAPI_API int _stdcall QDAPI_AddClientToRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* clientCode );                                             // (in) ��� �������

// ��������� ������� ������ �������� � ������� �� ������������
// ���� �������� ����������� �����������������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientsListOfRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, QDAPI_ArrayStrings** lsClientCodes );                                 // (out) ������ ����� ��������, � ������� ��������� ����� ���������

// ����������� ������ ���� ������� �� ������� �� ������������ � ������ ������ �� ������������
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenRestrictionTemplates(
	const char* firmCode                                                    // (in) ��� �����
	, const char* fromTemplateCode                                          // (in) �������� �������, �� �������� �������� ������
	, const char* toTemplateCode                                            // (in) �������� �������, � ������� ����������� ������
	, const char* clientCode );                                             // (in) ��� �������

// �������� ������ ���� ������� �� ������� �� ������������
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* clientCode );                                             // (in) ��� �������

// ��������� ������� ������ �������� � ������� �� ������������
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const QDAPI_ArrayStrings* lsClientCodes );                            // (in) ������ ����� ��������
#pragma endregion
#pragma region //===================== ProhibitRepoByFirstPartSideAndTerm =====================
// �������� ��� ������ � ��������� �� <����������, �������������� ������ �����, ���� ����>
QDEALERAPI_API int _stdcall QDAPI_AddClassToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, const char* classCode);                                               // (in) ��� ������

QDEALERAPI_API int _stdcall QDAPI_AddClassToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, const char* classCode);                                               // (in) ��� ������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode );
, "'QDAPI_AddItemToGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_AddClassToGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode );
, "'QDAPI_AddItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_AddClassToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");

// �������� ������ ����� ������� �� ��������� �� <����������, �������������� ������ �����, ���� ����>
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, QDAPI_ArrayStrings** lsClassCodes);                                  // (out) ������ ����� �������, � ������� ��������� ����� ���������

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) ������ ����� �������, � ������� ��������� ����� ���������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, QDAPI_ArrayStrings** lsClassCodes );
, "'QDAPI_GetItemFromGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_GetClassListFromGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, QDAPI_ArrayStrings** lsClassCodes );
, "'QDAPI_GetItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_GetClassListFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");

// ������� ��� ������ �� �������� �� <����������, �������������� ������ �����, ���� ����>
QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, const char* classCode);                                               // (in) ��� ������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, const char* classCode);                                               // (in) ��� ������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode);
, "'QDAPI_RemoveItemFromGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode);
, "'QDAPI_RemoveItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");

// ���������� ������ ����� ������� � ��������� �� <����������, �������������� ������ �����, ���� ����>
QDEALERAPI_API int _stdcall QDAPI_SetClassListToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) ������ ����� �������

QDEALERAPI_API int _stdcall QDAPI_SetClassListToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �������������� ������ �����
	, char side                                                             // (in) �������������� ������ �����. ��������� ��������: 'B' � 'S'
	, int isRepoTermExist                                                   // (in) ����� �� ���� ����
	, int repoTerm                                                          // (in) ���� ����. ��������� ��������: ������������� �������� ������ ���� ������ 0
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) ������ ����� �������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_SetClassListToGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_SetClassListToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");
#pragma endregion
#pragma region //========================= RestrictRepoByFirstPartSide ========================
QDEALERAPI_API int _stdcall QDAPI_AddSecurityToRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, const char* templateCode                                                // (in) �������� �������
	, const char* classCode                                                   // (in) ��� ������
	, QDAPI_OperationSide side                                                // (in) ��������������
	, const char* secCode);                                                   // (in) ��� �����������

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, const char* templateCode                                                // (in) �������� �������
	, QDAPI_OperationSide side                                                // (in) ��������������
	, QDAPI_ArrayClassBySide** lsClassCodes);                                 // (out) ������ ����� ������� � ��������� ��������������

QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, const char* templateCode                                                // (in) �������� �������
	, const char* classCode                                                   // (in) ��� ������
	, QDAPI_OperationSide side                                                // (in) ��������������
	, QDAPI_ArrayStrings** lsSecurityCodes);                                  // (out) ������ ����� ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, const char* templateCode                                                // (in) �������� �������
	, const char* classCode                                                   // (in) ��� ������
	, QDAPI_OperationSide side);                                              // (in) ��������������

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, const char* templateCode                                                // (in) �������� �������
	, const char* classCode                                                   // (in) ��� ������
	, QDAPI_OperationSide side                                                // (in) ��������������
	, const char* secCode);                                                   // (in) ��� �����������

QDEALERAPI_API int _stdcall QDAPI_SetSecurityListToRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, const char* templateCode                                                // (in) �������� �������
	, const char* classCode                                                   // (in) ��� ������
	, QDAPI_OperationSide side                                                // (in) ��������������
	, const QDAPI_ArrayStrings* lsSecurityCodes);                             // (in) ������ ����� ������������
#pragma endregion
#pragma region //=============================== SecurityAllowed ==============================
// ��������� ���������:
//   [cl<TemplateName>_Restriction_Template]
//   SecurityAllowed_<Security>=<Class1>,<Class2>,�,<ClassN>
// <Security> - ��� �����������
// <Class1>,<Class2>,�,<ClassN> - ������ ����� �������.

// �������� ��� ������ � ��������� �� ����������
QDEALERAPI_API int _stdcall QDAPI_AddItemToRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, const char* classCode );                                              // (in) ��� ������

// �������� ������ ����� ������� �� ��������� �� ����������
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetItemFromRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, QDAPI_ArrayStrings** lsClassCodes );                                  // (out) ������ ����� �������, � ������� ��������� ����� ���������

// ������� ��� ������ �� �������� �� ����������
QDEALERAPI_API int _stdcall QDAPI_RemoveItemFromRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, const char* classCode );                                              // (in) ��� ������

// ���������� ������ ����� ������� � ��������� �� ����������
QDEALERAPI_API int _stdcall QDAPI_SetItemToRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, const QDAPI_ArrayStrings* lsClassCodes );                             // (in) ������ ����� �������
#pragma endregion
#pragma region //============================= SecurityRestricted =============================
// ���������� ���������:
//   [SecurityRestricted]
//   <Security>,<Side>=<Class1>,<Class2>,�,<ClassN>
// ��������� ���������:
//   [cl<TemplateName>_Restriction_Template]
//   SecurityRestricted_<Security>,<Side>=<Class1>,<Class2>,�,<ClassN>
// <Security> - ��� �����������
// <Side> - �����������, ����� ��������� ��������� ��������:
//   <�����> � ������������� ������ ����������� ������, �������� �� ���������
//   B � ������������� �������������� ��������.
//   S � ������������� �������������� ��������.
// <Class1>,<Class2>,�,<ClassN> - ������ ����� �������, ����� ��������� �������� <ALL>.

// �������� ������ ����� ������������ � ��������� ��������������, �� ������� ������ ��������� (<����������,�����������>)
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_OperationSide side                                              // (in) ��������������
	, QDAPI_ArraySecurityBySide** lsSecurityCodes);                         // (out) ������ ����� ������������ � ��������� ��������������, � ������� ��������� ����� ���������

QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ��� �������
	, QDAPI_OperationSide side                                              // (in) ��������������
	, QDAPI_ArraySecurityBySide** lsSecurityCodes);                         // (out) ������ ����� ������������ � ��������� ��������������, � ������� ��������� ����� ���������

// �������� ��� ������ � ��������� �� <����������,�����������>
QDEALERAPI_API int _stdcall QDAPI_AddClassToGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, const char* classCode);                                               // (in) ��� ������

QDEALERAPI_API int _stdcall QDAPI_AddClassToRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, const char* classCode);                                               // (in) ��� ������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, const char* classCode);
, "'QDAPI_AddItemToGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_AddClassToGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, const char* classCode);
, "'QDAPI_AddItemToRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_AddClassToRestrictionTemplateSecurityRestricted'.");

// �������� ������ ����� ������� �� ��������� �� <����������,�����������>
// ��� ������������ �������� ���������� ������, ������� ���������� ���������� ����� ������� ������� QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) ������ ����� �������, � ������� ��������� ����� ���������

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) ������ ����� �������, � ������� ��������� ����� ���������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, QDAPI_ArrayStrings** lsClassCodes);
, "'QDAPI_GetItemFromGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_GetClassListFromGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, QDAPI_ArrayStrings** lsClassCodes);
, "'QDAPI_GetItemFromRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_GetClassListFromRestrictionTemplateSecurityRestricted'.");

// ������� ��� ������ �� �������� �� <����������,�����������>
QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, const char* classCode);                                               // (in) ��� ������
QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, const char* classCode);                                               // (in) ��� ������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, const char* classCode );
, "'QDAPI_RemoveItemFromGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, const char* classCode );
, "'QDAPI_RemoveItemFromRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromRestrictionTemplateSecurityRestricted'.");

// ���������� ������ ����� ������� � ��������� �� <����������,�����������>
QDEALERAPI_API int _stdcall QDAPI_SetClassListToGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) ������ ����� �������

QDEALERAPI_API int _stdcall QDAPI_SetClassListToRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const char* secCode                                                   // (in) ��� �����������
	, int isSideExist                                                       // (in) ������ �� �����������
	, char side                                                             // (in) �����������
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) ������ ����� �������

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_SetClassListToGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_SetClassListToRestrictionTemplateSecurityRestricted'.");
#pragma endregion

// 1.8
#pragma region //===================== ClientTemplate -> SecurityDiscounts ====================
//��������� ������ ������������ �� ���������� ��������� ����������� ���������.������ ��������� �������� � ������[SecurityDiscounts].
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromGlobalSecurityDiscounts(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

//��������� ������ ������������ �� ��������� ��������� ����������� ���������.
//��������� �������� � ������� ���� [cl<TemplateID>_Margin_Template_<LimitKind>] (��� ������ �0 ������ ����� ��� [cl<TemplateID>_Margin_Template]).
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromMarginTemplateSecurityDiscounts(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

// ��������� ������ ������������ �� �������������� ��������� ����������� ���������. ��������� �������� � ������� ���� [cl<ClientID>_Margin_<LimitKind>] (��� ������ �0 ������ ����� ��� [cl<ClientID>_Margin]).
// ���� ��������� �� ������ � ������������ ������ ������. ���� ��� ���������� ���� ������� �������� ��� (��� ������ �� ���� ��� �������/�������) � ������������ ������ QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND
// ���� ��� ���������� ���� �������/�������� ���������� �������������� ��������� ��� �����, �� ��� ��������� ���� ������ ��������� �� ������ � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromClientSettingsSecurityDiscounts(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������
	, int limitKind                                                         // (in) ��� ������
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������
#pragma endregion
#pragma region //============================= Global -> TranoutTag ===========================
// ��������� ���� �������� ���������, �.�. ���� �������� �� ������ [TranoutTag]. ���� ��������� �� ������ � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromTranoutTagGlobal(
	const char* firmCode                                                    // (in)  ��� �����
	, QDAPI_ArrayTranoutTag** lsSettings);                                  // (out) ������ ��������

// ������������� (��������������) ���������. ��� ������ ������� ������ ��������� (������ [TranoutTag]) ���������.
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToTranoutTagGlobal(
	const char* firmCode                                                    // (in)  ��� �����
	, const QDAPI_ArrayTranoutTag* lsSettings);                             // (in) ������ ��������

#pragma endregion
#pragma region //=========================== SecurityProhibitedTrdAcc =========================
// ��������� ������ ���� �������� ������, ��� ������� ������ �����������. ���� ������ [SecurityProhibitedTrdAcc] �� ������,
// ��� ������, �� �� �������� �� ������ ��������� �����, �� ������������ ������ ������.
// ���� �� ���� � ��� �� �������� ���� ������ ��������� ��������, �� ��������� �� ������ �� ���������, � ������������ ��� ����.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) ������ �������� ������

// ��������� ������ ������������, �� ������� ������ ����������� ���� �� ��� ������ ��������� �����.
// ���� ������[SecurityProhibitedTrdAcc] �� ������, ��� ������, �� �� �������� �� ������ ���� �����������, �� ������������ ������ ������.��������� �� ������ ���������.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

// ��������� ������ ������������ ��� ����������� ��������� �����.���� ������ �� �������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
// ���� ��� ������ � ���� �� ��������� ����� ������ ��������� ������� � ������������ ������ QDAPI_ERROR_INVALID_SETTINGS_FORMAT.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForTrdAccFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

// ��������� ������ �������� ������, ��� ������� ������ ����������� �� ���������� ����������.���� ������ �� �������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsForInstrFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* instrument                                                // (in) ����������
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) ������ �������� ������

// ���������� ���� ����������� � ������ ������������ ��� ����������� �����.���� ���� �� ������ � �� �����������.
// ���� ��� ����� ��� ����� ������ ����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.���� ��� ����� ������ ����� ������ ������ � ������������ ������ QDAPI_ERROR_INVALID_SETTINGS_FORMAT.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForTradeAccToSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, const char* instrument);                                              // (in) ����������

// ������� ������ ������������ ��� ����������� ��������� �����. ���� ������ ������������ ����, �� ����������� ��� ���������� ��������� ����� �� ����������� / ���������.
// ����� �������, ������ ������� ��������� ����������� �������� ��������. ���� �������� ������ ��������� �������� �� ���� �������� ���� (��� �������) � ��� ������� ������� ������ ��������� ��� ������ � ���� �������� ������.
// ���� ���������� ������� ������ ��������� ������ � ��������, ����� ��� ��������� ����� ��� ���������� ����� ����� ������ � ���������� � ��� ������ � ��������� ������ ��������� � ��������� ���� ����� ������ � ��������� �����������.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForTradeAccToSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) ������ ������������

// �������� ���� ����������� �� ������ ������������ ��� ����������� �����.���� ���� ��� ������ �� ������� � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
// ���� � ���������� �������� ���� ����������� ������ ���������� ������ � ������ � �������� ������ ���������.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForTradeAccFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, const char* instrument);                                              // (in) ����������

#pragma endregion
#pragma region //======================== Global -> SecurityAllowedTrdAcc =====================
// ��������� ������ ���� �������� ������, ��� ������� ������ ����������. ���� ������ [SecurityAllowedTrdAcc] �� ������, ��� ������,
// �� �� �������� �� ������ ��������� �����, �� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) ������ �������� ������

// ��������� ������ ������������, �� ������� ������ ���������� ���� �� ��� ������ ��������� �����. ���� ������ [SecurityAllowedTrdAcc] �� ������,
// ��� ������, �� �� �������� �� ������ ���� �����������, �� ������������ ������ ������. ��������� �� ������ ���������.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

// ��������� ������ ������������ ��� ����������� ��������� �����. ���� ������ �� �������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForTrdAccFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

// ��������� ������ �������� ������, ��� ������� ������ ���������� �� ���������� ����������. ���� ������ �� �������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsForInstrFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* instrument                                                // (in) ����������
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) ������ �������� ������

// ���������� ���� ����������� � ������ ������������ ��� ����������� �����. ���� ���� �� ������ � �� �����������. ���� ��� ����� ��� ����� ������ ����������,
// �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForTradeAccToSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, const char* instrument);                                              // (in) ����������

// ������� ������ ������������ ��� ����������� ��������� �����. ���� ������ ������������ ����, �� ���������� ��� ���������� ��������� ����� �� ����������� / ���������.
// ����� �������, ������ ������� ��������� ����������� �������� ��������.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForTradeAccToSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) ������ ������������

// �������� ���� ����������� �� ������ ������������ ��� ����������� �����. ���� ���� ��� ������ �� ������� � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
// ���� � ���������� �������� ���� ����������� ������ ���������� ������ � ������ � �������� ������ ���������.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForTradeAccFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* tradeAccount                                              // (in) �������� ����
	, const char* instrument);                                              // (in) ����������

#pragma endregion
#pragma region //=========================== RESTSECURITY_IN_TEMPLATE =========================
// ��������� ������ ���� �������, �������� � ��������� ��� ����������� ������� �� ��������.���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ���� ��������� �� �������� �� ������ ������(�� ������), �� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetListOfClassesFromClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayStrings** lsClasses);                                      // (out) ������ �������

// ��������� ������ ���� �������, �������� � ��������� ��� ����������� ������� / ��������.���� �������� �� ��������� ��� ������� ��� ������� �� ����������, �� ������������ ������ QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// ���� ��������� �� �������� �� ������ ������(�� ������), �� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetListOfClassesFromClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� ������� ��� �������
	, QDAPI_ArrayStrings** lsClasses);                                      // (out) ������ �������

// ��������� ������ ������������, �������� ��� ������ � ���������� ������� �� ��������.���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ���� ������ �� �������(��� ������ ��������� �� ������), �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForClassFromClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

// ��������� ������ ������������, �������� ��� ������ ��� ����������� ������� / ��������.���� �������� �� ��������� ��� ������� ��� ������� �� ����������, �� ������������ ������ QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// ���� ������ �� �������(��� ������ ��������� �� ������), �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForClassFromClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� ������� ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) ������ ������������

// ���������� ���� ����������� � ������ ������������ ��� ������������� ������ � ������ ����������� ������� �� ��������.���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ���� ����� �� ������ � �� �����������.���� ��� ������ ��� ����� ������ ����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForClassToClientTemplateRestrictedSecurity(
	const char*  firmCode                                                   // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* instrument);                                              // (in) ����������

// ���������� ���� ����������� � ������ ������������ ��� ������������� ������ � ������ �������� ��� ����������� ������� / ��������.���� �������� �� ��������� ��� ������� ��� ������� �� ����������, �� ������������ ������ QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// ���� ����� �� ������ � �� �����������.���� ��� ������ ��� ����� ������ ����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForClassToClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� ������� ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* instrument);                                              // (in) ����������

// ������� ������ ������������ ��� ������������� ������ � ������ ����������� ������� �� ��������.���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ���� ������ ������������ ����, �� ����������� ��� ���������� ������ �� ����������� / ���������.����� �������, ������ ������� ��������� ����������� �������� ��������.���� ����� �� ������ � �� �����������.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForClassToClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsInstruments);                             // (in) ������ ������������

// ������� ������ ������������ ��� ������������� ������ � ������ �������� ��� ����������� ������� / ��������.���� �������� �� ��������� ��� ������� ��� ������� �� ����������, �� ������������ ������ QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// ���� ������ ������������ ����, �� ����������� ��� ���������� ������ �� ����������� / ���������.����� �������, ������ ������� ��������� ����������� �������� ��������.���� ����� �� ������ � �� �����������.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForClassToClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� ������� ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const QDAPI_ArrayStrings* lsInstruments);                             // (in) ������ ������������

// �������� ���� ����������� �� ������ ��� ������������� ������ � ������ ����������� ������� �� ��������.���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ���� ����� ��� ������ �� ������� � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.���� � ���������� �������� ���� ����������� ������ ���������� ������ � ������ ��� ���������� ������ ���������.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForClassFromClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* instrument);                                              // (in) ����������

// �������� ���� ����������� �� ������ ��� ������������� ������ � ������ �������� ���  ����������� ������� / ��������. ���� �������� �� ��������� ��� ������� ��� ������� �� ����������, �� ������������ ������ QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// ���� ����� ��� ������ �� ������� � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.���� � ���������� �������� ���� ����������� ������ ���������� ������ � ������ ��� ���������� ������ ���������.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForClassFromClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* clientCode                                                // (in) ��� ������� ��� �������
	, const char* classCode                                                 // (in) ��� ������
	, const char* instrument);                                              // (in) ����������
#pragma endregion
#pragma region //=============================== MaxPositionLimit =============================
// ��������� ���� �������� � ���������� ��������� ����������� �� ������������ ������ �������, ��� ����������� �� ���������� ������ ������������.���� ����������� ��� � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMaxPositionLimitFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const  QDAPI_ArrayStrings* lsInstruments                              // (in) ������ ������������
	, QDAPI_ArrayMaxPositionLimit** lsRestrs);                              // (out) ������ �����������

// ��������� ���� �������� � ������� ��� ������������ ����������� �� ������������ ������ �������, ��� ����������� �� ���������� ������ ������������.
// ���� ����������� ��� � ������������ ������ ������.���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetMaxPositionLimitFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const  QDAPI_ArrayStrings* lsInstruments                              // (in) ������ ������������
	, QDAPI_ArrayMaxPositionLimit** lsRestrs);                              // (out) ������ �����������

// ��������� ����������� �� �������� ������������ � ���������� ���������.���� ��������� ��� ������ ������� ��� ����������(��������� �����������), �� ��� ��������� ����������������,
// � ���� �� ���������� � ���������.���� � ��������� ������ ������������ ���� ���� �� ���� ��� �����������, ������� ����������� � ������ ���������� � ���� �� ���������,
// �� ��� ���� ���� ������ �� ���������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST(��� ��� ������� ���������� ����������� ��� ������ � ���� �� ����������� �� �����������).
QDEALERAPI_API int _stdcall QDAPI_SetMaxPositionLimitToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const  QDAPI_ArrayMaxPositionLimit* lsRestrs);                        // (in) ������ �����������

// ��������� ����������� �� �������� ������������ � ������� ��� ������������.���� ��������� ��� ������ ������� ��� ����������(��������� �����������), �� ��� ��������� ����������������,
// � ���� �� ���������� � ���������.���� � ��������� ������ ������������ ���� ���� �� ���� ��� �����������, ������� ����������� � ������ ���������� � ���� �� ���������,
// �� ��� ���� ���� ������ �� ���������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST(��� ��� ������� ���������� ����������� ��� ������ � ���� �� ����������� �� �����������).
// ���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_SetMaxPositionLimitToRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const  QDAPI_ArrayMaxPositionLimit* lsRestrs);                        // (in) ������ �����������

// �������� ����������� �� �������� ������������ � ���������� ���������.���� ��������� ��������(��������� �����������) �� ����������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMaxPositionLimitFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const  QDAPI_ArrayStrings* lsInstruments);                            // (in) ������ ������������

// �������� ����������� �� �������� ������������ � ������� ��� ������������.���� ��������� ��������(��������� �����������) �� ����������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
// ���� ������ �� ����������, �� ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMaxPositionLimitFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) �������� �������
	, const  QDAPI_ArrayStrings* lsInstruments);                            // (in) ������ ������������
#pragma endregion
#pragma region //================================ ClientTemplate ==============================
// ���������� ������� ��� ��������.���� ������ ��� ���������� � ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddClientTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) ��� �������

// �������� ������� ��� ��������.���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveClientTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) ��� �������

// ��������� ������ ���� �������� ��� ��������.���� �� ������ ������� �� ������� � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetListOfClientTemplates(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsClientTemplateCodes);                          // (out)������ ����� ��������

// ��������� ������ �������� ���� �� ��������� ��������� � ������ �������� �� ��������� ����� � ���������� ������� ��� ��������.
// ���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND. ���� �������� ����� �� ������ � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetIncludeClientsWithLeverageFromClientTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� ������� ��� ��������
	, QDAPI_ArrayDoubleNumbers** lsLeverages);                              // (out) ��������� �����

// ������� ������ �������� ���� � ��������� ��������� � ������ �������� �� ��������� ����� � ���������� ������� ��� ��������. ���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ��� ������� ������� �����, ������������ �� ��������� � ������ ������� ���� �� ����, ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST. ������� ����� ��������� ���������� �������� ���������, ��� ���� ���������� ������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_SetIncludeClientsWithLeverageToClientTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� ������� ��� ��������
	, const QDAPI_ArrayDoubleNumbers* lsLeverages);                         // (in) ��������� �����
#pragma endregion
#pragma region //================================ MarginTemplate ==============================
// ���������� ������� ��� �����.���� ������ ��� ���������� � ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) ��� �������

// �������� ������� ��� �����.���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode);                                            // (in) ��� �������

// ��������� ������ ���� �������� ��� �����.���� �� ������ ������� �� ������� � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetListOfMarginTemplates(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsMarginTemplateCodes);                          // (out)������

// ��������� ������ �������� ���� �� ��������� ��������� � ������ �������� �� ��������� ����� � ���������� ������� ��� �����. ���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ���� �������� ����� �� ������ � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetIncludeClientsWithLeverageFromMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� ������� ��� �����
	, QDAPI_ArrayDoubleNumbers** lsLeverages);                              // (out) ��������� �����

// ������� ������ �������� ���� � ��������� ��������� � ������ �������� �� ��������� ����� � ���������� ������� ��� �����. ���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ��� ������� ������� �����, ������������ �� ��������� � ������ ������� ���� �� ����, ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST. ������� ����� ��������� ���������� �������� ���������, ��� ���� ���������� ������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_SetIncludeClientsWithLeverageToMarginTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� ������� ��� �����
	, const QDAPI_ArrayDoubleNumbers* lsLeverages);                         // (in) ��������� �����
#pragma endregion

// 1.9
#pragma region //================================== LimitKinds =================================
// ��������� �������������� ��������� ������� ������� ��� ����������� ���� ������.��� ���������� ��������� ������������ ������ ������.
// ���� ��������� � �������� ��������� ��������� ��� ������, ��� �������� ���������� �������� ���������, ����������� � ���������� ��������� � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetClientSettingsLimitKinds(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, int limitKind                                                         // (in) ��� ������
	, QDAPI_ArrayIntNumbers** lsLimitKinds);                                // (out) ������ �������
// ��������� ������� ������� ��� ����������� ���� ������ ������� ��� �����.��� ���������� ��������� ������������ ������ ������.\
// ���� ��������� � �������� ��������� ��������� ��� ������, ��� �������� ���������� �������� ���������, ����������� � ���������� ��������� � ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetMarginTemplateLimitKinds(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ������������ �������
	, int limitKind                                                         // (in) ��� ������
	, QDAPI_ArrayIntNumbers** lsLimitKinds);                                // (out) ������ �������
// ��������� ������� ������� �� ���������� ���������.��� ���������� ��������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetGlobalLimitKinds(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayIntNumbers** lsLimitKinds);                                // (out) ������ �������
// ������� �������������� ��������� ������� ������� ��� ����������� ���� ������.�������� ��������� ����������� ��� ������ ������� ������� ������.
// ���� ��� ������, ��� �������� ���������� ������ ���������, �� ����� � ���������� ��������� - ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_SetClientSettingsLimitKinds(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, int limitKind                                                         // (in) ��� ������
	, QDAPI_ArrayIntNumbers* lsLimitKinds);                                 // (in) ������ �������
// ������� ������� ������� ��� ����������� ���� ������ ������� ��� �����.�������� ��������� ����������� ��� ������ ������� ������� ������.
// ���� ��� ������, ��� �������� ���������� ������ ���������, �� ����� � ���������� ��������� - ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_SetMarginTemplateLimitKinds(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ������������ �������
	, int limitKind                                                         // (in) ��� ������
	, QDAPI_ArrayIntNumbers* lsLimitKinds);                                 // (in) ������ �������
// ������� ������� ������� �� ���������� ���������.�������� ��������� ����������� ��� ������ ������� ������� ������.
QDEALERAPI_API int _stdcall QDAPI_SetGlobalLimitKinds(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayIntNumbers* lsLimitKinds);                                 // (in) ������ �������
#pragma endregion
#pragma region //========================= AllowedPartnersAndSettleCodes =======================
QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) ������ ������������ ��� ���������� ��������� �������� ����������

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm                                                     // (in) ������������ ���� ����
	, QDAPI_ArrayStrings** lsCP);                                           // (out) ������ ����� ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm);                                                   // (in) ������������ ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) ������ ������������ ��� ���������� ��������� �������� ����������

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm                                                     // (in) ������������ ���� ����
	, QDAPI_ArrayStrings** lsCP);                                           // (out) ������ ����� ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm);                                                   // (in) ������������ ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_AddCPListToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) ������ ������������ ��� ���������� ��������� �������� ����������

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm                                                     // (in) ������������ ���� ����
	, QDAPI_ArrayStrings** lsCP);                                           // (out) ������ ����� ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm);                                                   // (in) ������������ ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) ������ ������������

#pragma endregion
#pragma region //======================= ProhibitedPartnersAndSettleCodes ======================
QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) ������ ������������ ��� ���������� ��������� �������� ����������

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm                                                     // (in) ������������ ���� ����
	, QDAPI_ArrayStrings** lsCP);                                           // (out) ������ ����� ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm);                                                   // (in) ������������ ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ��� �������/�������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) ������ ������������ ��� ���������� ��������� �������� ����������

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm                                                     // (in) ������������ ���� ����
	, QDAPI_ArrayStrings** lsCP);                                           // (out) ������ ����� ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm);                                                   // (in) ������������ ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_AddCPListToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) ������ ������������ ��� ���������� ��������� �������� ����������

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) ������ ������������

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm                                                     // (in) ������������ ���� ����
	, QDAPI_ArrayStrings** lsCP);                                           // (out) ������ ����� ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) ������ ����� ��������
	, QDAPI_OperationSide operationSide                                     // (in) �������������� ��������
	, long long maxTerm);                                                   // (in) ������������ ���� ����

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) ������ ������������
#pragma endregion
#pragma region  //========================== Global -> MinOrderQty ==============================
// ��������� ���� �������� � ���������� ��������� �����������. �������� �������� ���������� �������� ������� � ������������ � �������� ����������� �������.
// ��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromGlobal(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, QDAPI_ArrayStrings* lsClasses                                           // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments                                       // (in) ������ ������������
	, QDAPI_ArrayMinOrderQty** lsRestrictions);                               // (out) ������ �����������

// ���������� ����������� ����������� ��� ����������� ������ ������� � ������������. ���� ���� �� ��� ������ ���������  ������ + ����������(������������� ��� ��������� ���������
// �������� � ������� ������� � ������������) ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST. ������ �������� ������ ������������ ��������������� ��� ����������� ��������.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToGlobal(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, QDAPI_MinOrderQty* restriction);                                        // (in) �����������

// ������� ����������� � ���������� ���������. ������� ��������� �������������� ��� ���������. ���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.
// ��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ��������� ������ � ����������� (� ������ �������� ������� ������� ������ ������������) ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToGlobal(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, QDAPI_ArrayMinOrderQty* restriction);                                   // (in) �����������

// �������� ����������� ����������� ��� ����������� ������ ������� � ������������. ���� ��� ��������� ��������� �������� ���������� (������ ������� + ������ ������������) ����������� �� ������,
// �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND. � ������� �� ������� ������� ���� ��� �������� ��������� ������ ���������� ������ ������� � ������������ (� ������ ����, ��� ������ ������������ ����� ���� ������).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromGlobal(
	const char* firmCode                                                      // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                       // (in) ��� ��������
	, QDAPI_ArrayStrings* lsClasses                                           // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments);                                     // (in) ������ ������������


#pragma endregion
#pragma region //========================== Global -> OrderMinValue ============================
// ��������� ���� �������� � ���������� ��������� �����������. �������� �������� ���������� �������� ������� � ������������ � �������� ����������� �������.
// ��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) ������ ������������
	, QDAPI_ArrayMinOrderValue** lsRestrictions);                           // (out) ������ �����������

// ���������� ����������� ����������� ��� ����������� ������ ������� � ������������.���� ���� �� ��� ������ ���������  ������ + ����������(������������� ��� ��������� ���������
//�������� � ������� ������� � ������������) ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.������ �������� ������ ������������ ��������������� ��� ����������� ��������.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_MinOrderValue* restriction);                                    // (in) �����������

// ������� ����������� � ���������� ���������. ������� ��������� �������������� ��� ���������. ���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.
// ��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ��������� ������ � ����������� (� ������ �������� ������� ������� ������ ������������) ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayMinOrderValue* restrictions);                              // (in) �����������

// �������� ����������� ����������� ��� ����������� ������ ������� � ������������. ���� ��� ��������� ��������� �������� ���������� (������ ������� + ������ ������������) ����������� �� ������,
// �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND. � ������� �� ������� ������� ���� ��� �������� ��������� ������ ���������� ������ ������� � ������������ (� ������ ����, ��� ������ ������������ ����� ���� ������).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) ������ ������������
#pragma endregion
#pragma region //====================== RestrictionTemplate -> MinOrderQty =====================
// G�������� ���� �������� � ������� ��������� �����������. �������� �������� ���������� �������� ������� � ������������ � �������� ����������� �������.
// ��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) ������ ������������
	, QDAPI_ArrayMinOrderQty** lsRestrictions);                             // (out) ������ �����������

// ���������� ���������� ����������� ��� ����������� ������ ������� � ������������. ���� ���� �� ��� ������ ���������  ������ + ����������(������������� ��� ��������� ���������
// �������� � ������� ������� � ������������) ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST. ������ �������� ������ ������������ ��������������� ��� ����������� ��������.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_MinOrderQty* restriction);                                      // (in) �����������

// ������� ����������� � ��������� ���������. ������� ��������� �������������� ��� ���������. ���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.
// ��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ��������� ������ � ����������� (� ������ �������� ������� ������� ������ ������������) ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayMinOrderQty* restriction);                                 // (in) �����������

// �������� ���������� ����������� ��� ����������� ������ ������� � ������������. ���� ��� ��������� ��������� �������� ���������� (������ ������� + ������ ������������) ����������� �� ������,
// �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND. � ������� �� ������� ������� ���� ��� �������� ��������� ������ ���������� ������ ������� � ������������ (� ������ ����, ��� ������ ������������ ����� ���� ������).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) ������ ������������
#pragma endregion
#pragma region //===================== RestrictionTemplate -> OrderMinValue ====================
// ��������� ���� �������� � ������� �����������. �������� �������� ���������� �������� ������� � ������������ � �������� ����������� �������.
// ��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) ������ ������������
	, QDAPI_ArrayMinOrderValue** lsRestrictions);                           // (out) ������ �����������

// ���������� ���������� ����������� ��� ����������� ������ ������� � ������������.���� ���� �� ��� ������ ���������  ������ + ����������(������������� ��� ��������� ���������
//�������� � ������� ������� � ������������) ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.������ �������� ������ ������������ ��������������� ��� ����������� ��������.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_MinOrderValue* restriction);                                    // (in) �����������

// ������� ����������� � ��������� ���������. ������� ��������� �������������� ��� ���������. ���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.
// ��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ��������� ������ � ����������� (� ������ �������� ������� ������� ������ ������������) ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayMinOrderValue* restrictions);                              // (in) �����������

// �������� ���������� ����������� ��� ����������� ������ ������� � ������������. ���� ��� ��������� ��������� �������� ���������� (������ ������� + ������ ������������) ����������� �� ������,
// �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND. � ������� �� ������� ������� ���� ��� �������� ��������� ������ ���������� ������ ������� � ������������ (� ������ ����, ��� ������ ������������ ����� ���� ������).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                     // (in) ��� ��������
	, const char* templateCode                                              // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) ������ ������������
#pragma endregion
#pragma region //====================== ClientTemplate -> MinOrderQuantity =====================
// ��������� ���� �������� � ������� �����������.�������� �������� ����������� �������� ������ � �������� ������������ �������.��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, const char* classCode                                                     // (in) �����
	, QDAPI_ArrayClassMinOrderQty** lsRestrictions);                            // (out) ������ �����������

// ���������� ���������� ����������� ��� ����������� ������.���� ��� ���������� ������ ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, QDAPI_ClassMinOrderQty* restriction);                                     // (in) �����������

// ������� ����������� � ��������� ���������.������� ��������� �������������� ��� ���������.���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ������ ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, QDAPI_ArrayClassMinOrderQty* restrictions);                               // (in) �����������

// �������� ���������� ����������� ��� ����������� ������.���� ��� ���������� ������ ����������� �� ������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, const char* classCode);                                                   // (in) ��� ������

// ��������� ���� �������� � �������������� / ���������� ���������� �����������.�������� �������� ����������� �������� ������ � �������� ������������ �������.��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, const char* classCode                                                     // (in) �����
	, QDAPI_ArrayClassMinOrderQty** lsRestrictions);                            // (out) ������ �����������

// ���������� ��������������� / ����������� ����������� ��� ����������� ������.���� ��� ���������� ������ ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, QDAPI_ClassMinOrderQty* restriction);                                     // (in) �����������

// ������� ����������� � �������������� / ���������� ���������.������� ��������� �������������� ��� ���������.���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ������ ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, QDAPI_ArrayClassMinOrderQty* restrictions);                               // (in) �����������

// �������� ��������������� / ����������� ����������� ��� ����������� ������.���� ��� ���������� ������ ����������� �� ������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, const char* classCode);                                                   // (in) ��� ������
#pragma endregion
#pragma region //======================== ClientTemplate -> OrderMinValue ======================
// ��������� ���� �������� � ������� �����������.�������� �������� ����������� �������� ������ � �������� ������������ �������.��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, const char* classCode                                                     // (in) �����
	, QDAPI_ArrayClassMinOrderValue** lsRestrictions);                          // (out) ������ �����������

// ���������� ���������� ����������� ��� ����������� ������.���� ��� ���������� ������ ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, QDAPI_ClassMinOrderValue* restriction);                                   // (in) �����������

// ������� ����������� � ��������� ���������.������� ��������� �������������� ��� ���������.���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ������ ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, QDAPI_ArrayClassMinOrderValue* restrictions);                             // (in) �����������

// �������� ���������� ����������� ��� ����������� ������.���� ��� ���������� ������ ����������� �� ������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromClientTemplate(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                           // (in) ��� ��������
	, const char* templateCode                                                  // (in) ������������ �������
	, const char* classCode);                                                   // (in) ��� ������

// ��������� ���� �������� � �������������� / ���������� ���������� �����������.�������� �������� ����������� �������� ������ � �������� ������������ �������.��� ���������� ����������� ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, const char* classCode                                                     // (in) �����
	, QDAPI_ArrayClassMinOrderValue** lsRestrictions);                          // (out) ������ �����������

// ���������� ��������������� / ����������� ����������� ��� ����������� ������.���� ��� ���������� ������ ��� ������ �����������, �� ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, QDAPI_ClassMinOrderValue* restriction);                                   // (in) �����������

// ������� ����������� � �������������� / ���������� ���������.������� ��������� �������������� ��� ���������.���� � ������� ����� ������ ������ � ��������� ��� ������� �����������.��� ������� ������� � ����� ������ ������� ����� ������ ����������� ��� ������ � ���� �� ������ ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, QDAPI_ArrayClassMinOrderValue* restrictions);                             // (in) �����������

// �������� ��������������� / ����������� ����������� ��� ����������� ������.���� ��� ���������� ������ ����������� �� ������, �� ������������ ������ QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromClientSettings(
	const char* firmCode                                                        // (in) ��� �����
	, QDAPI_SettingsScope settingsScope                                         // (in) ��� ��������
	, const char* clientCode                                                    // (in) ��� �������/�������
	, const char* classCode);                                                   // (in) ��� ������
#pragma endregion
#pragma region //=================== ClientTemplate -> VolumeBasedCommission ===================

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������������ �������
	, QDAPI_ArrayOfStringArrays** lsClassLists);                            // (out) ������ �������

QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsFromClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsClasses                                        // (out) ������ �������
	, QDAPI_ArrayOfVolumeBasedCommissionRates** rates);                     // (out) ������ ��������

QDEALERAPI_API int _stdcall QDAPI_AddClassToClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, const char* classCode);                                               // (in) ��� ������

QDEALERAPI_API int _stdcall QDAPI_SetClassListSettingsToClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayOfVolumeBasedCommissionRates* rates);                      // (in) ������ ��������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateName                                              // (in) ������������ �������
	, const char* classCode);                                               // (in) ��� ������

#pragma endregion
#pragma region //=================== ClientSettings -> VolumeBasedCommission ===================

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ������������ �������
	, QDAPI_ArrayOfStringArrays** lsClassLists);                            // (out) ������ �������

QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsFromClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ������������ �������
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsClasses                                        // (out) ������ �������
	, QDAPI_ArrayOfVolumeBasedCommissionRates** rates);                     // (out) ������ ��������

QDEALERAPI_API int _stdcall QDAPI_AddClassToClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, const char* classCode);                                               // (in) ��� ������

QDEALERAPI_API int _stdcall QDAPI_SetClassListSettingsToClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ������������ �������
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayOfVolumeBasedCommissionRates* rates);                      // (in) ������ ��������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* clientCode                                                // (in) ������������ �������
	, const char* classCode);                                               // (in) ��� ������

#pragma endregion
#pragma region //================ Global -> ClassesWithPriceExportForMarketOrders ==============

QDEALERAPI_API int _stdcall QDAPI_GetClassesWithPriceExportForMarketOrdersFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings** lsClasses);                                      // (out) ������ �������

QDEALERAPI_API int _stdcall QDAPI_SetClassesWithPriceExportForMarketOrdersToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings* lsClasses);                                       // (in) ������ �������

#pragma endregion
#pragma region //===================== Global -> CommissionSettingsCurrency ====================

QDEALERAPI_API int _stdcall QDAPI_GetCommissionSettingsCurrencyFromGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayClassListForCurrency** lsSettings);                        // (out) ������ ������������ ����� � �������

QDEALERAPI_API int _stdcall QDAPI_SetCommissionSettingsCurrencyToGlobal(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayClassListForCurrency* lsSettings);                         // (in) ������ ������������ ����� � �������

#pragma endregion
#pragma region //======================== Global -> VolumeBasedCommission ======================

QDEALERAPI_API int _stdcall QDAPI_GetClassListsFromGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayOfStringArrays** lsClassLists);                            // (out) ������ �������

QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsFromGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* classCode                                                 // (in) ��� ������
	, QDAPI_ArrayStrings** lsClasses                                        // (out) ������ �������
	, QDAPI_ArrayOfVolumeBasedCommissionRates** rates);                     // (out) ������ ��������

QDEALERAPI_API int _stdcall QDAPI_AddClassToGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, const char* classCode);                                               // (in) ��� ������

QDEALERAPI_API int _stdcall QDAPI_SetClassListSettingsToGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, QDAPI_ArrayStrings* lsClasses                                         // (in) ������ �������
	, QDAPI_ArrayOfVolumeBasedCommissionRates* rates);                      // (in) ������ ��������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) ��� �����
	, const char* classCode);                                               // (in) ��� ������

#pragma endregion

#pragma region
//��������� ������������ � ���������� ������ (Set of Instruments&)
QDEALERAPI_API int _stdcall QDAPI_GetGroupsWithDependentPricesListFromGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	QDAPI_ArrayGroupsWithDependentPrices** lsGroups                         // (out) � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_AddGroupWithDependentPricesToGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	const QDAPI_GroupWithDependentPrices* group                            // (in) � ��������� [������������, ������� ���������]
);

QDEALERAPI_API int _stdcall QDAPI_RemoveGroupWithDependentPricesFromGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	const char* groupCode                                                     // (in) � ������������ ���������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	const char* groupCode,                                                    // (in) � ������������ ���������
	QDAPI_ArrayInstruments** lsInstruments                                  // (out) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentToGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	const char* groupCode,                                                    // (in) � ������������ ���������
	const QDAPI_Instrument* instrument                                      // (in) -  ����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListToGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	const char* groupCode,                                                    // (in) � ������������ ���������
	const QDAPI_ArrayInstruments* lsInstruments                             // (in) � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentFromGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	const char* groupCode,                                                    // (in) � ��� ���������
	const char* secCode                                                     // (in) � ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_GetGroupsWithDependentPricesListFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ������������ �������
	QDAPI_ArrayGroupsWithDependentPrices** lsGroups                         // (out) � ������ �������� [������������, ������� ���������]
);

QDEALERAPI_API int _stdcall QDAPI_AddGroupWithDependentPricesToMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ������������ �������
	const QDAPI_GroupWithDependentPrices* group                            // (in) � ��������� [��������� +������� ���������]
);

QDEALERAPI_API int _stdcall QDAPI_RemoveGroupWithDependentPricesFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ������������ �������
	const char* groupCode                                                    // (in) � ������������ ���������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromGroupWithDependentMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ������������ �������
	const char* groupCode,                                                  // (in)  - ����������� ���������
	QDAPI_ArrayInstruments** lsInstruments                                 // (out) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentToGroupWithDependentPricesMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ������������ �������
	const char* groupCode,                                                  // (in) � ������������ ���������
	const QDAPI_Instrument* instrument                                     // (in) ����������� [���, ����, �����]
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListToGroupWithDependentPricesMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ������������ �������
	const char* groupCode,                                                   // (in) ������������� ���������
	const QDAPI_ArrayInstruments* lsInstruments                            // (in) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentFromGroupWithDependentPricesMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ������������ �������
	const char* groupCode,                                                   // (in) � ������������ ���������
	const char* secCode                                                    // (in) � ��� �����������
);

//������������ ��������� ��� ��������, �� �������� � ������
QDEALERAPI_API int _stdcall QDAPI_GetUseGroupsForNonTemplateClientsFromGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	bool* value                                                            // (out) ��������� ���������
);

QDEALERAPI_API int _stdcall QDAPI_SetUseGroupsForNonTemplateClientsToGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	bool value                                                             // (in) � �������� ���������
);

//������������ ���������� ��������� ��� ������� �����
QDEALERAPI_API int _stdcall QDAPI_GetUseGlobalGroupsInMarginCalculationFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ��� �������
	bool* value                                                            // (out) � �������� ���������
);

QDEALERAPI_API int _stdcall QDAPI_SetUseGlobalGroupsInMarginCalculationToMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ��� �������
	bool value                                                             // (in) � ��������
);

//����������� �������� �������� �� ������� ��
QDEALERAPI_API int _stdcall QDAPI_GetFuturesDiscountFromCollateralAmountFromGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	bool* value                                                            // (out) � �������� ���������
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesDiscountFromCollateralAmountToGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	bool value                                                             // (in) � �������� ���������
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesDiscountFromCollateralAmountToMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* tempalteCode,                                              // (in) - ��� �������
	bool value                                                             // (in) � �������� 
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesDiscountFromCollateralAmountFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* tempalteCode,                                              // (in) - ��� �������
	bool* value                                                            // (out) � �������� 
);


//������� � ���������� ������� �����
QDEALERAPI_API int _stdcall QDAPI_GetHighRiskLevelClientsFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ��� �������
	bool* value                                                            // (out) � �������� ���������
);

QDEALERAPI_API int _stdcall QDAPI_SetHighRiskLevelClientsToMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) � ��� �������
	bool value                                                             // (in) � ��������
);

//����������� ��� ������� ����������� ����� � ����� ��+
QDEALERAPI_API int _stdcall QDAPI_GetMDPlusMinMarginCalcRateFromGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	double* value                                                          // (out) � �������� ���������
);

QDEALERAPI_API int _stdcall QDAPI_SetMDPlusMinMarginCalcRateToGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	double value                                                           // (in) � ��������
);


//����������� ��� ����� ��������� �����
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_ArrayStrings** lsClasses                                         // (out)  - ������ �������
);

QDEALERAPI_API int _stdcall QDAPI_AddClassToInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* classCode                                                  // (in) � ��� ������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* classCode                                                  // (in) � ��� ������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                   // (in) � ��� �����
	const char* classCode,                                                  // (in) � ��� ������
	QDAPI_ArrayStrings** lsInstruments                                      // (out) ������� ������������
);

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* classCode,                                                 // (in) � ��� ������
	const char* secCode                                                    // (in)  - ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* classCode,                                                 // (in) � ��� ������
	QDAPI_ArrayStrings* lsInstruments                                      // (in) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* classCode,                                                 // (in) � ��� ������
	const char* secCode                                                    // (in) � ��� �����������
);

#pragma endregion

#pragma region 
QDEALERAPI_API int _stdcall QDAPI_GetClientMarginSchemeListFromGlobal(
	const char* firmCode                                                   // (in) � ��� �����
	, QDAPI_ArrayClientLag** lsClientLags                                  // (out) ������ ������������ ����� ������� � ���� ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClientMarginSchemeFromGlobal(
	const char* firmCode                                                   // (in) � ��� �����
	, const char* clientCode                                               // (in) - ��� �������
);

QDEALERAPI_API int _stdcall QDAPI_AddClientMarginSchemeToGlobal(
	const char* firmCode                                                   // (in) � ��� �����
	, const char* clientCode                                               // (in) - ��� �������
	, QDAPI_ClientLagType lagType                                          // (in) - ����� ������������ �������
);

QDEALERAPI_API int _stdcall QDAPI_SetClientMarginSchemeListToGlobal(
	const char* firmCode                                                   // (in) � ��� �����
	, QDAPI_ArrayClientLag* lsClientLags                                   // (in) ������ ������������ ����� ������� � ���� ������������
);

QDEALERAPI_API int _stdcall QDAPI_GetChangeFutClientCodesByFirmFromGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* futTrdacc,                                                 // (in) � ��� ������
	QDAPI_ArrayClientCodeToTrdAcc** lsClientCodeToTrdAcc                   // (out) � ������ ������������ ����� ������� � �������� ������
);


QDEALERAPI_API int _stdcall QDAPI_GetCommissionTypeAndSimpleRatesFromClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		QDAPI_CommissionTypeAndRate** commissionTypeAndRate                // (out) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionTypeAndSimpleRatesFromClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	QDAPI_CommissionTypeAndRate** commissionTypeAndRate                // (out) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionTypeAndSimpleRatesToClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		QDAPI_CommissionTypeAndRate* commissionTypeAndRate                 // (in) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionTypeAndSimpleRatesToClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) � ��� �������
	QDAPI_CommissionTypeAndRate* commissionTypeAndRate                 // (in) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_GetTPNameFromClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		char** TPName                                                      // (out) - ��� ��������� �����
);

QDEALERAPI_API int _stdcall QDAPI_GetTPNameFromClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) � ��� �������
	char** TPName                                                      // (out) - ��� ��������� �����
);

QDEALERAPI_API int _stdcall QDAPI_SetTPNameToClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		const char* TPName                                                 // (in) - ��� ��������� �����
);

QDEALERAPI_API int _stdcall QDAPI_SetTPNameToClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	const char* TPName                                                 // (in) - ��� ��������� �����
);

QDEALERAPI_API int _stdcall QDAPI_GetRepoBrokerRateFromClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		double* repoCommissionRate                                         // (out) - ������ �������� ���� � % �� ������ �� ������ ���� ����� ������
);

QDEALERAPI_API int _stdcall QDAPI_GetRepoBrokerRateFromClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	double* repoCommissionRate                                         // (out) - ������ �������� ���� � % �� ������ �� ������ ���� ����� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetRepoBrokerRateToClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		double repoCommissionRate                                          // (in) - ������ �������� ���� � % �� ������ �� ������ ���� ����� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetRepoBrokerRateToClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	double repoCommissionRate                                          // (in) - ������ �������� ���� � % �� ������ �� ������ ���� ����� ������
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionByClassesFromClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		QDAPI_ArrayClassCommissionType** commissionTypeAndRate             // (out) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionByClassesFromClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	QDAPI_ArrayClassCommissionType** commissionTypeAndRate             // (out) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionByClassesToClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		QDAPI_ArrayClassCommissionType* commissionTypeAndRate              // (in) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionByClassesToClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	QDAPI_ArrayClassCommissionType* commissionTypeAndRate              // (in) - ��� � ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesCommissionFromClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		QDAPI_ArrayBaseAssetCommissionRate** lsBaseAssetCommission         // (out) - ������ (��� �����������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesCommissionFromClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	QDAPI_ArrayBaseAssetCommissionRate** lsBaseAssetCommission         // (out) - ������ (��� �����������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesCommissionToClientTemplate(
		const char* firmCode,                                              // (in) � ��� �����
		const char* templateName,                                          // (in) � ��� �������
		QDAPI_ArrayBaseAssetCommissionRate* lsBaseAssetCommission          // (in) - ������ (��� �����������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesCommissionToClientSettings(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                            // (in) - ��� �������
	QDAPI_ArrayBaseAssetCommissionRate* lsBaseAssetCommission          // (in) - ������ (��� �����������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleJumpFromClientSettings(
		const char* firmCode,                                              // (in) � ��� �����
		const char* clientCode,                                            // (in) - ��� �������
		int* commissionScaleJump                                           // (out) - �-1� (�� ���������) � ������������ �������� ���������� ���������.�0� - ���������, ������������ ����� ��� ���������.	�1� � ��������, ������������ ����� � ����������.
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleJumpFromClientTemplate(
	const char* firmCode,                                              // (in) � ��� �����
	const char* clientCode,                                          // (in) � ��� �������
	int* commissionScaleJump                                           // (out) - �-1� (�� ���������) � ������������ �������� ���������� ���������.�0� - ���������, ������������ ����� ��� ���������.	�1� � ��������, ������������ ����� � ����������.
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleJumpToClientSettings(
		const char* firmCode,                                              // (in) � ��� �����
		const char* clientCode,                                            // (in) - ��� �������
		int commissionScaleJump                                            // (in) - �-1� (�� ���������) � ������������ �������� ���������� ���������.�0� - ���������, ������������ ����� ��� ���������.	�1� � ��������, ������������ ����� � ����������.
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleJumpToClientTemplate(
	const char* firmCode,                                              // (in) � ��� �����
	const char* templateName,                                          // (in) � ��� �������
	int commissionScaleJump                                            // (in) - �-1� (�� ���������) � ������������ �������� ���������� ���������.�0� - ���������, ������������ ����� ��� ���������.	�1� � ��������, ������������ ����� � ����������.
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRestrictionsFromClientSettings(
		const char* firmCode,                                              // (in) � ��� �����
		const char* clientCode,                                            // (in) - ��� �������
		QDAPI_ScaleCommExParams** minMaxTurnover                           // (out) -������������ ��������, ����������� ��������, ����������� ������
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRestrictionsFromClientTemplate(
	const char* firmCode,                                              // (in) � ��� �����
	const char* templateName,                                          // (in) � ��� �������
	QDAPI_ScaleCommExParams** minMaxTurnover                           // (out) -������������ ��������, ����������� ��������, ����������� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRestrictionsToClientSettings(
		const char* firmCode,                                              // (in) � ��� �����
		const char* clientCode,                                            // (in) - ��� �������
		QDAPI_ScaleCommExParams* minMaxTurnover                            // (in) -������������ ��������, ����������� ��������, ����������� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRestrictionsToClientTemplate(
	const char* firmCode,                                              // (in) � ��� �����
	const char* templateName,                                          // (in) � ��� �������
	QDAPI_ScaleCommExParams* minMaxTurnover                            // (in) -������������ ��������, ����������� ��������, ����������� ������
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRatesFromClientSettings(
		const char* firmCode,                                               // (in) � ��� �����
		const char* clientCode,                                             // (in) - ��� �������
		QDAPI_ArrayOfScaleRates** scale                                     // (out) - ���������� �������� ����� � �������� (����� �������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRatesFromClientTemplate(
	const char* firmCode,                                              // (in) � ��� �����
	const char* templateName,                                          // (in) � ��� �������
	QDAPI_ArrayOfScaleRates** scale                                    // (out) - ���������� �������� ����� � �������� (����� �������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRatesToClientSettings(
		const char* firmCode,                                              // (in) � ��� �����
		const char* clientCode,                                            // (in) - ��� �������
		QDAPI_ArrayOfScaleRates* scale                                     // (in) - ���������� �������� ����� � �������� (����� �������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRatesToClientTemplate(
	const char* firmCode,                                              // (in) � ��� �����
	const char* templateName,                                          // (in) � ��� �������
	QDAPI_ArrayOfScaleRates* scale                                     // (in) - ���������� �������� ����� � �������� (����� �������, ������)
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCommissionScaleFromClientSettings(
		const char* firmCode,                                              // (in) � ��� �����
		const char* clientCode                                             // (in) - ��� �������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCommissionScaleFromClientTemplate(
	const char* firmCode,                                              // (in) � ��� �����
	const char* templateName                                           // (in) � ��� �������
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionByClassesFromGlobal(
		const char* firmCode,                                              // (in) � ��� �����
		QDAPI_ArrayClassCommissionType** commissionTypeAndRate             // (out) - ��� ��������� � �� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionByClassesToGlobal(
		const char* firmCode,                                              // (in) � ��� �����
		QDAPI_ArrayClassCommissionType* commissionTypeAndRate              // (in) - ��� ��������� � �� ������
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesCommissionFromGlobal(
		const char* firmCode,                                              // (in) � ��� �����
		QDAPI_ArrayBaseAssetCommissionRate** lsBaseAssetCommission         // (out) - ������ ��� ������� (�����; ������ ��������)
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesCommissionToGlobal(
		const char* firmCode,                                              // (in) � ��� �����
		QDAPI_ArrayBaseAssetCommissionRate* lsBaseAssetCommission          // (in) - ������ ��� ������� (�����; ������ ��������)
);

QDEALERAPI_API int _stdcall QDAPI_GetSecurityWeightFromGlobal(
	const char* firmCode,                                                  // (in) � ��� ����� 
	QDAPI_SecsWithWeightAndRestrictionsList** lsSec                        // (out) - ������ ������������ �� �������
);

QDEALERAPI_API int _stdcall QDAPI_GetSecurityWeightFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithWeightAndRestrictionsList** lsSec                        // (out) - ������ ������������ �� �������
);

QDEALERAPI_API int _stdcall QDAPI_GetSecurityWeightFromClientSettings(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithWeightAndRestrictionsList** lsSec                        // (out) - ������ ������������ �� �������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithCoefficientsFromGlobalSecurityWeight(
	const char* firmCode,                                                   // (in) � ��� �����
	QDAPI_SecsWithCoeffsList** lsSec                                        // (out) - ������ ������������ �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithCoefficientsFromMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithCoeffsList** lsSec                                       // (out) - ������ ������������ �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithCoefficientsFromClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithCoeffsList** lsSec                                       // (out) - ������ ������������ �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithPositionRestrictionFromGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecsWithRestrictionsList** lsSec                                 // (out) - ������ ������������ �� ���������� ����������� �� ������ ������� 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithPositionRestrictionFromMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithRestrictionsList** lsSec                                 // (out) - ������ ������������ �� ���������� ����������� �� ������ ������� 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithPositionRestrictionFromClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithRestrictionsList** lsSec                                 // (out) - ������ ������������ �� ���������� ����������� �� ������ ������� 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecsWithVarianceList** lsSec                                     // (out) -������ ������������ �� ���������� ������������� ���������� �������� ���� 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithVarianceList** lsSec                                     // (out) -������ ������������ �� ���������� ������������� ���������� �������� ���� 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithVarianceList** lsSec                                     // (out) -������ ������������ �� ���������� ������������� ���������� �������� ���� 
);

QDEALERAPI_API int _stdcall QDAPI_SetSecurityWeightToGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecsWithWeightAndRestrictionsList* lsSec                         // (in) - ������ ������������ �� �������
);

QDEALERAPI_API int _stdcall QDAPI_SetSecurityWeightToMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithWeightAndRestrictionsList* lsSec                         // (in) - ������ ������������ �� �������
);

QDEALERAPI_API int _stdcall QDAPI_SetSecurityWeightToClientSettings(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithWeightAndRestrictionsList* lsSec                         // (in) - ������ ������������ �� �������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentCoefficientsToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecWithCoeffs* sec                                               // (in) - ���������� �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentCoefficientsToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecWithCoeffs* sec                                               // (in) - ���������� �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentCoefficientsToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecWithCoeffs* sec                                               // (in) - ���������� �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentPositionRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecWithRestrictions* sec                                         // (in) - ����������� �� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentPositionRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecWithRestrictions* sec                                         // (in) - ����������� �� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentPositionRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecWithRestrictions* sec                                         // (in) - ����������� �� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentRepoDiscountRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecWithVariance* sec                                             // (in) - ������������ ���������� �������� ���� ��� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentRepoDiscountRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecWithVariance* sec                                             // (in) - ������������ ���������� �������� ���� ��� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentRepoDiscountRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecWithVariance* sec                                             // (in) - ������������ ���������� �������� ���� ��� ������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithCoefficientsToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecsWithCoeffsList* lsSec                                        // (in) - ������ ������������ �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithCoefficientsToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithCoeffsList* lsSec                                        // (in) - ������ ������������ �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithCoefficientsToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithCoeffsList* lsSec                                        // (in) - ������ ������������ �� ��������� �������������� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithPositionRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecsWithRestrictionsList* lsSec                                  // (in) - ������ ������������ �� ���������� ����������� �� ������ ������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithPositionRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithRestrictionsList* lsSec                                  // (in) - ������ ������������ �� ���������� ����������� �� ������ ������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithPositionRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithRestrictionsList* lsSec                                  // (in) - ������ ������������ �� ���������� ����������� �� ������ ������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithRepoDiscountRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	QDAPI_SecsWithVarianceList* lsSec                                      // (in) -������ ������������ �� ���������� ������������� ���������� �������� ���� 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithRepoDiscountRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithVarianceList* lsSec                                      // (in) -������ ������������ �� ���������� ������������� ���������� �������� ���� 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithRepoDiscountRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	QDAPI_SecsWithVarianceList* lsSec                                      // (in) -������ ������������ �� ���������� ������������� ���������� �������� ���� 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityWeightForInstrumentFromGlobal(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* secCode                                                    // (in) � ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityWeightForInstrumentFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	const char* secCode                                                    // (in) � ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityWeightForInstrumentFromClientSettings(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind,                                                   // (in) - ��� ������
	const char* secCode                                                    // (in) � ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSecurityWeightFromGlobal(
	const char* firmCode                                                   // (in) � ��� �����
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSecurityWeightFromMarginTemplate(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* templateCode,                                              // (in) - ��� �������
	const int limitKind                                                    // (in) - ��� ������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSecurityWeightFromClientSettings(
	const char* firmCode,                                                  // (in) � ��� �����
	const char* clientCode,                                                // (in) - ��� �������
	const int limitKind                                                    // (in) - ��� ������
);
#pragma endregion

#pragma region
QDEALERAPI_API int _stdcall QDAPI_GetProhibitedCPAndSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency** lsProhibitedCPSC      // (out) - ������ �������� �������� � ������������ �� ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedSettlementCurrency** lsProhibitedSC             // (out) - ������ �������� �������� �� ������ �������� ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetProhibitedCPAndSettlementCurrencyToGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency* lsProhibitedCPSC       // (in) - ������ �������� �������� � ������������ �� ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedSettlementCurrency* lsProhibitedSC              // (in) - ������ �������� �������� �� ������ �������� ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, const char* cP                                                       // (in) - ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_GetProhibitedCPAndSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency** lsProhibitedCPSC      // (out) - ������ �������� �������� � ������������ �� ������ �������� 
); 

QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedSettlementCurrency** lsProhibitedSC             // (out) - ������ �������� �������� �� ������ �������� ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetProhibitedCPAndSettlementCurrencyToRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency* lsProhibitedCPSC       // (in) - ������ �������� �������� � ������������ �� ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayProhibitedSettlementCurrency* lsProhibitedSC              // (in) - ������ �������� �������� �� ������ �������� ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_GetRestrictREPOWithCPBasedOnTermFromGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm** lsRestrictRepoCP          // (out) - ������ ����������� �������� ���� c ������������ �� ����� ������ 
);

QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOBasedOnTerm** lsRestrictRepo                  // (out) - ������ ����������� �������� ���� �� ����� ������ ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictREPOWithCPBasedOnTermToGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm* lsRestrictRepoCP           // (in) - ������ ����������� �������� ���� c ������������ �� ����� ������ 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOBasedOnTerm* lsRestrictRepo                   // (in) - ������ ����������� �������� ���� �� ����� ������ ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_GetRestrictREPOWithCPBasedOnTermFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm** lsRestrictRepoCP          // (out) - ������ ����������� �������� ���� c ������������ �� ����� ������ 
);
QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOBasedOnTerm** lsRestrictRepo                  // (out) - ������ ����������� �������� ���� �� ����� ������ ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictREPOWithCPBasedOnTermToRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm* lsRestrictRepoCP           // (in) - ������ ����������� �������� ���� c ������������ �� ����� ������ 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictREPOBasedOnTerm* lsRestrictRepo                   // (in) - ������ ����������� �������� ���� �� ����� ������ ��� �����������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* cP                                                       // (in) - ��� �����������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
); 

QDEALERAPI_API int _stdcall QDAPI_GetRestrictMaxValueForSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency** lsRestrictMVSC    // (out) - ������ ����������� ������������� ������ ������ � ������ �������� 
); 

QDEALERAPI_API int _stdcall QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* settlementCurrency                                       // (in) - ������ ��������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValue** lsRestrictMV                           // (out) - ������ ����������� ������������� ������ ������ ��� ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictMaxValueForSettlementCurrencyToGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency* lsRestrictMVSC     // (in) - ������ ����������� ������������� ������ ������ � ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* settlementCurrency                                       // (in) - ������ ��������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValue* lsRestrictMV                            // (in) - ������ ����������� ������������� ������ ������ ��� ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
); 

QDEALERAPI_API int _stdcall QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - ��� �����
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, const char* settlementCurrency                                       // (in) - ������ ��������
);

QDEALERAPI_API int _stdcall QDAPI_GetRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency** lsRestrictMVSC    // (out) - ������ ����������� ������������� ������ ������ � ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* settlementCurrency                                       // (in) - ������ ��������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValue** lsRestrictMV                           // (out) - ������ ����������� ������������� ������ ������ ��� ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictMaxValueForSettlementCurrencyToRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency* lsRestrictMVSC     // (in) - ������ ����������� ������������� ������ ������ � ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, const char* settlementCurrency                                       // (in) - ������ ��������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, QDAPI_ArrayRestrictMaxValue* lsRestrictMV                            // (in) - ������ ����������� ������������� ������ ������ ��� ������ �������� 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - ��� �����
	, const char* templateCode                                             // (in) - ��� �������
	, QDAPI_SettingsScope settingsScope                                    // (in) - ��� ��������
	, const char* settlementCurrency                                       // (in) - ������ ��������
);
#pragma endregion

#pragma region
//QDealerAPI 1.12 (��������� � ����������  ������� ���������)

//��������� �������
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* templateName                                                  // (in) � ��� �������
	, QDAPI_ArrayStrings** lsClasses);                                            // (out) - ������ �������

QDEALERAPI_API int _stdcall QDAPI_AddClassToInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* templateName                                                  // (in) � ��� �������
	, const char* classCode);                                                   // (in) � ��� ������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* templateName                                                  // (in) � ��� �������
	, const char* classCode);                                                   // (in) � ��� ������

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* templateName                                                  // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, QDAPI_ArrayStrings** lsInstruments);                                        // (out) ������� ������������

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* templateName                                                  // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, const char* secCode);                                                     // (in)  - ��� �����������

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* templateName                                                  // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, const QDAPI_ArrayStrings* lsInstruments);                                   // (in) � ������ ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* templateName                                                  // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, const char* secCode);                                                     // (in) � ��� �����������

//���������� �������

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* clientCode                                                    // (in) � ��� �������
	, QDAPI_ArrayStrings** lsClasses);                                            // (out)  - ������ �������

QDEALERAPI_API int _stdcall QDAPI_AddClassToInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* clientCode                                                    // (in) � ��� �������
	, const char* classCode);                                                   // (in) � ��� ������

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* clientCode                                                    // (in) � ��� �������
	, const char* classCode);                                                   // (in) � ��� ������

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* clientCode                                                    // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, QDAPI_ArrayStrings** lsInstruments);                                        // (out) ������� ������������

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* clientCode                                                    // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, const char* secCode);                                                     // (in)  - ��� �����������

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* clientCode                                                    // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, const QDAPI_ArrayStrings* lsInstruments);                                   // (in) � ������ ������������

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) � ��� �����
	, const char* clientCode                                                    // (in) � ��� �������
	, const char* classCode                                                     // (in) � ��� ������
	, const char* secCode);                                                     // (in) � ��� �����������

#pragma endregion

#pragma region teriffPlanes
// ��������� ������ �������� ������ :
QDEALERAPI_API int _stdcall QDAPI_GetTPList(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_ArrayStrings** lsTarifPlans                                             // (out)- ������ �������� ������
);

// ��������� �������� ��������� ����� :
QDEALERAPI_API int _stdcall QDAPI_GetTPSettings(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* tPName,                                                         // (in) � ��� ��������� �����
	QDAPI_ArrayClassGroups** lsClassGroups                                         // (out) � ������ ������� � �����������
);

// �������� ��������� ����� :
QDEALERAPI_API int _stdcall QDAPI_RemoveTPSettings(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* tPName                                                          // (in) � ��� ��������� �����
);

// ���������� �������� ��� ���������� ��������� ����� :
QDEALERAPI_API int _stdcall QDAPI_SetTPSettings(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* tPName,                                                         // (in) � ��� ��������� �����
	QDAPI_ArrayClassGroups* lsClassGroups                                          // (in) � ������ ������� � �����������
);

#pragma endregion teriffPlanes

#pragma region BrokerCommission
//��� ������ � ���������� ������������� ����� ��������:
QDEALERAPI_API int _stdcall QDAPI_GetUseCommissionScaleFromGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	bool* useCommissionScale);                                                  // (out) -�������� ���������

QDEALERAPI_API int _stdcall QDAPI_SetUseCommissionScaleToGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	bool useCommissionScale);                                                   // (in) -�������� ���������

//��� ������ � ���������� ������ �������� � ���������� �� �������:
QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleJumpFromGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	bool* useCommissionScaleJump);                                              // (out) -�������� ���������

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleJumpToGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	bool useCommissionScaleJump);                                               // (in) -�������� ���������

//��� ������ � ����������� ������������� ���������, ������������ ��������� � ������������ ������ :
QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRestrictionsFromGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_ScaleCommExParams** minMaxTurnover);                                  // (out) -������������ ��������, ����������� ��������, ����������� ������

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRestrictionsToGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_ScaleCommExParams* minMaxTurnover);                                   // (in) -������������ ��������, ����������� ��������, ����������� ������

//��� ������ �� �������� ����� ��������(��������� �������(� ��������� ��� �� ������) � �������(� ��������� ��� ������� ��������)):
QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRatesFromGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_ArrayOfScaleRates** lsScalesAndRates);                                // (out) � ���������� �������� ����� � �������� (����� �������, ������)

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRatesToGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_ArrayOfScaleRates* lsScalesAndRates);                                 // (in) � ���������� �������� ����� � �������� (����� �������, ������)

QDEALERAPI_API int _stdcall QDAPI_RemoveCommissionScaleFromGlobal(
	const char* firmCode);                                                      // (in) � ��� �����

#pragma endregion BrokerCommission

#pragma region ProhibitREPOByFirstPartSideAndTerm
// ����������� ��� �������� �����������
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromSecurityAllowedRestrictionTemplate(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* templateCode,                                                   // (in) � ��� �������
	QDAPI_ArrayStrings** lsInstruments                                          // (out) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentListFromSecurityAllowedRestrictionTemplate(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* templateCode,                                                   // (in) � ��� �������
	QDAPI_ArrayStrings* lsInstruments                                           // (in) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromSecurityAllowedRestrictionTemplate(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* templateCode                                                    // (in) � ��� �������
);

//����������� ��� �������� �����������

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromSecurityRestrictedRestrictionTemplate(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* templateCode,                                                   // (in) � ��� �������
	QDAPI_SettingsScope settingsScope                                           // (in) ��� ��������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromSecurityRestrictedGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_SettingsScope settingsScope                                           // (in) ��� ��������
);

//������ ������ ���� �� ����������� ������ ����� � ����� ����
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate(
	const char* firmCode,                                                       // (in) � ��� �����
	const char* templateCode,                                                   // (in) � ��� ������
	QDAPI_SettingsScope settingsScope,                                          // (in) ��� ��������
	QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm** lsProhibitedREPOInstruments // (out) � ������ ������������ � �������������, ������������� ������� 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_SettingsScope settingsScope,                                          // (in) ��� ��������
	QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm** lsProhibitedREPOInstruments // (out) � ������ ������������ � �������������, ������������� ������� 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_SettingsScope settingsScope,                                          // (in) ��� ��������
	const char* templateCode                                                    // (in) � ��� �������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermGlobal(
	const char* firmCode,                                                       // (in) � ��� �����
	QDAPI_SettingsScope settingsScope                                           // (in) ��� ��������
);
#pragma endregion ProhibitREPOByFirstPartSideAndTerm

#pragma region RestrictOpenSecurity
// ���������� ���������
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  � ��� �����
	QDAPI_ArrayStrings** lsClassCodes                                           // (out) - ������ �������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* classCode,                                                      // (in)  � ��� ������
	QDAPI_ArrayStrings** lsInstruments                                          // (out) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* classCode,                                                      // (in)  � ��� ������
	QDAPI_ArrayStrings* lsInstruments                                           // (in)  � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* classCode                                                       // (in)  � ��� ������
);

//��������� � �������� ��� ��������
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* templateName,                                                   // (in)  � ��� ������� �� ��������
	QDAPI_ArrayStrings** lsClassCodes                                           // (out) - ������ �������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* templateName,                                                   // (in)  � ��� ������� �� ��������
	const char* classCode,                                                      // (in)  � ��� ������
	QDAPI_ArrayStrings** lsInstruments                                          // (out) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* templateName,                                                   // (in)  � ��� ������� �� ��������
	const char* classCode,                                                      // (in)  � ��� ������
	QDAPI_ArrayStrings* lsInstruments                                           // (in)  � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* templateName,                                                   // (in)  � ��� ������� �� ��������
	const char* classCode                                                       // (in)  � ��� ������
);

// ��������� �� ��� ������� ��� ������� ���� �������
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* clientCode,                                                     // (in)  � ��� �������
	QDAPI_ArrayStrings** lsClassCodes                                           // (out) - ������ �������
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* clientCode,                                                     // (in)  � ��� �������
	const char* classCode,                                                      // (in)  � ��� ������
	QDAPI_ArrayStrings** lsInstruments                                          // (out) � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* clientCode,                                                     // (in)  � ��� �������
	const char* classCode,                                                      // (in)  � ��� ������
	QDAPI_ArrayStrings* lsInstruments                                           // (in)  � ������ ������������
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  � ��� �����
	const char* clientCode,                                                     // (in)  � ��� �������
	const char* classCode                                                       // (in)  � ��� ������
);

#pragma endregion RestrictOpenSecurity

#pragma region ComplexInstruments

QDEALERAPI_API int _stdcall QDAPI_GetComplexInstrumentsAccessControlFromGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	bool* value);                                                               // (out) - �������� ���������

QDEALERAPI_API int _stdcall QDAPI_SetComplexInstrumentsAccessControlToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	bool value);                                                                // (out) - �������� ���������

QDEALERAPI_API int _stdcall QDAPI_GetComplexFIApprovedClientsFromGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	const char* clientCode,                                                     // (in) - ��� �������, ���� �����, �� �������� ������ �� 1 
	                                                                            //        ������ � ������������ ��� ������� �������, ���� nullptr, �� ������ ������
	QDAPI_ArrayClientFIApproves** lsApproves);                                  // (out) - ������ ���������� �� ��������/���� ������ ��� ��������� �������

QDEALERAPI_API int _stdcall QDAPI_AddComplexFIApprovedClientsToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayClientFIApproves* lsApproves);                                   // (in) - ������ ��������������� ����������

//������ ������� ����������� ��� ���������
QDEALERAPI_API int _stdcall QDAPI_SetComplexFIApprovedClientsToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayClientFIApproves* lsApproves);                                   // (in) - ������ ��������������� ���������� 

QDEALERAPI_API int _stdcall QDAPI_RemoveComplexFIApprovedClientsFromGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	const char* clientCode);                                                    // (in) - ��� �������

QDEALERAPI_API int _stdcall QDAPI_GetQualifiedInvestorsSignFromRestrictionTemplate(
	const char* firmCode,                                                       // (in) - ��� �����
	const char* templateCode,                                                   // (in) - ��� �������
	bool* value);                                                               // (out) - �������� ���������

QDEALERAPI_API int _stdcall QDAPI_SetQualifiedInvestorsSignToRestrictionTemplate(
	const char* firmCode,                                                       // (in) - ��� �����
	const char* templateCode,                                                   // (in) - ��� �������
	bool value);                                                                // (in) - �������� ���������

QDEALERAPI_API int _stdcall QDAPI_GetAccessToComplexInstrumentsFromRestrictionTemplate(
	const char* firmCode,                                                       // (in) - ��� �����
	const char* templateCode,                                                   // (in) -  ��� �������
	QDAPI_ArrayStrings** lsApproves);                                           // (out) - ������ ����������

QDEALERAPI_API int _stdcall QDAPI_SetAccessToComplexInstrumentsToRestrictionTemplate(
	const char* firmCode,                                                       // (in) - ��� �����
	const char* templateCode,                                                   // (in) - ��� �������
	QDAPI_ArrayStrings* lsApproves);                                            // (in)  -������ ����������

QDEALERAPI_API int _stdcall QDAPI_GetComplexInstrumentsFromGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	const char* complexityType,                                                 // (in) - ��� ���������, ����� ���� nullptr, ����� ������������ ������ ���� ������������, 
	                                                                            //        ����� ������ ��������� ��� ������� ���� ���������
	QDAPI_ArrayComplexInstruments** lsComplexSecs);                             // (out) - ������ c������ ������������ �� �������

QDEALERAPI_API int _stdcall QDAPI_AddComplexInstrumentsToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayComplexInstruments* lsComplexSecs);                              // (in) - ������ ������� ������������ �� �������

// ����������� ��������� �������
QDEALERAPI_API int _stdcall QDAPI_SetComplexInstrumentsToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayComplexInstruments* lsComplexSecs);                              // (in) - ������ ������� ������������ �� �������

QDEALERAPI_API int _stdcall QDAPI_RemoveComplexInstrumentsFromGlobal(
	const char* firmCode,                                                       // (in) -  ��� �����
	const char* complexityType);                                                // (in) - ��� ���������


QDEALERAPI_API int _stdcall QDAPI_GetClientCvalSignFromGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	bool* value);                                                               // (out) -�������� ���������

QDEALERAPI_API int _stdcall QDAPI_SetClientCvalSignToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	bool value);                                                                // (out) - �������� ���������

QDEALERAPI_API int _stdcall QDAPI_GetClientCvalListFromGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayStrings** lsClients);                                            // (out) - ������ ���������� ������� ����� ������������ ��������������� 
	                                                                            // ��������� �������� �� ���������

QDEALERAPI_API int _stdcall QDAPI_SetClientCvalListToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayStrings* lsClients);                                             // (out) - ������ ���������� ������� ����� ������������ ��������������� 
	                                                                            // ��������� �������� �� ���������

QDEALERAPI_API int _stdcall QDAPI_GetComplexInstrumentsTypesWithoutRestrictionsFromGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayStrings** instrumentsTypes);                                     // (out) - ������ ����� ������������ ��� ����������� ��� ������������������� ����������

QDEALERAPI_API int _stdcall QDAPI_SetComplexInstrumentsTypesWithoutRestrictionsToGlobal(
	const char* firmCode,                                                       // (in) - ��� �����
	QDAPI_ArrayStrings* instrumentsTypes);                                      // (in) - ������ ����� ������������ ��� ����������� ��� ������������������� ����������

QDEALERAPI_API int _stdcall QDAPI_RemoveComplexInstrumentsTypesWithoutRestrictionsFromGlobal(
	const char* firmCode);                                                      // (in) - ��� �����



#pragma endregion ComplexInstruments

#pragma region RestrictionTemplate -> IncludeClientsWithLeverage
// ��������� ������ �������� ���� �� ��������� ��������� � ������ �������� �� ��������� ����� � ���������� ������� ��� ������������.
// ���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ���� �������� ����� �� ������ � ������������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_GetIncludeClientsWithLeverageFromRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� ������� ��� �����
	, QDAPI_ArrayDoubleNumbers** lsLeverages);                              // (out) ��������� �����

// ������� ������ �������� ���� � ��������� ��������� � ������ �������� �� ��������� ����� � ���������� ������� ��� ������������.
// ���� ������ �� ���������� � ������������ ������ QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// ��� ������� ������� �����, ������������ �� ��������� � ������ ������� ���� �� ����, ������������ ������ QDAPI_ERROR_DATA_ALREADY_EXIST. 
// ������� ����� ��������� ���������� �������� ���������, ��� ���� ���������� ������ ������ ������.
QDEALERAPI_API int _stdcall QDAPI_SetIncludeClientsWithLeverageToRestrictionTemplate(
	const char* firmCode                                                    // (in) ��� �����
	, const char* templateCode                                              // (in) ��� ������� ��� �����
	, const QDAPI_ArrayDoubleNumbers* lsLeverages);                         // (in) ��������� �����
#pragma endregion

#pragma endregion RestrictionTemplate -> IncludeClientsWithLeverage
#endif // QDEALERAPI_H