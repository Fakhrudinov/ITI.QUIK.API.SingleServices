using System;
using System.Runtime.InteropServices;

namespace QDealerAPI
{
#if X64
    using size_t = UInt64;
#else
    using size_t = UInt32;
#endif
    public static class Constants
	{
		public static readonly string ALL_CLASSES = "<ALL>";
		public static readonly string ALL_INSTRUMENTS = "<ALL>";
		public static readonly string ALL_CLIENTS = "<ALL>";
		public static readonly string ALL_REPO = "<ALL_REPO>";
		public static readonly string ALL_NDM = "<ALL_NDM>";
		public static readonly string ALL_REPO_CCP = "<ALL_REPO_CCP>";
		public static readonly string ALL_NDM_CCP = "<ALL_NDM_CCP>";
	}

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayIntNumbers
	{
		/// size_t
		public size_t count;

		/// int*
		public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayStrings
	{

		/// size_t
		public size_t count;

        /// char**
        public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_StringToString
	{

		/// char*
		[MarshalAsAttribute(UnmanagedType.LPStr)]
		public string fst;

		/// char*
		[MarshalAsAttribute(UnmanagedType.LPStr)]
		public string snd;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_RestrictOptionOrdersBody
	{

		/// int
		public int day;

		/// int
		public int month;

		/// int
		public int year;

		/// double
		public double max_dev_strike;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_RestrictOptionOrders
	{

		/// char*
		[MarshalAsAttribute(UnmanagedType.LPStr)]
		public string base_asset;

		/// QDAPI_RestrictOptionOrdersBody
		public QDAPI_RestrictOptionOrdersBody restrBody;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayRestrictOptionOrders
	{

		/// size_t
		public size_t count;

		/// QDAPI_RestrictOptionOrders*
		public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_Discounts
	{

		/// double
		public double KLong;

		/// double
		public double KShort;

		/// double
		public double DLong;

		/// double
		public double DShort;

		/// double
		public double DLong_min;

		/// double
		public double DShort_min;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_PriceTypeAndPercent
	{

		/// QDAPI_PriceType
		public QDAPI_PriceType priceType;

		/// double
		public double deviationPercent;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_PriceLimit
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string activeCode;

		/// QDAPI_PriceType
		public QDAPI_PriceType priceType;

		/// double
		public double deviationPercent;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayPriceLimit
	{

		/// size_t
		public size_t count;

		/// QDAPI_PriceLimit*
		public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_VolumeRestriction
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string classCode;

		/// double
		public double restPercent;

		/// double
		public double alertPercent;

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string valuationClass;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayVolumeRestriction
	{

		/// size_t
		public size_t count;

		/// QDAPI_VolumeRestriction*
		public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_SecurityBySide
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string secCode;

		/// QDAPI_OperationSide
		public QDAPI_OperationSide side;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArraySecurityBySide
	{

		/// size_t
		public size_t count;

		/// QDAPI_SecurityBySide*
		public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_ClassBySide
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string classCode;

		/// QDAPI_OperationSide
		public QDAPI_OperationSide side;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayClassBySide
	{

		/// size_t
		public size_t count;

		/// QDAPI_ClassBySide*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_VolumeRestrictionByAvgTurnover
	{

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings classList;

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings instrList;

		/// double
		public double restPercent;

		/// double
		public double alertPercent;

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string valuationClass;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayVolumeRestrictionByAvgTurnover
	{

		/// size_t
		public size_t count;

		/// QDAPI_VolumeRestrictionByAvgTurnover*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_AdditionalSpotActive
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string spotCode;

		/// double
		public double lotRatio;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArraySpotListForBaseAsset
	{

		/// size_t
		public size_t count;

		/// QDAPI_AdditionalSpotActive*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_MainSettingsOfPortfolioRiskConfigGlobal
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string boardTag;

		/// char[4]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
		public string currency;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isLimitKind;

		/// int
		public int limitKind;

		/// int
		public int optionLiquidationValueByTheoreticalPrice;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isPortfolioValueMode;

		/// QDAPI_PortfolioValueMode
		public QDAPI_PortfolioValueMode portfolioValueMode;

		/// int
		public int useFullPortfolioValue;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_SpreadTier
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string tierName;

		/// int
		public int tierTerm;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayOfSpreadTiers
	{

		/// size_t
		public size_t count;

		/// QDAPI_SpreadTier*
		public System.IntPtr elems;
	}

	public enum QDAPI_Errors
	{

		/// QDAPI_ERROR_SUCCESS -> 0
		QDAPI_ERROR_SUCCESS = 0,

		/// QDAPI_ERROR_QADMINSRV -> 1
		QDAPI_ERROR_QADMINSRV = 1,

		/// QDAPI_ERROR_NOT_INITIALIZED -> 2
		QDAPI_ERROR_NOT_INITIALIZED = 2,

		/// QDAPI_ERROR_CONNECT_FAILED -> 3
		QDAPI_ERROR_CONNECT_FAILED = 3,
		/// QDAPI_ERROR_CONNECT_ALREADYUSE -> 4
		QDAPI_ERROR_CONNECT_ALREADYUSE = 4,

		/// QDAPI_ERROR_NOT_CONNECTED -> 5
		QDAPI_ERROR_NOT_CONNECTED = 5,

		/// QDAPI_ERROR_TIMEOUT -> 6
		QDAPI_ERROR_TIMEOUT = 6,

		/// QDAPI_ERROR_CONNECTION_LOST -> 7
		QDAPI_ERROR_CONNECTION_LOST = 7,

		/// QDAPI_ERROR_NO_RIGHTS -> 8
		QDAPI_ERROR_NO_RIGHTS = 8,

		/// QDAPI_ERROR_DL_NOT_FOUND -> 9
		QDAPI_ERROR_DL_NOT_FOUND = 9,

		/// QDAPI_ERROR_DL_READ_PROHIBITED -> 10
		QDAPI_ERROR_DL_READ_PROHIBITED = 10,

		/// QDAPI_ERROR_DL_WRITE_PROHIBITED -> 11
		QDAPI_ERROR_DL_WRITE_PROHIBITED = 11,

		/// QDAPI_ERROR_DL_WRITE_NOT_AVAILABLE -> 12
		QDAPI_ERROR_DL_WRITE_NOT_AVAILABLE = 12,

		/// QDAPI_ERROR_UNCLASSIFIED -> 1001
		QDAPI_ERROR_UNCLASSIFIED = 1001,

		/// QDAPI_ERROR_NOT_LOADED_SETTINGS_FOR_FIRM -> 1002
		QDAPI_ERROR_NOT_LOADED_SETTINGS_FOR_FIRM = 1002,

		/// QDAPI_ERROR_INCORRECT_PARAMETER -> 1003
		QDAPI_ERROR_INCORRECT_PARAMETER = 1003,

		/// QDAPI_ERROR_DATA_NOT_FOUND -> 1004
		QDAPI_ERROR_DATA_NOT_FOUND = 1004,

		/// QDAPI_ERROR_FAILED_RELEASE_MEMORY -> 1005
		QDAPI_ERROR_FAILED_RELEASE_MEMORY = 1005,

		/// QDAPI_ERROR_IMPOSSIBLE_ALLOCATE_MEMORY -> 1006
		QDAPI_ERROR_IMPOSSIBLE_ALLOCATE_MEMORY = 1006,

		/// QDAPI_ERROR_IMPOSSIBLE_OPEN_FILE -> 1007
		QDAPI_ERROR_IMPOSSIBLE_OPEN_FILE = 1007,

		/// QDAPI_ERROR_IMPOSSIBLE_CLOSE_FILE -> 1008
		QDAPI_ERROR_IMPOSSIBLE_CLOSE_FILE = 1008,

		/// QDAPI_ERROR_NO_VALID_LENGTH_CLASS_CODE -> 1009
		QDAPI_ERROR_NO_VALID_LENGTH_CLASS_CODE = 1009,

		/// QDAPI_ERROR_NO_VALID_LENGTH_CLIENT_CODE -> 1010
		QDAPI_ERROR_NO_VALID_LENGTH_CLIENT_CODE = 1010,

		/// QDAPI_ERROR_NO_VALID_LENGTH_CURR_CODE -> 1011
		QDAPI_ERROR_NO_VALID_LENGTH_CURR_CODE = 1011,

		/// QDAPI_ERROR_NO_VALID_LENGTH_FIRM_CODE -> 1012
		QDAPI_ERROR_NO_VALID_LENGTH_FIRM_CODE = 1012,

		/// QDAPI_ERROR_NO_VALID_LENGTH_SEC_CODE -> 1013
		QDAPI_ERROR_NO_VALID_LENGTH_SEC_CODE = 1013,

		/// QDAPI_ERROR_NO_VALID_LENGTH_TRADE_ACCOUNT -> 1014
		QDAPI_ERROR_NO_VALID_LENGTH_TRADE_ACCOUNT = 1014,

		/// QDAPI_ERROR_TEMPLATE_NOT_FOUND -> 1015
		QDAPI_ERROR_TEMPLATE_NOT_FOUND = 1015,

		/// QDAPI_ERROR_DATA_ALREADY_EXIST -> 1016
		QDAPI_ERROR_DATA_ALREADY_EXIST = 1016,

		/// QDAPI_ERROR_NO_VALID_LENGTH_PARTNER_CODE -> 1017
		QDAPI_ERROR_NO_VALID_LENGTH_PARTNER_CODE = 1017,

		/// QDAPI_ERROR_NO_VALID_LENGTH_SETTLE_CODE -> 1018
		QDAPI_ERROR_NO_VALID_LENGTH_SETTLE_CODE = 1018,

		/// QDAPI_ERROR_NOT_SUPPORTED -> 1019
		QDAPI_ERROR_NOT_SUPPORTED = 1019,

		/// QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND -> 1020
		QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND = 1020,

		/// QDAPI_ERRORS_NO_VALID_LENGTH_TEMPLATE_CODE -> 1021
		QDAPI_ERRORS_NO_VALID_LENGTH_TEMPLATE_CODE = 1021,

		/// QDAPI_ERROR_NOT_VALID_LENGTH_TAG_CODE -> 1022
		QDAPI_ERROR_NOT_VALID_LENGTH_TAG_CODE = 1022,
	}

	public enum QDAPI_SettingsScope
	{
		/// QDAPI_SETTINGS_SCOPE_MAIN -> 0
		QDAPI_SETTINGS_SCOPE_MAIN = 0,

		/// QDAPI_SETTINGS_SCOPE_ADDITIONAL -> 1
		QDAPI_SETTINGS_SCOPE_ADDITIONAL = 1,
	}

	public enum QDAPI_PriceType
	{

		/// QDAPI_PRICE_TYPE__DEFAULT -> 0
		QDAPI_PRICE_TYPE__DEFAULT = 0,

		/// QDAPI_PRICE_TYPE__WAPRICE -> 1
		QDAPI_PRICE_TYPE__WAPRICE = 1,

		/// QDAPI_PRICE_TYPE__LAST -> 2
		QDAPI_PRICE_TYPE__LAST = 2,

		/// QDAPI_PRICE_TYPE__OPEN -> 3
		QDAPI_PRICE_TYPE__OPEN = 3,

		/// QDAPI_PRICE_TYPE__MARKETPRICE -> 4
		QDAPI_PRICE_TYPE__MARKETPRICE = 4,

		/// QDAPI_PRICE_TYPE__PREVPRICE -> 5
		QDAPI_PRICE_TYPE__PREVPRICE = 5,

		/// QDAPI_PRICE_TYPE__THEORPRICE -> 6
		QDAPI_PRICE_TYPE__THEORPRICE = 6,

		QDAPI_PRICE_TYPES_COUNT,
	}

	public enum QDAPI_OperationSide
	{

		/// QDAPI_SIDE_NOT_CONSIDERED -> 0
		QDAPI_SIDE_NOT_CONSIDERED = 0,

		/// QDAPI_SIDE_ANY -> 1
		QDAPI_SIDE_ANY = 1,

		/// QDAPI_SIDE_BUY -> 2
		QDAPI_SIDE_BUY = 2,

		/// QDAPI_SIDE_SELL -> 3
		QDAPI_SIDE_SELL = 3,
	}
	public enum QDAPI_PortfolioValueMode
	{

		/// QDAPI_PORTFOLIO_VALUE_MODE_NO_VARMARGIN -> 0
		QDAPI_PORTFOLIO_VALUE_MODE_NO_VARMARGIN = 0,

		/// QDAPI_PORTFOLIO_VALUE_MODE_ADD_POSITIVE_VARMARGIN -> 1
		QDAPI_PORTFOLIO_VALUE_MODE_ADD_POSITIVE_VARMARGIN = 1,

		/// QDAPI_PORTFOLIO_VALUE_MODE_ADD_NEGATIVE_VARMARGIN -> 2
		QDAPI_PORTFOLIO_VALUE_MODE_ADD_NEGATIVE_VARMARGIN = 2,

		/// QDAPI_PORTFOLIO_VALUE_MODE_ADD_ALL_VARMARGIN -> 3
		QDAPI_PORTFOLIO_VALUE_MODE_ADD_ALL_VARMARGIN = 3,
	}
	public enum QDAPI_VolatilityType
	{

		/// QDAPI_VOLATILITY_TYPE_FROM_SETTINGS -> 0
		QDAPI_VOLATILITY_TYPE_FROM_SETTINGS = 0,

		/// QDAPI_VOLATILITY_TYPE_FROM_TS -> 1
		QDAPI_VOLATILITY_TYPE_FROM_TS = 1,
	}
	public enum QDAPI_OptionDeltaType
	{

		/// QDAPI_OPTION_DELTA_TYPE_AVERAGE -> 0
		QDAPI_OPTION_DELTA_TYPE_AVERAGE = 0,

		/// QDAPI_OPTION_DELTA_TYPE_BY_MAX_RISK_SCENARIO -> 1
		QDAPI_OPTION_DELTA_TYPE_BY_MAX_RISK_SCENARIO = 1,
	}
	public enum QDAPI_OrderLimitationMode
	{

		/// QDAPI_ORDER_LIMITATION_MODE_WITHOUT_NETTING -> 0
		QDAPI_ORDER_LIMITATION_MODE_WITHOUT_NETTING = 0,

		/// QDAPI_ORDER_LIMITATION_MODE_ACCOUNT_SPREAD_LIQUIDATION -> 1
		QDAPI_ORDER_LIMITATION_MODE_ACCOUNT_SPREAD_LIQUIDATION = 1,

		/// QDAPI_ORDER_LIMITATION_MODE_ACCOUNT_SPREAD_FORMATION -> 2
		QDAPI_ORDER_LIMITATION_MODE_ACCOUNT_SPREAD_FORMATION = 2,
	}
	public enum QDAPI_PriceScanRangeType
	{

		/// QDAPI_PRICE_SCAN_RANGE_TYPE_CLEARING_PRICE_PERCENT -> 0
		QDAPI_PRICE_SCAN_RANGE_TYPE_CLEARING_PRICE_PERCENT = 0,

		/// QDAPI_PRICE_SCAN_RANGE_TYPE_MONEY -> 1
		QDAPI_PRICE_SCAN_RANGE_TYPE_MONEY = 1,

		/// QDAPI_PRICE_SCAN_RANGE_TYPE_FUTURE_COLLATERAL -> 2
		QDAPI_PRICE_SCAN_RANGE_TYPE_FUTURE_COLLATERAL = 2,
	}
	public enum QDAPI_OptionType
	{

		/// QDAPI_OPTION_TYPE_LONG_CALL -> 0
		QDAPI_OPTION_TYPE_LONG_CALL = 0,

		/// QDAPI_OPTION_TYPE_SHORT_CALL -> 1
		QDAPI_OPTION_TYPE_SHORT_CALL = 1,

		/// QDAPI_OPTION_TYPE_LONG_PUT -> 2
		QDAPI_OPTION_TYPE_LONG_PUT = 2,

		/// QDAPI_OPTION_TYPE_SHORT_PUT -> 3
		QDAPI_OPTION_TYPE_SHORT_PUT = 3,
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_SpreadRatio
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string firstTier;

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string secondTier;

		/// double
		public double longRate;

		/// double
		public double shortRate;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_InterSpread
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string baseAsset;

		/// QDAPI_SpreadRatio
		public QDAPI_SpreadRatio spreadRatio;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayInterSpread
	{

		/// size_t
		public size_t count;

		/// QDAPI_InterSpread*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayIntraSpread
	{

		/// size_t
		public size_t count;

		/// QDAPI_SpreadRatio*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_VolatilitySlope
	{

		/// QDAPI_OptionType
		public QDAPI_OptionType optionType;

		/// double
		public double strikeDeviation;

		/// double
		public double volatilityRatio;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayVolatilitySlope
	{

		/// size_t
		public size_t count;

		/// QDAPI_VolatilitySlope*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_PortfolioRiskConfigSettings
	{

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isBoundaryImpliedRisk;

		/// double
		public double boundaryImpliedRisk;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isBoundaryPriceChange;

		/// double
		public double boundaryPriceChange;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isExpMatDateTerm;

		/// double
		public double expMatDateTerm;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isFuturesLiquidityFactor;

		/// double
		public double futuresLiquidityFactor;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isKGO;

		/// double
		public double KGO;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isMinShortOptionsIM;

		/// double
		public double minShortOptionsIM;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isOptionDeltaType;

		/// QDAPI_OptionDeltaType
		public QDAPI_OptionDeltaType optionDeltaType;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isOrderKGO;

		/// double
		public double orderKGO;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isOrderLimitationMode;

		/// QDAPI_OrderLimitationMode
		public QDAPI_OrderLimitationMode orderLimitationMode;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isPriceScanRange;

		/// double
		public double priceScanRange;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isPriceScanRangeType;

		/// QDAPI_PriceScanRangeType
		public QDAPI_PriceScanRangeType priceScanRangeType;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isRestrictMaxVolatility;

		/// double
		public double restrictMaxVolatility;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isRiskFreeRate;

		/// double
		public double riskFreeRate;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isSpotVarMarginNeg;

		/// double
		public double spotVarMarginNeg;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isSpotVarMarginPos;

		/// double
		public double spotVarMarginPos;

		/// QDAPI_ArrayInterSpread
		public QDAPI_ArrayInterSpread interSpread;

		/// QDAPI_ArrayIntraSpread
		public QDAPI_ArrayIntraSpread intraSpread;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isUseSpotNetting;

		/// int
		public int useSpotNetting;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isVolatility;

		/// double
		public double volatility;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isVolatilityChange;

		/// double
		public double volatilityChange;

		/// QDAPI_ArrayVolatilitySlope
		public QDAPI_ArrayVolatilitySlope volatilitySlope;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isVolatilityType;

		/// QDAPI_VolatilityType
		public QDAPI_VolatilityType volatilityType;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_PortfolioRiskConfigTemplateIdentifier
	{
		/// char*
		[MarshalAsAttribute(UnmanagedType.LPStr)]
		public string templateCode;

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string mainAsset;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayPortfolioRiskConfigTemplateIdentifier
	{

		/// size_t
		public size_t count;

		/// QDAPI_PortfolioRiskConfigTemplateIdentifier*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_BaseAssetsSpreadOrder
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string firstBaseAsset;

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string secondBaseAsset;

		/// int
		public int seqNumber;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayBaseAssetsSpreadOrder
	{

		/// size_t
		public size_t count;

		/// QDAPI_BaseAssetsSpreadOrder*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_RestrictSecurityByClass
	{

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsTradeAccounts;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isPeriodExists;

		/// int
		public int FromTimeHours;

		/// int
		public int FromTimeMinutes;

		/// int
		public int TillTimeHours;

		/// int
		public int TillTimeMinutes;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayRestrictSecurityByClass
	{

		/// size_t
		public size_t count;

		/// QDAPI_RestrictSecurityByClass*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_TranoutTag
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string nonTradeInstrument;

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string classCode;

		/// char[5]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
		public string currency;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayTranoutTag
	{

		/// size_t
		public size_t count;

		/// QDAPI_TranoutTag*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayDoubleNumbers
	{

		/// size_t
		public size_t count;

		/// double*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_MaxPositionLimit
	{

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsInstruments;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isLongPosLimit;

		/// Int64
		public Int64 longPosLimit;

		/// boolean
		[MarshalAsAttribute(UnmanagedType.I1)]
		public bool isShortPosLimit;

		/// Int64
		public Int64 shortPosLimit;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayMaxPositionLimit
	{

		/// size_t
		public size_t count;

		/// QDAPI_MaxPositionLimit*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_PartnersAndSettleCodesRestrictions
	{

		/// char[15]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 15)]
		public string classCode;

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsSettleCodes;

		/// QDAPI_OperationSide
		public QDAPI_OperationSide operationSide;

		/// int
		public Int64 maxTerm;

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsCP;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayPartnersAndSettleCodesRestrictions
	{

		/// size_t
		public size_t count;

		/// QDAPI_PartnersAndSettleCodesRestrictions*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_MinOrderQty
	{

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsClasses;

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsInstruments;

		/// long long
		public Int64 qty;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayMinOrderQty
	{

		/// size_t
		public size_t count;

		/// QDAPI_MinOrderQty*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_MinOrderValue
	{

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsClasses;

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsInstruments;

		/// double
		public double value;

		/// char[5]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
		public string currency;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayMinOrderValue
	{

		/// size_t
		public size_t count;

		/// QDAPI_MinOrderValue*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_ClassMinOrderQty
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string classCode;

		/// long long
		public Int64 qty;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayClassMinOrderQty
	{

		/// size_t
		public size_t count;

		/// QDAPI_ClassMinOrderQty*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_ClassMinOrderValue
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string classCode;

		/// double
		public double value;

		/// char[5]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
		public string currency;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayClassMinOrderValue
	{

		/// size_t
		public size_t count;

		/// QDAPI_ClassMinOrderValue*
		public System.IntPtr elems;
	}

	public enum QDAPI_CommissionType
	{

		/// QDAPI_COMMISSION_TYPE_FIXED -> 0
		QDAPI_COMMISSION_TYPE_FIXED = 0,

		/// QDAPI_COMMISSION_TYPE_TRADE_MAX -> 1
		QDAPI_COMMISSION_TYPE_TRADE_MAX = 1,

		/// QDAPI_COMMISSION_TYPE_TRADE_MIN -> 2
		QDAPI_COMMISSION_TYPE_TRADE_MIN = 2,

		QDAPI_COMMISSION_TYPE_COUNT,
	}

    public enum QDAPI_BrokCommType
    {

        /// QDAPI_BROK_COMM_TYPE_NO -> 0
        QDAPI_BROK_COMM_TYPE_NO = 0,

        /// QDAPI_BROK_COMM_TYPE_FIXED -> 1
        QDAPI_BROK_COMM_TYPE_FIXED = 1,

        /// QDAPI_BROK_COMM_TYPE_TURNOVER_SCALE -> 2
        QDAPI_BROK_COMM_TYPE_TURNOVER_SCALE = 2,

        /// QDAPI_BROK_COMM_TYPE_TRADE -> 3
        QDAPI_BROK_COMM_TYPE_TRADE = 3,

        /// QDAPI_BROK_COMM_TYPE_TRADE_FIXED_MAX -> 4
        QDAPI_BROK_COMM_TYPE_TRADE_FIXED_MAX = 4,

        /// QDAPI_BROK_COMM_TYPE_ONESEC -> 5
        QDAPI_BROK_COMM_TYPE_ONESEC = 5,

        /// QDAPI_BROK_COMM_TYPE_LOT -> 6
        QDAPI_BROK_COMM_TYPE_LOT = 6,

        /// QDAPI_BROK_COMM_TYPE_TRADE_LOT_MAX -> 7
        QDAPI_BROK_COMM_TYPE_TRADE_LOT_MAX = 7,

        QDAPI_BROK_COMM_TYPE_COUNT,
    }

    public enum QDAPI_BrokCommTypeByClasses
    {

        /// QDAPI_BROK_COMM_TYPE_BY_CLASSES_NO -> 0
        QDAPI_BROK_COMM_TYPE_BY_CLASSES_NO = 0,

        /// QDAPI_BROK_COMM_TYPE_BY_CLASSES_FIXED -> 1
        QDAPI_BROK_COMM_TYPE_BY_CLASSES_FIXED = 1,

        /// QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE -> 2
        QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE = 2,

        /// QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_FIXED_MAX -> 3
        QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_FIXED_MAX = 3,

        /// QDAPI_BROK_COMM_TYPE_BY_CLASSES_ONESEC -> 4
        QDAPI_BROK_COMM_TYPE_BY_CLASSES_ONESEC = 4,

        /// QDAPI_BROK_COMM_TYPE_BY_CLASSES_LOT -> 5
        QDAPI_BROK_COMM_TYPE_BY_CLASSES_LOT = 5,

        /// QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_LOT_MAX -> 6
        QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_LOT_MAX = 6,

        QDAPI_BROK_COMM_TYPE_BY_CLASSES_COUNT,
    }

    public enum QDAPI_ClientLagType
    {

        /// QDAPI_LAG_BY_LIMIT -> 1
        QDAPI_LAG_BY_LIMIT = 1,

        /// QDAPI_LAG_BY_LEVERAGE -> 2
        QDAPI_LAG_BY_LEVERAGE = 2,

        /// QDAPI_LAG_LIMIT_ON_OPEN_POSITION -> 3
        QDAPI_LAG_LIMIT_ON_OPEN_POSITION = 3,

        /// QDAPI_LAG_BY_DISCOUNTS -> 4
        QDAPI_LAG_BY_DISCOUNTS = 4,

        /// QDAPI_LAG_MDPLUS -> 5
        QDAPI_LAG_MDPLUS = 5,

        QDAPI_LAG_COUNT,
    }


    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_ClassListForCurrency
	{

		/// char[5]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
		public string currency;

		/// QDAPI_ArrayStrings
		public QDAPI_ArrayStrings lsClasses;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayClassListForCurrency
	{

		/// size_t
		public size_t count;

		/// QDAPI_ClassListForCurrency*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayOfStringArrays
	{

		/// size_t
		public size_t count;

		/// QDAPI_ArrayStrings*
		public System.IntPtr elems;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_VolumeBasedCommissionRates
	{

		/// double
		public double volume;

		/// QDAPI_OperationSide
		public QDAPI_OperationSide side;

		/// QDAPI_CommissionType
		public QDAPI_CommissionType commissionType;

		/// double
		public double rate1;

		/// double
		public double rate2;
	}
	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayOfVolumeBasedCommissionRates
	{

		/// size_t
		public size_t count;

		/// QDAPI_VolumeBasedCommissionRates*
		public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_GroupWithDependentPrices
	{

		/// char[256]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string groupName;

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string baseIndicator;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayGroupsWithDependentPrices
	{

		/// size_t
		public size_t count;

		/// QDAPI_GroupWithDependentPrices*
		public System.IntPtr elems;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
	public struct QDAPI_Instrument
	{

		/// char[13]
		[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
		public string secCode;

		/// double
		public double relativeRiskRate;

		/// int
		public int dependencyTrend;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
	public struct QDAPI_ArrayInstruments
	{

		/// size_t
		public size_t count;

		/// QDAPI_Instrument*
		public System.IntPtr elems;
	}

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_CommissionTypeAndRate
    {

        /// QDAPI_BrokCommType
        public QDAPI_BrokCommType commissionType;

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string TPName;

        /// double
        public double brokerCommissionRate;

        /// double
        public double tradeCommissionRate;

        /// double
        public double tradeLotCommissionRate;

        /// double
        public double oneSecCommissionRate;

        /// double
        public double repoBrokerRate;

        public QDAPI_CommissionTypeAndRate(QDAPI_BrokCommType commissionType, string TPName, double brokerCommissionRate
                , double tradeCommissionRate, double tradeLotCommissionRate, double oneSecCommissionRate, double repoBrokerRate)
        {
            this.commissionType = commissionType;
            this.TPName = TPName;
            this.brokerCommissionRate = brokerCommissionRate;
            this.tradeCommissionRate = tradeCommissionRate;
            this.tradeLotCommissionRate = tradeLotCommissionRate;
            this.oneSecCommissionRate = oneSecCommissionRate;
            this.repoBrokerRate = repoBrokerRate;
        }
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_ClassCommissionType
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string classCode;

        /// QDAPI_BrokCommTypeByClasses
        public QDAPI_BrokCommTypeByClasses commissionType;

        /// double
        public double rate1;

        /// double
        public double rate2;

        public QDAPI_ClassCommissionType(string classCode, QDAPI_BrokCommTypeByClasses commissionType, double rate1, double rate2)
        {
            this.classCode = classCode;
            this.commissionType = commissionType;
            this.rate1 = rate1;
            this.rate2 = rate2;
        }
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayClassCommissionType
    {

        /// size_t
        public size_t count;

        /// QDAPI_ClassCommissionType*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_BaseAssetCommissionRate
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string baseAsset;

        /// double
        public double rate;
        public QDAPI_BaseAssetCommissionRate(string baseAsset, double rate)
        {
            this.baseAsset = baseAsset;
            this.rate = rate;
        }
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayBaseAssetCommissionRate
    {

        /// size_t
        public size_t count;

        /// QDAPI_BaseAssetCommissionRate*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ScaleCommExParams
    {

        /// double
        public double minValue;

        /// double
        public double maxValue;

        /// double
        public double minTurnover;
        public QDAPI_ScaleCommExParams(double minValue, double maxValue, double minTurnover)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.minTurnover = minTurnover;
        }
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ScaleRate
    {

        /// double
        public double volume;

        /// double
        public double rate;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayOfScaleRates
    {

        /// size_t
        public size_t count;

        /// QDAPI_ScaleRate*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_SecWithWeightAndRestrictions
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string secCode;

        /// double
        public double longCoeff;

        /// double
        public double shortCoeff;

        /// double
        public double longRestriction;

        /// double
        public double shortRestriction;

        /// double
        public double maxVariancePercent;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_WeightAndRestrictionForSec
    {

        /// double
        public double longCoeff;

        /// double
        public double shortCoeff;

        /// double
        public double longRestriction;

        /// double
        public double shortRestriction;

        /// double
        public double maxVariancePercent;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_SecsWithWeightAndRestrictionsList
    {

        /// size_t
        public size_t count;

        /// QDAPI_SecWithWeightAndRestrictions*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_SecWithVariance
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string secCode;

        /// double
        public double maxVariancePercent;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_SecsWithVarianceList
    {

        /// size_t
        public size_t count;

        /// QDAPI_SecWithVariance*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_SecWithRestrictions
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string secCode;

        /// double
        public double longRestriction;

        /// double
        public double shortRestriction;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_SecsWithRestrictionsList
    {

        /// size_t
        public size_t count;

        /// QDAPI_SecWithRestrictions*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_SecWithCoeffs
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string secCode;

        /// double
        public double longCoeff;

        /// double
        public double shortCoeff;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_SecsWithCoeffsList
    {

        /// size_t
        public size_t count;

        /// QDAPI_SecWithCoeffs*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_ClientLag
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string clientCode;

        /// QDAPI_ClientLagType
        public QDAPI_ClientLagType clientLag;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayClientLag
    {

        /// size_t
        public size_t count;

        /// QDAPI_ClientLag*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_ClientCodeToTrdAcc
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string clientCode;

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string tradeAcc;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayClientCodeToTrdAcc
    {

        /// size_t
        public size_t count;

        /// QDAPI_ClientCodeToTrdAcc*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_ProhibitedCPAndSettlementCurrency
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string cP;

        /// char[5]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string settlementCurrency;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClassCodes;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsInstrumentCodes;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayProhibitedCPAndSettlementCurrency
    {

        /// size_t
        public size_t count;

        /// QDAPI_ProhibitedCPAndSettlementCurrency*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_ProhibitedSettlementCurrency
    {

        /// char[5]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string settlementCurrency;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClassCodes;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsInstrumentCodes;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayProhibitedSettlementCurrency
    {

        /// size_t
        public size_t count;

        /// QDAPI_ProhibitedSettlementCurrency*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_RestrictREPOWithCPBasedOnTerm
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string cP;

        /// char[5]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string settlementCurrency;

        /// char[5]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string faceValueCurrency;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClassCodes;

        /// int
        public int maxTerm;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayRestrictREPOWithCPBasedOnTerm
    {

        /// size_t
        public size_t count;

        /// QDAPI_RestrictREPOWithCPBasedOnTerm*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_RestrictREPOBasedOnTerm
    {

        /// char[5]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string settlementCurrency;

        /// char[5]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string faceValueCurrency;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClassCodes;

        /// int
        public int maxTerm;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayRestrictREPOBasedOnTerm
    {

        /// size_t
        public size_t count;

        /// QDAPI_RestrictREPOBasedOnTerm*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_RestrictMaxValueForSettlementCurrency
    {

        /// char[5]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string settlementCurrency;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClassCodes;

        /// QDAPI_OperationSide
        public QDAPI_OperationSide side;

        /// double
        public double maxValue;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayRestrictMaxValueForSettlementCurrency
    {

        /// size_t
        public size_t count;

        /// QDAPI_RestrictMaxValueForSettlementCurrency*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_RestrictMaxValue
    {

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClassCodes;

        /// QDAPI_OperationSide
        public QDAPI_OperationSide side;

        /// double
        public double maxValue;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayRestrictMaxValue
    {

        /// size_t
        public size_t count;

        /// QDAPI_RestrictMaxValue*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_REPOBySideToTerm
    {

        /// boolean
        [MarshalAsAttribute(UnmanagedType.I1)]
        public bool isSideUsed;

        /// QDAPI_ArrayIntNumbers
        public QDAPI_ArrayIntNumbers maxTerms;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct QDAPI_ProhibitREPOByFirstPartSideAndTerm
    {

        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string secCode;

        /// QDAPI_REPOBySideToTerm
        public QDAPI_REPOBySideToTerm TermByAny;

        /// QDAPI_REPOBySideToTerm
        public QDAPI_REPOBySideToTerm TermByBuy;

        /// QDAPI_REPOBySideToTerm
        public QDAPI_REPOBySideToTerm TermBySell;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm
    {

        /// size_t
        public size_t count;

        /// QDAPI_ProhibitREPOByFirstPartSideAndTerm*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ClassGroupWithScale
    {

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClassCodes;

        /// QDAPI_ScaleCommExParams
        public QDAPI_ScaleCommExParams scaleParams;

        /// QDAPI_ArrayOfScaleRates
        public QDAPI_ArrayOfScaleRates scaleRates;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayClassGroups
    {

        /// size_t
        public size_t count;

        /// QDAPI_ClassGroupWithScale*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet=CharSet.Ansi)]
    public struct QDAPI_ComplexInstruments 
    {

        // char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=13)]
        public string complexityType;
    
        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsClasses;
        
        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsInstruments;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayComplexInstruments 
    {
    
        /// size_t
        public size_t count;

        /// QDAPI_ComplexInstruments*
        public System.IntPtr elems;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4, CharSet=CharSet.Ansi)]
    public struct QDAPI_ClientFIApproves 
    {
    
        /// char[13]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=13)]
        public string clientCode;

        /// QDAPI_ArrayStrings
        public QDAPI_ArrayStrings lsApproves;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 4)]
    public struct QDAPI_ArrayClientFIApproves
    {

        /// size_t
        public size_t count;

        /// QDAPI_ClientFIApproves*
        public System.IntPtr elems;
    }


    public partial class NativeMethods
	{

		/// Return Type: int
		///lpszIniFile: char*
		///lpszUserName: char*
		///lpszUserPassword: char*
		///lpszError: char**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_Connect", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_Connect([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string lpszIniFile, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string lpszUserName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string lpszUserPassword, ref System.IntPtr lpszError);


		/// Return Type: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_Disconnect", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_Disconnect();


		/// Return Type: int
		///ppFirmCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_DLGetFirmList", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_DLGetFirmList(ref System.IntPtr ppFirmCodes);


		/// Return Type: int
		///lpszFirmCode: char*
		///nMode: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_DLOpenFile", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_DLOpenFile([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string lpszFirmCode, int nMode);


		/// Return Type: int
		///lpszFirmCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_DLUpdateFile", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_DLUpdateFile([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string lpszFirmCode);


		/// Return Type: int
		///lpszFirmCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_DLCloseFile", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_DLCloseFile([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string lpszFirmCode);


		/// Return Type: int
		///pMem: void**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_FreeMemory", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_FreeMemory(ref System.IntPtr pMem);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///deviationPercent: double
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassSettingsToGlobalPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassSettingsToGlobalPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, double deviationPercent, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///deviationPercent: double
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassSettingsToClientSettingsPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassSettingsToClientSettingsPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, double deviationPercent, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///deviationPercent: double
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassSettingsToClientTemplatePriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassSettingsToClientTemplatePriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, double deviationPercent, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///priceType: QDAPI_PriceType*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMiddlePriceFromGlobalPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMiddlePriceFromGlobalPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///priceType: QDAPI_PriceType*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMiddlePriceFromClientSettingsPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMiddlePriceFromClientSettingsPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///priceType: QDAPI_PriceType*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMiddlePriceFromClientTemplatePriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMiddlePriceFromClientTemplatePriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///pPriceLimitList: QDAPI_ArrayPriceLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromGlobalPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromGlobalPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr pPriceLimitList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///pPriceLimitList: QDAPI_ArrayPriceLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromClientSettingsPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromClientSettingsPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr pPriceLimitList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///pPriceLimitList: QDAPI_ArrayPriceLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromClientTemplatePriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromClientTemplatePriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr pPriceLimitList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassSettingsFromGlobalPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassSettingsFromGlobalPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassSettingsFromClientSettingsPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassSettingsFromClientSettingsPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassSettingsFromClientTemplatePriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassSettingsFromClientTemplatePriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMiddlePriceToGlobalPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMiddlePriceToGlobalPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMiddlePriceToClientSettingsPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMiddlePriceToClientSettingsPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMiddlePriceToClientTemplatePriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMiddlePriceToClientTemplatePriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCodes: QDAPI_ArrayPriceLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingListToGlobalPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingListToGlobalPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayPriceLimit classCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCodes: QDAPI_ArrayPriceLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingListToClientSettingsPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingListToClientSettingsPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayPriceLimit classCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCodes: QDAPI_ArrayPriceLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingListToClientTemplatePriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingListToClientTemplatePriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayPriceLimit classCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClientToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientsListOfClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClientsListOfClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///fromTemplateCode: char*
		///toTemplateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_MoveClientBetweenClientTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_MoveClientBetweenClientTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string fromTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string toTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClientFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClientsListOfClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClientsListOfClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);

		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddPartnerAndSettleCodeToClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddPartnerAndSettleCodeToClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetPartnerAndSettleCodeListFromClientTemplateProhibitedPartnersAndSettleCod" +
			"es", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetPartnerAndSettleCodeListFromClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemovePartnerAndSettleCodeFromClientTemplateProhibitedPartnersAndSettleCode" +
			"s", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemovePartnerAndSettleCodeFromClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetPartnerAndSettleCodeListToClientTemplateProhibitedPartnersAndSettleCodes" +
			"", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetPartnerAndSettleCodeListToClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///deviationPercent: double
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSecuritySettingsToGlobalSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSecuritySettingsToGlobalSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, double deviationPercent, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///secCode: char*
		///deviationPercent: double
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSecuritySettingsToClientSettingsSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSecuritySettingsToClientSettingsSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, double deviationPercent, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///deviationPercent: double
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSecuritySettingsToClientTemplateSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSecuritySettingsToClientTemplateSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, double deviationPercent, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///priceType: QDAPI_PriceType*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMiddlePriceFromGlobalSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMiddlePriceFromGlobalSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///priceType: QDAPI_PriceType*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMiddlePriceFromClientSettingsSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMiddlePriceFromClientSettingsSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///priceType: QDAPI_PriceType*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMiddlePriceFromClientTemplateSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMiddlePriceFromClientTemplateSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///pPriceLimitList: QDAPI_ArrayPriceLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromGlobalSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromGlobalSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr pPriceLimitList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///pPriceLimitList: QDAPI_ArrayPriceLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromClientSettingsSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromClientSettingsSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr pPriceLimitList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///pPriceLimitList: QDAPI_ArrayPriceLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromClientTemplateSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromClientTemplateSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr pPriceLimitList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecuritySettingsFromGlobalSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecuritySettingsFromGlobalSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecuritySettingsFromClientSettingsSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecuritySettingsFromClientSettingsSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecuritySettingsFromClientTemplateSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecuritySettingsFromClientTemplateSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMiddlePriceToGlobalSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMiddlePriceToGlobalSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMiddlePriceToClientSettingsSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMiddlePriceToClientSettingsSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///priceType: QDAPI_PriceType
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMiddlePriceToClientTemplateSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMiddlePriceToClientTemplateSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_PriceType priceType);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCodes: QDAPI_ArrayPriceLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingListToGlobalSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingListToGlobalSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayPriceLimit classCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCodes: QDAPI_ArrayPriceLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingListToClientSettingsSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingListToClientSettingsSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayPriceLimit classCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCodes: QDAPI_ArrayPriceLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingListToClientTemplateSecPriceLimit", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingListToClientTemplateSecPriceLimit([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayPriceLimit classCodes);


		/// Return Type: int
		///firmCode: char*
		///value: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetAdditionalSubClientDelimiterFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetAdditionalSubClientDelimiterFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref byte value);


		/// Return Type: int
		///firmCode: char*
		///newValue: char
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetAdditionalSubClientDelimiterToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetAdditionalSubClientDelimiterToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, byte newValue);


		/// Return Type: int
		///firmCode: char*
		///secPricePriority: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecPricePriorityFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecPricePriorityFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref int secPricePriority);


		/// Return Type: int
		///firmCode: char*
		///secPricePriority: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecPricePriorityToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSecPricePriorityToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, int secPricePriority);


		/// Return Type: int
		///firmCode: char*
		///lsFirmCodesOnDerivMarket: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfFirmsGlobalChangeFutClientCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfFirmsGlobalChangeFutClientCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsFirmCodesOnDerivMarket);


		/// Return Type: int
		///firmCode: char*
		///firmCodeOnDerivMarket: char*
		///clientCodeToTrdAcc: QDAPI_StringToString*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddCorrespToGlobalChangeFutClientCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddCorrespToGlobalChangeFutClientCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCodeOnDerivMarket, ref QDAPI_StringToString clientCodeToTrdAcc);


		/// Return Type: int
		///firmCode: char*
		///firmCodeOnDerivMarket: char*
		///trdAcc: char*
		///clientCode: char**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientCodeGlobalChangeFutClientCodesByTrdAcc", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClientCodeGlobalChangeFutClientCodesByTrdAcc([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCodeOnDerivMarket, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string trdAcc, ref System.IntPtr clientCode);


		/// Return Type: int
		///firmCode: char*
		///firmCodeOnDerivMarket: char*
		///clientCode: char*
		///trdAcc: char**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTrdAccGlobalChangeFutClientCodesByClientCode", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetTrdAccGlobalChangeFutClientCodesByClientCode([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCodeOnDerivMarket, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr trdAcc);


		/// Return Type: int
		///firmCode: char*
		///firmCodeOnDerivMarket: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllCorrespsFromGlobalChangeFutClientCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveAllCorrespsFromGlobalChangeFutClientCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCodeOnDerivMarket);


		/// Return Type: int
		///firmCode: char*
		///firmCodeOnDerivMarket: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByClientCode", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByClientCode([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCodeOnDerivMarket, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///firmCodeOnDerivMarket: char*
		///trdAcc: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByTrdAcc", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByTrdAcc([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCodeOnDerivMarket, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string trdAcc);


		/// Return Type: int
		///firmCode: char*
		///tradeAccount: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddTrdAccToGlobalProhibedTrdAcc", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddTrdAccToGlobalProhibedTrdAcc([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount);


		/// Return Type: int
		///firmCode: char*
		///tradeAccounts: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetGlobalProhibedTrdAcc", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetGlobalProhibedTrdAcc([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr tradeAccounts);


		/// Return Type: int
		///firmCode: char*
		///tradeAccount: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveTrdAccFromGlobalProhibedTrdAcc", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveTrdAccFromGlobalProhibedTrdAcc([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount);


		/// Return Type: int
		///firmCode: char*
		///tradeAccounts: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetGlobalProhibedTrdAcc", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetGlobalProhibedTrdAcc([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings tradeAccounts);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientToGlobalProhibitOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClientToGlobalProhibitOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///clientCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetGlobalProhibitOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetGlobalProhibitOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr clientCodes);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientFromGlobalProhibitOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClientFromGlobalProhibitOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///clientCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetGlobalProhibitOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetGlobalProhibitOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings clientCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///basePeriod: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetBasePeriodFromGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetBasePeriodFromGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref int basePeriod);


		/// Return Type: int
		///firmCode: char*
		///restr: QDAPI_RestrictOptionOrders*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddRestrictToGlobalRestrictOptionOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddRestrictToGlobalRestrictOptionOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_RestrictOptionOrders restr);


		/// Return Type: int
		///firmCode: char*
		///baseAssets: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetBaseAssetsGlobalRestrictOptionOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetBaseAssetsGlobalRestrictOptionOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr baseAssets);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///restrBody: QDAPI_RestrictOptionOrdersBody**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetRestrictionGlobalRestrictOptionOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetRestrictionGlobalRestrictOptionOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref System.IntPtr restrBody);


		/// Return Type: int
		///firmCode: char*
		///restrsList: QDAPI_ArrayRestrictOptionOrders**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetAllRestrictionsGlobalRestrictOptionOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetAllRestrictionsGlobalRestrictOptionOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr restrsList);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveRestrictFromGlobalRestrictOptionOrders", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveRestrictFromGlobalRestrictOptionOrders([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSecurityToGlobalRestrictSecuritiesProportionInCollateral", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSecurityToGlobalRestrictSecuritiesProportionInCollateral([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///secCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetGlobalRestrictSecuritiesProportionInCollateral", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetGlobalRestrictSecuritiesProportionInCollateral([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr secCodes);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityFromGlobalRestrictSecuritiesProportionInCollateral", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecurityFromGlobalRestrictSecuritiesProportionInCollateral([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///secCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetGlobalRestrictSecuritiesProportionInCollateral", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetGlobalRestrictSecuritiesProportionInCollateral([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings secCodes);


		/// Return Type: int
		///firmCode: char*
		///subBrokers: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSubBrokerListFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSubBrokerListFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr subBrokers);


		/// Return Type: int
		///firmCode: char*
		///subBroker: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSubBrokerFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSubBrokerFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subBroker);


		/// Return Type: int
		///firmCode: char*
		///subBroker: char*
		///subClient: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSubClientToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSubClientToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subBroker, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subClient);


		/// Return Type: int
		///firmCode: char*
		///subBroker: char*
		///subClientList: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSubClientListFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSubClientListFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subBroker, ref System.IntPtr subClientList);


		/// Return Type: int
		///firmCode: char*
		///subBroker: char*
		///subClient: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSubClientFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSubClientFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subBroker, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subClient);


		/// Return Type: int
		///firmCode: char*
		///subBroker: char*
		///subClientList: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSubClientListToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSubClientListToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subBroker, ref QDAPI_ArrayStrings subClientList);


		/// Return Type: int
		///firmCode: char*
		///subBroker: char*
		///flagNotAffectedOnGlobalLimit: int*
		///flagAffectedOnGlobalLimit: int*
		///flagWithoutNetting: int*
		///globalLimit: char**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSubBrokerSettingsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSubBrokerSettingsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subBroker, ref int flagNotAffectedOnGlobalLimit, ref int flagAffectedOnGlobalLimit, ref int flagWithoutNetting, ref System.IntPtr globalLimit);


		/// Return Type: int
		///firmCode: char*
		///subBroker: char*
		///flagNotAffectedOnGlobalLimit: int
		///flagAffectedOnGlobalLimit: int
		///flagWithoutNetting: int
		///globalLimit: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSubBrokerSettingsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSubBrokerSettingsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string subBroker, int flagNotAffectedOnGlobalLimit, int flagAffectedOnGlobalLimit, int flagWithoutNetting, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string globalLimit);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClientToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientsListOfMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClientsListOfMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///fromTemplateCode: char*
		///toTemplateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_MoveClientBetweenMarginTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_MoveClientBetweenMarginTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string fromTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string toTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClientFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClientsListOfMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClientsListOfMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClientToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientsListOfRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClientsListOfRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///fromTemplateCode: char*
		///toTemplateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_MoveClientBetweenRestrictionTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_MoveClientBetweenRestrictionTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string fromTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string toTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClientFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClientsListOfRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClientsListOfRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassFromGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassListToGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassListToGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref QDAPI_ArrayStrings lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassListToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassListToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref QDAPI_ArrayStrings lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToRestrictionTemplateSecurityAllowed", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToRestrictionTemplateSecurityAllowed([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///lsClassCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromRestrictionTemplateSecurityAllowed", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromRestrictionTemplateSecurityAllowed([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromRestrictionTemplateSecurityAllowed", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromRestrictionTemplateSecurityAllowed([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///lsClassCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToRestrictionTemplateSecurityAllowed", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToRestrictionTemplateSecurityAllowed([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref QDAPI_ArrayStrings lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassFromGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassFromRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassListToGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassListToGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref QDAPI_ArrayStrings lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassListToRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassListToRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref QDAPI_ArrayStrings lsClassCodes);

		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///discounts: QDAPI_Discounts*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityDiscountsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecurityDiscountsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref QDAPI_Discounts discounts);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///secCode: char*
		///discounts: QDAPI_Discounts*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityDiscountsFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecurityDiscountsFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref QDAPI_Discounts discounts);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///secCode: char*
		///discounts: QDAPI_Discounts*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityDiscountsFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecurityDiscountsFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref QDAPI_Discounts discounts);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityDiscountsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecurityDiscountsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityDiscountsFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecurityDiscountsFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityDiscountsFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecurityDiscountsFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///discounts: QDAPI_Discounts*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityDiscountsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSecurityDiscountsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref QDAPI_Discounts discounts);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///secCode: char*
		///discounts: QDAPI_Discounts*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityDiscountsToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSecurityDiscountsToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref QDAPI_Discounts discounts);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///secCode: char*
		///discounts: QDAPI_Discounts*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityDiscountsToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSecurityDiscountsToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, ref QDAPI_Discounts discounts);


		/// Return Type: int
		///firmCode: char*
		///useDiscountsType: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseDiscountsTypeFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseDiscountsTypeFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref int useDiscountsType);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///useDiscountsType: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseDiscountsTypeFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseDiscountsTypeFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref int useDiscountsType);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///useDiscountsType: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseDiscountsTypeFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseDiscountsTypeFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref int useDiscountsType);


		/// Return Type: int
		///firmCode: char*
		///useDiscountsType: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseDiscountsTypeToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseDiscountsTypeToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, int useDiscountsType);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///useDiscountsType: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseDiscountsTypeToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseDiscountsTypeToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, int useDiscountsType);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///useDiscountsType: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseDiscountsTypeToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseDiscountsTypeToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, int useDiscountsType);


		/// Return Type: int
		///firmCode: char*
		///useCHSecurityDiscounts: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseCHSecurityDiscountsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseCHSecurityDiscountsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref int useCHSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///useCHSecurityDiscounts: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseCHSecurityDiscountsFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseCHSecurityDiscountsFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref int useCHSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///useCHSecurityDiscounts: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseCHSecurityDiscountsFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseCHSecurityDiscountsFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref int useCHSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///useCHSecurityDiscounts: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseCHSecurityDiscountsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseCHSecurityDiscountsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, int useCHSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///useCHSecurityDiscounts: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseCHSecurityDiscountsToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseCHSecurityDiscountsToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, int useCHSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///useCHSecurityDiscounts: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseCHSecurityDiscountsToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseCHSecurityDiscountsToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, int useCHSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///useSecurityDiscounts: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseSecurityDiscountsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseSecurityDiscountsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref int useSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///useSecurityDiscounts: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseSecurityDiscountsFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseSecurityDiscountsFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref int useSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///useSecurityDiscounts: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseSecurityDiscountsFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseSecurityDiscountsFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref int useSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///useSecurityDiscounts: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseSecurityDiscountsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseSecurityDiscountsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, int useSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///useSecurityDiscounts: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseSecurityDiscountsToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseSecurityDiscountsToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, int useSecurityDiscounts);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///useSecurityDiscounts: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseSecurityDiscountsToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseSecurityDiscountsToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, int useSecurityDiscounts);

		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///lsRestrictionTemplateCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfRestrictionTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfRestrictionTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsRestrictionTemplateCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);

		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///side: QDAPI_OperationSide
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSecurityToRestrictionTemplateRestrictRepoByFirstPartSide", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSecurityToRestrictionTemplateRestrictRepoByFirstPartSide([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, QDAPI_OperationSide side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///side: QDAPI_OperationSide
		///lsClassCodes: QDAPI_ArrayClassBySide**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromRestrictionTemplateRestrictRepoByFirstPartSide", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromRestrictionTemplateRestrictRepoByFirstPartSide([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_OperationSide side, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///side: QDAPI_OperationSide
		///lsSecurityCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityListFromRestrictionTemplateRestrictRepoByFirstPartSide", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecurityListFromRestrictionTemplateRestrictRepoByFirstPartSide([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, QDAPI_OperationSide side, ref System.IntPtr lsSecurityCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///side: QDAPI_OperationSide
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromRestrictionTemplateRestrictRepoByFirstPartSide", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassFromRestrictionTemplateRestrictRepoByFirstPartSide([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, QDAPI_OperationSide side);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///side: QDAPI_OperationSide
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityFromRestrictionTemplateRestrictRepoByFirstPartSide", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecurityFromRestrictionTemplateRestrictRepoByFirstPartSide([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, QDAPI_OperationSide side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///side: QDAPI_OperationSide
		///lsSecurityCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityListToRestrictionTemplateRestrictRepoByFirstPartSide", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSecurityListToRestrictionTemplateRestrictRepoByFirstPartSide([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, QDAPI_OperationSide side, ref QDAPI_ArrayStrings lsSecurityCodes);

		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///side: QDAPI_OperationSide
		///lsSecurityCodes: QDAPI_ArraySecurityBySide**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityListFromGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecurityListFromGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, QDAPI_OperationSide side, ref System.IntPtr lsSecurityCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///side: QDAPI_OperationSide
		///lsSecurityCodes: QDAPI_ArraySecurityBySide**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityListFromRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecurityListFromRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_OperationSide side, ref System.IntPtr lsSecurityCodes);

		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddPartnerAndSettleCodeToClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddPartnerAndSettleCodeToClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetPartnerAndSettleCodeListFromClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetPartnerAndSettleCodeListFromClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemovePartnerAndSettleCodeFromClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemovePartnerAndSettleCodeFromClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetPartnerAndSettleCodeListToClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetPartnerAndSettleCodeListToClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///usePGO: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUsePGOFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUsePGOFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref int usePGO);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///usePGO: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUsePGOFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUsePGOFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref int usePGO);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///usePGO: int*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUsePGOFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUsePGOFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref int usePGO);


		/// Return Type: int
		///firmCode: char*
		///usePGO: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUsePGOToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUsePGOToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, int usePGO);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///usePGO: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUsePGOToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUsePGOToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int usePGO);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///usePGO: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUsePGOToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUsePGOToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int usePGO);


		/// Return Type: int
		///firmCode: char*
		///lsBaseAssets: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetBaseAssetsListFromBaseAssetsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetBaseAssetsListFromBaseAssetsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsBaseAssets);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///lsSpotCodes: QDAPI_ArraySpotListForBaseAsset**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSpotListForBaseAssetFromBaseAssetsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSpotListForBaseAssetFromBaseAssetsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref System.IntPtr lsSpotCodes);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///lsSpotCodes: QDAPI_ArraySpotListForBaseAsset*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToBaseAssetsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToBaseAssetsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref QDAPI_ArraySpotListForBaseAsset lsSpotCodes);


		/// Return Type: int
		///firmCode: char*
		///lsBaseAssetsTemplateCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfBaseAssetsTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfBaseAssetsTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsBaseAssetsTemplateCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientToBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClientToBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientsListFromBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClientsListFromBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///fromTemplateCode: char*
		///toTemplateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_MoveClientBetweenBaseAssetsTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_MoveClientBetweenBaseAssetsTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string fromTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string toTemplateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientFromBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClientFromBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsClientCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClientsListOfBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClientsListOfBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsBaseAssets: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetBaseAssetsListFromBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetBaseAssetsListFromBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsBaseAssets);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///baseAsset: char*
		///lsSpotCodes: QDAPI_ArraySpotListForBaseAsset**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSpotListForBaseAssetFromBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSpotListForBaseAssetFromBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref System.IntPtr lsSpotCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///baseAsset: char*
		///lsSpotCodes: QDAPI_ArraySpotListForBaseAsset*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToBaseAssetsTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToBaseAssetsTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref QDAPI_ArraySpotListForBaseAsset lsSpotCodes);


		/// Return Type: int
		///firmCode: char*
		///settings: QDAPI_MainSettingsOfPortfolioRiskConfigGlobal**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMainSettingsFromPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMainSettingsFromPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr settings);


		/// Return Type: int
		///firmCode: char*
		///settings: QDAPI_MainSettingsOfPortfolioRiskConfigGlobal*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMainSettingsToPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMainSettingsToPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_MainSettingsOfPortfolioRiskConfigGlobal settings);


		/// Return Type: int
		///firmCode: char*
		///lsTiers: QDAPI_ArrayOfSpreadTiers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSpreadTiersFromPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSpreadTiersFromPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsTiers);


		/// Return Type: int
		///firmCode: char*
		///lsTiers: QDAPI_ArrayOfSpreadTiers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSpreadTiersToPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSpreadTiersToPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayOfSpreadTiers lsTiers);


		/// Return Type: int
		///firmCode: char*
		///settings: QDAPI_PortfolioRiskConfigSettings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommonSettingsFromPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCommonSettingsFromPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr settings);


		/// Return Type: int
		///firmCode: char*
		///settings: QDAPI_PortfolioRiskConfigSettings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommonSettingsToPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetCommonSettingsToPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_PortfolioRiskConfigSettings settings);


		/// Return Type: int
		///firmCode: char*
		///lsTrdAccs: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTrdAccListFromPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetTrdAccListFromPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsTrdAccs);


		/// Return Type: int
		///firmCode: char*
		///tradingAccount: char*
		///settings: QDAPI_PortfolioRiskConfigSettings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetIndividualSettingsFromPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetIndividualSettingsFromPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradingAccount, ref System.IntPtr settings);


		/// Return Type: int
		///firmCode: char*
		///tradingAccount: char*
		///settings: QDAPI_PortfolioRiskConfigSettings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetIndividualSettingsToPortfolioRiskConfigGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetIndividualSettingsToPortfolioRiskConfigGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradingAccount, ref QDAPI_PortfolioRiskConfigSettings settings);


		/// Return Type: int
		///firmCode: char*
		///lsBaseAssets: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetBaseAssetsListWithPortfolioRiskConfigOnBaseAssetSection", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetBaseAssetsListWithPortfolioRiskConfigOnBaseAssetSection([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsBaseAssets);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddPortfolioRiskConfigOnBaseAssetSection", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddPortfolioRiskConfigOnBaseAssetSection([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemovePortfolioRiskConfigOnBaseAssetSection", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemovePortfolioRiskConfigOnBaseAssetSection([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///lsAdditionalBaseAssets: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref System.IntPtr lsAdditionalBaseAssets);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///lsAdditionalBaseAssets: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref QDAPI_ArrayStrings lsAdditionalBaseAssets);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///lsTiers: QDAPI_ArrayOfSpreadTiers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSpreadTiersFromPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSpreadTiersFromPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref System.IntPtr lsTiers);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///lsTiers: QDAPI_ArrayOfSpreadTiers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSpreadTiersToPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSpreadTiersToPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref QDAPI_ArrayOfSpreadTiers lsTiers);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///settings: QDAPI_PortfolioRiskConfigSettings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommonSettingsFromPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCommonSettingsFromPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref System.IntPtr settings);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///settings: QDAPI_PortfolioRiskConfigSettings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommonSettingsToPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetCommonSettingsToPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref QDAPI_PortfolioRiskConfigSettings settings);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///lsTrdAccs: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTrdAccListFromPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetTrdAccListFromPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, ref System.IntPtr lsTrdAccs);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///tradingAccount: char*
		///settings: QDAPI_PortfolioRiskConfigSettings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetIndividualSettingsFromPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetIndividualSettingsFromPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradingAccount, ref System.IntPtr settings);


		/// Return Type: int
		///firmCode: char*
		///baseAsset: char*
		///tradingAccount: char*
		///settings: QDAPI_PortfolioRiskConfigSettings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetIndividualSettingsToPortfolioRiskConfigOnBaseAsset", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetIndividualSettingsToPortfolioRiskConfigOnBaseAsset([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradingAccount, ref QDAPI_PortfolioRiskConfigSettings settings);


		/// Return Type: int
		///firmCode: char*
		///lsTemplates: QDAPI_ArrayPortfolioRiskConfigTemplateIdentifier**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetPortfolioRiskConfigTemplatesList", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetPortfolioRiskConfigTemplatesList([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsTemplates);


		/// Return Type: int
		///firmCode: char*
		///templateId: QDAPI_PortfolioRiskConfigTemplateIdentifier*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_PortfolioRiskConfigTemplateIdentifier templateId);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemovePortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemovePortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientToPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClientToPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsClientCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientsListFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClientsListFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///fromTemplate: char*
		///toTemplate: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_MoveClientBetweenPortfolioRiskConfigTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_MoveClientBetweenPortfolioRiskConfigTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string fromTemplate, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string toTemplate, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///clientCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClientFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsClientCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClientsListOfPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClientsListOfPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayStrings lsClientCodes);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///tag: char**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetBoardTagFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetBoardTagFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr tag);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///tag: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetBoardTagToPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetBoardTagToPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tag);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///baseAsset: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMainAssetToPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMainAssetToPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string baseAsset);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsAdditionalBaseAssets: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsAdditionalBaseAssets);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsAdditionalBaseAssets: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayStrings lsAdditionalBaseAssets);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsTiers: QDAPI_ArrayOfSpreadTiers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSpreadTiersFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSpreadTiersFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsTiers);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsTiers: QDAPI_ArrayOfSpreadTiers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSpreadTiersToPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSpreadTiersToPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayOfSpreadTiers lsTiers);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///settings: QDAPI_PortfolioRiskConfigSettings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommonSettingsFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCommonSettingsFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr settings);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///settings: QDAPI_PortfolioRiskConfigSettings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommonSettingsToPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetCommonSettingsToPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_PortfolioRiskConfigSettings settings);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsTrdAccs: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTrdAccListFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetTrdAccListFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsTrdAccs);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///tradingAccount: char*
		///settings: QDAPI_PortfolioRiskConfigSettings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetIndividualSettingsFromPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetIndividualSettingsFromPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradingAccount, ref System.IntPtr settings);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///tradingAccount: char*
		///settings: QDAPI_PortfolioRiskConfigSettings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetIndividualSettingsToPortfolioRiskConfigTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetIndividualSettingsToPortfolioRiskConfigTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradingAccount, ref QDAPI_PortfolioRiskConfigSettings settings);


		/// Return Type: int
		///firmCode: char*
		///lsSpreadOrderSettings: QDAPI_ArrayBaseAssetsSpreadOrder**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsListFromPortfolioSpreadOrder", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsListFromPortfolioSpreadOrder([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsSpreadOrderSettings);


		/// Return Type: int
		///firmCode: char*
		///lsSpreadOrderSettings: QDAPI_BaseAssetsSpreadOrder*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToPortfolioSpreadOrder", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToPortfolioSpreadOrder([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_BaseAssetsSpreadOrder lsSpreadOrderSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		///restrs: QDAPI_ArrayVolumeRestrictionByAvgTurnover**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnoverEx", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnoverEx([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr restrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		///restrs: QDAPI_ArrayVolumeRestrictionByAvgTurnover**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromRestrictionTemplateRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromRestrictionTemplateRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr restrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///basePeriod: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetBasePeriodToGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetBasePeriodToGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, int basePeriod);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///restrs: QDAPI_ArrayVolumeRestrictionByAvgTurnover*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingToGlobalRestOrdVolumeByAvgTurnoverEx", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingToGlobalRestOrdVolumeByAvgTurnoverEx([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayVolumeRestrictionByAvgTurnover restrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restrs: QDAPI_ArrayVolumeRestrictionByAvgTurnover*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayVolumeRestrictionByAvgTurnover restrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classList: QDAPI_ArrayStrings*
		///instrList: QDAPI_ArrayStrings*
		///restPercent: double
		///alertPercent: double
		///valuationClass: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSettingsToGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSettingsToGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings classList, ref QDAPI_ArrayStrings instrList, double restPercent, double alertPercent, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string valuationClass);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classList: QDAPI_ArrayStrings*
		///instrList: QDAPI_ArrayStrings*
		///restPercent: double
		///alertPercent: double
		///valuationClass: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings classList, ref QDAPI_ArrayStrings instrList, double restPercent, double alertPercent, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string valuationClass);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classList: QDAPI_ArrayStrings*
		///instrList: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSettingsFromGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSettingsFromGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings classList, ref QDAPI_ArrayStrings instrList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classList: QDAPI_ArrayStrings*
		///instrList: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings classList, ref QDAPI_ArrayStrings instrList);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllSettingsFromGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveAllSettingsFromGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveAllSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsClassCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromGlobalRestrictSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromGlobalRestrictSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///restrictions: QDAPI_ArrayRestrictSecurityByClass**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassSettingsListFromGlobalRestrictSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassSettingsListFromGlobalRestrictSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr restrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsTradeAccounts: QDAPI_ArrayStrings*
		///isPeriodExists: boolean
		///fromTimeHours: int
		///fromTimeMinutes: int
		///tillTimeHours: int
		///tillTimeMinutes: int
		///lsSecurityCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddSecurityListToGlobalRestrictSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddSecurityListToGlobalRestrictSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsTradeAccounts, [MarshalAsAttribute(UnmanagedType.I1)] bool isPeriodExists, int fromTimeHours, int fromTimeMinutes, int tillTimeHours, int tillTimeMinutes, ref QDAPI_ArrayStrings lsSecurityCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsTradeAccounts: QDAPI_ArrayStrings*
		///isPeriodExists: boolean
		///fromTimeHours: int
		///fromTimeMinutes: int
		///tillTimeHours: int
		///tillTimeMinutes: int
		///lsSecurityCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityListFromGlobalRestrictSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSecurityListFromGlobalRestrictSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsTradeAccounts, [MarshalAsAttribute(UnmanagedType.I1)] bool isPeriodExists, int fromTimeHours, int fromTimeMinutes, int tillTimeHours, int tillTimeMinutes, ref System.IntPtr lsSecurityCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsTradeAccounts: QDAPI_ArrayStrings*
		///isPeriodExists: boolean
		///fromTimeHours: int
		///fromTimeMinutes: int
		///tillTimeHours: int
		///tillTimeMinutes: int
		///lsSecurityCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityListFromGlobalRestrictSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveSecurityListFromGlobalRestrictSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsTradeAccounts, [MarshalAsAttribute(UnmanagedType.I1)] bool isPeriodExists, int fromTimeHours, int fromTimeMinutes, int tillTimeHours, int tillTimeMinutes, ref QDAPI_ArrayStrings lsSecurityCodes);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsTradeAccounts: QDAPI_ArrayStrings*
		///isPeriodExists: boolean
		///fromTimeHours: int
		///fromTimeMinutes: int
		///tillTimeHours: int
		///tillTimeMinutes: int
		///lsSecurityCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityListToGlobalRestrictSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSecurityListToGlobalRestrictSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsTradeAccounts, [MarshalAsAttribute(UnmanagedType.I1)] bool isPeriodExists, int fromTimeHours, int fromTimeMinutes, int tillTimeHours, int tillTimeMinutes, ref QDAPI_ArrayStrings lsSecurityCodes);

		///
		/// Deprecated functions
		///

		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[System.Obsolete("use QDAPI_AddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[System.Obsolete("use QDAPI_AddPartnerAndSettleCodeToClientTemplateProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[System.Obsolete("use QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings**
		///lsSettleCodes: QDAPI_ArrayStrings**
		[System.Obsolete("use QDAPI_GetPartnerAndSettleCodeListFromClientTemplateProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsPartnerCodes, ref System.IntPtr lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[System.Obsolete("use QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///partnerCode: char*
		///settleCode: char*
		[System.Obsolete("use QDAPI_RemovePartnerAndSettleCodeFromClientTemplateProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string partnerCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settleCode);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[System.Obsolete("use QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///classCode: char*
		///lsPartnerCodes: QDAPI_ArrayStrings*
		///lsSettleCodes: QDAPI_ArrayStrings*
		[System.Obsolete("use QDAPI_SetPartnerAndSettleCodeListToClientTemplateProhibitedPartnersAndSettleCodes")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsPartnerCodes, ref QDAPI_ArrayStrings lsSettleCodes);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[System.Obsolete("use QDAPI_AddClassToGlobalProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[System.Obsolete("use QDAPI_AddClassToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings**
		[System.Obsolete("use QDAPI_GetClassListFromGlobalProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings**
		[System.Obsolete("use QDAPI_GetClassListFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[System.Obsolete("use QDAPI_RemoveClassFromGlobalProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///classCode: char*
		[System.Obsolete("use QDAPI_RemoveClassFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings*
		[System.Obsolete("use QDAPI_SetClassListToGlobalProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToGlobalProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToGlobalProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref QDAPI_ArrayStrings lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///isRepoTermExist: int
		///repoTerm: int
		///lsClassCodes: QDAPI_ArrayStrings*
		[System.Obsolete("use QDAPI_SetClassListToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, int isRepoTermExist, int repoTerm, ref QDAPI_ArrayStrings lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[System.Obsolete("use QDAPI_AddClassToGlobalSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[System.Obsolete("use QDAPI_AddClassToRestrictionTemplateSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddItemToRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddItemToRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings**
		[System.Obsolete("use QDAPI_GetClassListFromGlobalSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings**
		[System.Obsolete("use QDAPI_GetClassListFromRestrictionTemplateSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetItemFromRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetItemFromRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref System.IntPtr lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[System.Obsolete("use QDAPI_RemoveClassFromGlobalSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///classCode: char*
		[System.Obsolete("use QDAPI_RemoveClassFromRestrictionTemplateSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveItemFromRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveItemFromRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings*
		[System.Obsolete("use QDAPI_SetClassListToGlobalSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToGlobalSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToGlobalSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref QDAPI_ArrayStrings lsClassCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///secCode: char*
		///isSideExist: int
		///side: char
		///lsClassCodes: QDAPI_ArrayStrings*
		[System.Obsolete("use QDAPI_SetClassListToRestrictionTemplateSecurityRestricted")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetItemToRestrictionTemplateSecurityRestricted", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetItemToRestrictionTemplateSecurityRestricted([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode, int isSideExist, byte side, ref QDAPI_ArrayStrings lsClassCodes);

		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///restPercent: double
		///alertPercent: double
		///valuationClass: char*
		[System.Obsolete("use QDAPI_AddSettingsToGlobalRestOrdVolumeByAvgTurnoverEx")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassSettingsToGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassSettingsToGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, double restPercent, double alertPercent, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string valuationClass);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///restrs: QDAPI_ArrayVolumeRestriction**
		[System.Obsolete("use QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnoverEx")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr restrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		[System.Obsolete("use QDAPI_RemoveSettingsFromGlobalRestOrdVolumeByAvgTurnover")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassSettingsFromGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassSettingsFromGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///restrs: QDAPI_ArrayVolumeRestriction*
		[System.Obsolete("use QDAPI_SetSettingToGlobalRestOrdVolumeByAvgTurnoverEx")]
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingListToGlobalRestOrdVolumeByAvgTurnover", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingListToGlobalRestOrdVolumeByAvgTurnover([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayVolumeRestriction restrs);


		/// Return Type: int
		///firmCode: char*
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromGlobalSecurityDiscounts", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetInstrumentListFromGlobalSecurityDiscounts([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromMarginTemplateSecurityDiscounts", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetInstrumentListFromMarginTemplateSecurityDiscounts([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromClientSettingsSecurityDiscounts", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetInstrumentListFromClientSettingsSecurityDiscounts([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///lsSettings: QDAPI_ArrayTranoutTag**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsFromTranoutTagGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsFromTranoutTagGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///lsSettings: QDAPI_ArrayTranoutTag*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToTranoutTagGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToTranoutTagGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayTranoutTag lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsTradeAccounts: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfTradeAccsFromSecProhibitedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfTradeAccsFromSecProhibitedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsTradeAccounts);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfInstrumentsFromSecProhibitedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfInstrumentsFromSecProhibitedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfInstrumentsForTrdAccFromSecProhibitedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfInstrumentsForTrdAccFromSecProhibitedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///instrument: char*
		///lsTradeAccounts: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfTradeAccsForInstrFromSecProhibitedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfTradeAccsForInstrFromSecProhibitedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument, ref System.IntPtr lsTradeAccounts);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrForTradeAccToSecProhibitedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddInstrForTradeAccToSecProhibitedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrListForTradeAccToSecProhibitedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetInstrListForTradeAccToSecProhibitedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrForTradeAccFromSecProhibitedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveInstrForTradeAccFromSecProhibitedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsTradeAccounts: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfTradeAccsFromSecAllowedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfTradeAccsFromSecAllowedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsTradeAccounts);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfInstrumentsFromSecAllowedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfInstrumentsFromSecAllowedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfInstrumentsForTrdAccFromSecAllowedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfInstrumentsForTrdAccFromSecAllowedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///instrument: char*
		///lsTradeAccounts: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfTradeAccsForInstrFromSecAllowedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfTradeAccsForInstrFromSecAllowedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument, ref System.IntPtr lsTradeAccounts);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrForTradeAccToSecAllowedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddInstrForTradeAccToSecAllowedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrListForTradeAccToSecAllowedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetInstrListForTradeAccToSecAllowedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///tradeAccount: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrForTradeAccFromSecAllowedTrdAccsGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveInstrForTradeAccFromSecAllowedTrdAccsGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string tradeAccount, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsClasses: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfClassesFromClientTemplateRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfClassesFromClientTemplateRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsClasses);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///lsClasses: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfClassesFromClientSettingsRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfClassesFromClientSettingsRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsClasses);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfInstrumentsForClassFromClientTemplateRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfInstrumentsForClassFromClientTemplateRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfInstrumentsForClassFromClientSettingsRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfInstrumentsForClassFromClientSettingsRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrForClassToClientTemplateRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddInstrForClassToClientTemplateRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrForClassToClientSettingsRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddInstrForClassToClientSettingsRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrListForClassToClientTemplateRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetInstrListForClassToClientTemplateRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrListForClassToClientSettingsRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetInstrListForClassToClientSettingsRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrForClassFromClientTemplateRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveInstrForClassFromClientTemplateRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///instrument: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrForClassFromClientSettingsRestrictedSecurity", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveInstrForClassFromClientSettingsRestrictedSecurity([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string instrument);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsInstruments: QDAPI_ArrayStrings*
		///lsRestrs: QDAPI_ArrayMaxPositionLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMaxPositionLimitFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMaxPositionLimitFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr lsRestrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsInstruments: QDAPI_ArrayStrings*
		///lsRestrs: QDAPI_ArrayMaxPositionLimit**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMaxPositionLimitFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMaxPositionLimitFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr lsRestrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsRestrs: QDAPI_ArrayMaxPositionLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMaxPositionLimitToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMaxPositionLimitToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayMaxPositionLimit lsRestrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsRestrs: QDAPI_ArrayMaxPositionLimit*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMaxPositionLimitToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMaxPositionLimitToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayMaxPositionLimit lsRestrs);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMaxPositionLimitFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMaxPositionLimitFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMaxPositionLimitFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMaxPositionLimitFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///lsClientTemplateCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfClientTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfClientTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsClientTemplateCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///leverage: QDAPI_ArrayDoubleNumbers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetIncludeClientsWithLeverageFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetIncludeClientsWithLeverageFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr leverage);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///leverage: QDAPI_ArrayDoubleNumbers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetIncludeClientsWithLeverageToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetIncludeClientsWithLeverageToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayDoubleNumbers leverage);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


		/// Return Type: int
		///firmCode: char*
		///lsMarginTemplateCodes: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetListOfMarginTemplates", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetListOfMarginTemplates([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsMarginTemplateCodes);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///leverage: QDAPI_ArrayDoubleNumbers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetIncludeClientsWithLeverageFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetIncludeClientsWithLeverageFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr leverage);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///leverage: QDAPI_ArrayDoubleNumbers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetIncludeClientsWithLeverageToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetIncludeClientsWithLeverageToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayDoubleNumbers leverage);

		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///lsLimitKinds: QDAPI_ArrayIntNumbers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientSettingsLimitKinds", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClientSettingsLimitKinds([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref System.IntPtr lsLimitKinds);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///lsLimitKinds: QDAPI_ArrayIntNumbers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMarginTemplateLimitKinds", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMarginTemplateLimitKinds([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref System.IntPtr lsLimitKinds);


		/// Return Type: int
		///firmCode: char*
		///lsLimitKinds: QDAPI_ArrayIntNumbers**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetGlobalLimitKinds", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetGlobalLimitKinds([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsLimitKinds);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///limitKind: int
		///lsLimitKinds: QDAPI_ArrayIntNumbers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClientSettingsLimitKinds", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClientSettingsLimitKinds([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_ArrayIntNumbers lsLimitKinds);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///limitKind: int
		///lsLimitKinds: QDAPI_ArrayIntNumbers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMarginTemplateLimitKinds", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMarginTemplateLimitKinds([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_ArrayIntNumbers lsLimitKinds);


		/// Return Type: int
		///firmCode: char*
		///lsLimitKinds: QDAPI_ArrayIntNumbers*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetGlobalLimitKinds", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetGlobalLimitKinds([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayIntNumbers lsLimitKinds);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsCP: QDAPI_PartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddCPListToClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddCPListToClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_PartnersAndSettleCodesRestrictions lsCP);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsFromClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsFromClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		///lsCP: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPListFromClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCPListFromClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm, ref System.IntPtr lsCP);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPListFromClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCPListFromClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToClientSettingsAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToClientSettingsAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayPartnersAndSettleCodesRestrictions lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsCP: QDAPI_PartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddCPListToClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddCPListToClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_PartnersAndSettleCodesRestrictions lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsFromClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsFromClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		///lsCP: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPListFromClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCPListFromClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm, ref System.IntPtr lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPListFromClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCPListFromClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToClientTemplateAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToClientTemplateAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayPartnersAndSettleCodesRestrictions lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsCP: QDAPI_PartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddCPListToGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddCPListToGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_PartnersAndSettleCodesRestrictions lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsFromGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsFromGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		///lsCP: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPListFromGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCPListFromGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm, ref System.IntPtr lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPListFromGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCPListFromGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToGlobalAllowedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToGlobalAllowedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayPartnersAndSettleCodesRestrictions lsSettings);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsCP: QDAPI_PartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddCPListToClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddCPListToClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_PartnersAndSettleCodesRestrictions lsCP);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsFromClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsFromClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		///lsCP: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPListFromClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCPListFromClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm, ref System.IntPtr lsCP);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPListFromClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCPListFromClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToClientSettingsProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToClientSettingsProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayPartnersAndSettleCodesRestrictions lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsCP: QDAPI_PartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddCPListToClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddCPListToClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_PartnersAndSettleCodesRestrictions lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsFromClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsFromClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		///lsCP: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPListFromClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCPListFromClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm, ref System.IntPtr lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPListFromClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCPListFromClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToClientTemplateProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToClientTemplateProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayPartnersAndSettleCodesRestrictions lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsCP: QDAPI_PartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddCPListToGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddCPListToGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_PartnersAndSettleCodesRestrictions lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSettingsFromGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetSettingsFromGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		///lsCP: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPListFromGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCPListFromGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm, ref System.IntPtr lsCP);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///classCode: char*
		///lsSettleCodes: QDAPI_ArrayStrings*
		///operationSide: QDAPI_OperationSide
		///maxTerm: int
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPListFromGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveCPListFromGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsSettleCodes, QDAPI_OperationSide operationSide, Int64 maxTerm);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsSettings: QDAPI_ArrayPartnersAndSettleCodesRestrictions*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSettingsToGlobalProhibitedPartnersAndSettleCodes", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetSettingsToGlobalProhibitedPartnersAndSettleCodes([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayPartnersAndSettleCodesRestrictions lsSettings);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		///lsRestrictions: QDAPI_ArrayMinOrderQty**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderQtyFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderQtyFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///restriction: QDAPI_MinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderQtyToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderQtyToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_MinOrderQty restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///restriction: QDAPI_ArrayMinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderQtyToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderQtyToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayMinOrderQty restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderQtyFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderQtyFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		///lsRestrictions: QDAPI_ArrayMinOrderValue**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderValueFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderValueFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///restriction: QDAPI_MinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderValueToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderValueToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_MinOrderValue restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///restrictions: QDAPI_ArrayMinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderValueToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderValueToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayMinOrderValue restrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderValueFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderValueFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		///lsRestrictions: QDAPI_ArrayMinOrderQty**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderQtyFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderQtyFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restriction: QDAPI_MinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderQtyToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderQtyToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_MinOrderQty restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restriction: QDAPI_ArrayMinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderQtyToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderQtyToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayMinOrderQty restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderQtyFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderQtyFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		///lsRestrictions: QDAPI_ArrayMinOrderValue**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderValueFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderValueFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restriction: QDAPI_MinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderValueToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderValueToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_MinOrderValue restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restrictions: QDAPI_ArrayMinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderValueToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderValueToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayMinOrderValue restrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderValueFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderValueFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsRestrictions: QDAPI_ArrayClassMinOrderQty**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderQtyFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderQtyFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restriction: QDAPI_ClassMinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderQtyToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderQtyToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ClassMinOrderQty restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restrictions: QDAPI_ArrayClassMinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderQtyToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderQtyToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayClassMinOrderQty restrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderQtyFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderQtyFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///lsRestrictions: QDAPI_ArrayClassMinOrderQty**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderQtyFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderQtyFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///restriction: QDAPI_ClassMinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderQtyToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderQtyToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ClassMinOrderQty restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///restrictions: QDAPI_ArrayClassMinOrderQty*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderQtyToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderQtyToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayClassMinOrderQty restrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderQtyFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderQtyFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		///lsRestrictions: QDAPI_ArrayClassMinOrderValue**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderValueFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderValueFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restriction: QDAPI_ClassMinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderValueToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderValueToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ClassMinOrderValue restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///restrictions: QDAPI_ArrayClassMinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderValueToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderValueToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayClassMinOrderValue restrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///templateCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderValueFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderValueFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		///lsRestrictions: QDAPI_ArrayClassMinOrderValue**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMinOrderValueFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMinOrderValueFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsRestrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///restriction: QDAPI_ClassMinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddMinOrderValueToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddMinOrderValueToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ClassMinOrderValue restriction);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///restrictions: QDAPI_ArrayClassMinOrderValue*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMinOrderValueToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMinOrderValueToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayClassMinOrderValue restrictions);


		/// Return Type: int
		///firmCode: char*
		///settingsScope: QDAPI_SettingsScope
		///clientCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveMinOrderValueFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveMinOrderValueFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsClassLists: QDAPI_ArrayOfStringArrays**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromClientTemplateVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromClientTemplateVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsClassLists);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///classCode: char*
		///lsClasses: QDAPI_ArrayStrings**
		///rates: QDAPI_ArrayOfVolumeBasedCommissionRates**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassSettingsFromClientTemplateVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassSettingsFromClientTemplateVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsClasses, ref System.IntPtr rates);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsClasses: QDAPI_ArrayStrings*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToClientTemplateVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToClientTemplateVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayStrings lsClasses, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///lsClasses: QDAPI_ArrayStrings*
		///rates: QDAPI_ArrayOfVolumeBasedCommissionRates*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassListSettingsToClientTemplateVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassListSettingsToClientTemplateVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayOfVolumeBasedCommissionRates rates);


		/// Return Type: int
		///firmCode: char*
		///templateName: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassSettingsFromClientTemplateVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassSettingsFromClientTemplateVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsClassLists: QDAPI_ArrayOfStringArrays**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromClientSettingsVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromClientSettingsVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsClassLists);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		///lsClasses: QDAPI_ArrayStrings**
		///rates: QDAPI_ArrayOfVolumeBasedCommissionRates**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassSettingsFromClientSettingsVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassSettingsFromClientSettingsVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsClasses, ref System.IntPtr rates);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToClientSettingsVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToClientSettingsVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayStrings lsClasses, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///rates: QDAPI_ArrayOfVolumeBasedCommissionRates*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassListSettingsToClientSettingsVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassListSettingsToClientSettingsVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayOfVolumeBasedCommissionRates rates);


		/// Return Type: int
		///firmCode: char*
		///clientCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassSettingsFromClientSettingsVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassSettingsFromClientSettingsVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///lsClasses: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassesWithPriceExportForMarketOrdersFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassesWithPriceExportForMarketOrdersFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsClasses);


		/// Return Type: int
		///firmCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassesWithPriceExportForMarketOrdersToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassesWithPriceExportForMarketOrdersToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings lsClasses);


		/// Return Type: int
		///firmCode: char*
		///lsSettings: QDAPI_ArrayClassListForCurrency**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionSettingsCurrencyFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetCommissionSettingsCurrencyFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsSettings);


		/// Return Type: int
		///firmCode: char*
		///lsSettings: QDAPI_ArrayClassListForCurrency*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionSettingsCurrencyToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetCommissionSettingsCurrencyToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayClassListForCurrency lsSettings);


		/// Return Type: int
		///firmCode: char*
		///lsClassLists: QDAPI_ArrayOfStringArrays**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListsFromGlobalVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListsFromGlobalVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsClassLists);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///lsClasses: QDAPI_ArrayStrings**
		///rates: QDAPI_ArrayOfVolumeBasedCommissionRates**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassSettingsFromGlobalVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassSettingsFromGlobalVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsClasses, ref System.IntPtr rates);


		/// Return Type: int
		///firmCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToGlobalVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToGlobalVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings lsClasses, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///lsClasses: QDAPI_ArrayStrings*
		///rates: QDAPI_ArrayOfVolumeBasedCommissionRates*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClassListSettingsToGlobalVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetClassListSettingsToGlobalVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings lsClasses, ref QDAPI_ArrayOfVolumeBasedCommissionRates rates);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassSettingsFromGlobalVolumeBasedCommission", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassSettingsFromGlobalVolumeBasedCommission([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);

		/// Return Type: int
		///firmCode: char*
		///lsGroups: QDAPI_ArrayGroupsWithDependentPrices**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetGroupsWithDependentPricesListFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetGroupsWithDependentPricesListFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsGroups);


		/// Return Type: int
		///firmCode: char*
		///group: QDAPI_GroupWithDependentPrices*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddGroupWithDependentPricesToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddGroupWithDependentPricesToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_GroupWithDependentPrices group);


		/// Return Type: int
		///firmCode: char*
		///groupCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveGroupWithDependentPricesFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveGroupWithDependentPricesFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode);


		/// Return Type: int
		///firmCode: char*
		///groupCode: char*
		///lsInstruments: QDAPI_ArrayInstruments**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromGroupWithDependentPricesGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetInstrumentListFromGroupWithDependentPricesGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///groupCode: char*
		///instrument: QDAPI_Instrument*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrumentToGroupWithDependentPricesGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddInstrumentToGroupWithDependentPricesGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, ref QDAPI_Instrument instrument);


		/// Return Type: int
		///firmCode: char*
		///groupCode: char*
		///lsInstruments: QDAPI_ArrayInstruments*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListToGroupWithDependentPricesGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetInstrumentListToGroupWithDependentPricesGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, ref QDAPI_ArrayInstruments lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///groupCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrumentFromGroupWithDependentPricesGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveInstrumentFromGroupWithDependentPricesGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///lsGroup: QDAPI_ArrayGroupsWithDependentPrices**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetGroupsWithDependentPricesListFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetGroupsWithDependentPricesListFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsGroup);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///group: QDAPI_GroupWithDependentPrices*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddGroupWithDependentPricesToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddGroupWithDependentPricesToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_GroupWithDependentPrices group);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///groupCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveGroupWithDependentPricesFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveGroupWithDependentPricesFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///groupCode: char*
		///lsInstruments: QDAPI_ArrayInstruments**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromGroupWithDependentMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetInstrumentListFromGroupWithDependentMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///groupCode: char*
		///instrument: QDAPI_Instrument*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrumentToGroupWithDependentPricesMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddInstrumentToGroupWithDependentPricesMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, ref QDAPI_Instrument instrument);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///groupCode: char*
		///lsInstruments: QDAPI_ArrayInstruments*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListToGroupWithDependentPricesMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetInstrumentListToGroupWithDependentPricesMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, ref QDAPI_ArrayInstruments lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///groupCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrumentFromGroupWithDependentPricesMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveInstrumentFromGroupWithDependentPricesMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string groupCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///value: boolean*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseGroupsForNonTemplateClientsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseGroupsForNonTemplateClientsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref bool value);


		/// Return Type: int
		///firmCode: char*
		///value: boolean
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseGroupsForNonTemplateClientsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseGroupsForNonTemplateClientsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///value: boolean*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseGlobalGroupsInMarginCalculationFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetUseGlobalGroupsInMarginCalculationFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref bool value);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///value: boolean
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseGlobalGroupsInMarginCalculationToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetUseGlobalGroupsInMarginCalculationToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value);


		/// Return Type: int
		///firmCode: char*
		///value: boolean*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetFuturesDiscountFromCollateralAmountFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetFuturesDiscountFromCollateralAmountFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref bool value);


		/// Return Type: int
		///firmCode: char*
		///value: boolean
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetFuturesDiscountFromCollateralAmountToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetFuturesDiscountFromCollateralAmountToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///value: boolean*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetFuturesDiscountFromCollateralAmountFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetFuturesDiscountFromCollateralAmountFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref bool value);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///value: boolean
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetFuturesDiscountFromCollateralAmountToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetFuturesDiscountFromCollateralAmountToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///value: boolean*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetHighRiskLevelClientsFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetHighRiskLevelClientsFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref bool value);


		/// Return Type: int
		///firmCode: char*
		///templateCode: char*
		///value: boolean
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetHighRiskLevelClientsToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetHighRiskLevelClientsToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value);


		/// Return Type: int
		///firmCode: char*
		///value: double*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetMDPlusMinMarginCalcRateFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetMDPlusMinMarginCalcRateFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref double value);


		/// Return Type: int
		///firmCode: char*
		///value: double
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetMDPlusMinMarginCalcRateToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetMDPlusMinMarginCalcRateToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, double value);


		/// Return Type: int
		///firmCode: char*
		///lsClasses: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsClasses);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToInstrumentsWithoutCurrencyRiskGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddClassToInstrumentsWithoutCurrencyRiskGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///lsInstruments: QDAPI_ArrayStrings**
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///lsInstruments: QDAPI_ArrayStrings*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


		/// Return Type: int
		///firmCode: char*
		///classCode: char*
		///secCode: char*
		[DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern int QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


        /// Return Type: int
        ///firmCode: char*
        ///lsClientLags: QDAPI_ArrayClientLag**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClientMarginSchemeListFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetClientMarginSchemeListFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsClientLags);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClientMarginSchemeFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveClientMarginSchemeFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///lagType: QDAPI_ClientLagType
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClientMarginSchemeToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_AddClientMarginSchemeToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, QDAPI_ClientLagType lagType);


        /// Return Type: int
        ///firmCode: char*
        ///lsClientLags: QDAPI_ArrayClientLag*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetClientMarginSchemeListToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetClientMarginSchemeListToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayClientLag lsClientLags);


        /// Return Type: int
        ///firmCode: char*
        ///futTrdacc: char*
        ///lsClientCodeToTrdAcc: QDAPI_ArrayClientCodeToTrdAcc**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetChangeFutClientCodesByFirmFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetChangeFutClientCodesByFirmFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string futTrdacc, ref System.IntPtr lsClientCodeToTrdAcc);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///commissionTypeAndRate: QDAPI_CommissionTypeAndRate**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionTypeAndSimpleRatesFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionTypeAndSimpleRatesFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///commissionTypeAndRate: QDAPI_CommissionTypeAndRate**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionTypeAndSimpleRatesFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionTypeAndSimpleRatesFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///commissionTypeAndRate: QDAPI_CommissionTypeAndRate*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionTypeAndSimpleRatesToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionTypeAndSimpleRatesToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_CommissionTypeAndRate commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///commissionTypeAndRate: QDAPI_CommissionTypeAndRate*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionTypeAndSimpleRatesToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionTypeAndSimpleRatesToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_CommissionTypeAndRate commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///TPName: char**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTPNameFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetTPNameFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr TPName);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///TPName: char**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTPNameFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetTPNameFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr TPName);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///TPName: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetTPNameToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetTPNameToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string TPName);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///TPName: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetTPNameToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetTPNameToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string TPName);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///repoCommissionRate: double*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetRepoBrokerRateFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetRepoBrokerRateFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref double repoCommissionRate);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///repoCommissionRate: double*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetRepoBrokerRateFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetRepoBrokerRateFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref double repoCommissionRate);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///repoCommissionRate: double
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetRepoBrokerRateToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetRepoBrokerRateToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, double repoCommissionRate);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///repoCommissionRate: double
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetRepoBrokerRateToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetRepoBrokerRateToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, double repoCommissionRate);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///commissionTypeAndRate: QDAPI_ArrayClassCommissionType**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionByClassesFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionByClassesFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///commissionTypeAndRate: QDAPI_ArrayClassCommissionType**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionByClassesFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionByClassesFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///commissionTypeAndRate: QDAPI_ArrayClassCommissionType*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionByClassesToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionByClassesToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayClassCommissionType commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///commissionTypeAndRate: QDAPI_ArrayClassCommissionType*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionByClassesToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionByClassesToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayClassCommissionType commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///lsBaseAssetCommission: QDAPI_ArrayBaseAssetCommissionRate**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetFuturesCommissionFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetFuturesCommissionFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsBaseAssetCommission);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///lsBaseAssetCommission: QDAPI_ArrayBaseAssetCommissionRate**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetFuturesCommissionFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetFuturesCommissionFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsBaseAssetCommission);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///lsBaseAssetCommission: QDAPI_ArrayBaseAssetCommissionRate*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetFuturesCommissionToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetFuturesCommissionToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayBaseAssetCommissionRate lsBaseAssetCommission);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///lsBaseAssetCommission: QDAPI_ArrayBaseAssetCommissionRate*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetFuturesCommissionToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetFuturesCommissionToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayBaseAssetCommissionRate lsBaseAssetCommission);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///commissionScaleJump: int*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleJumpFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleJumpFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref int commissionScaleJump);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///commissionScaleJump: int*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleJumpFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleJumpFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref int commissionScaleJump);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///commissionScaleJump: int
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleJumpToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleJumpToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int commissionScaleJump);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///commissionScaleJump: int
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleJumpToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleJumpToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, int commissionScaleJump);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///minMaxTurnover: QDAPI_ScaleCommExParams**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleRestrictionsFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleRestrictionsFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr minMaxTurnover);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///minMaxTurnover: QDAPI_ScaleCommExParams**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleRestrictionsFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleRestrictionsFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr minMaxTurnover);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///minMaxTurnover: QDAPI_ScaleCommExParams*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleRestrictionsToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleRestrictionsToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ScaleCommExParams minMaxTurnover);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///minMaxTurnover: QDAPI_ScaleCommExParams*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleRestrictionsToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleRestrictionsToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ScaleCommExParams minMaxTurnover);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///scale: QDAPI_ArrayOfScaleRates**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleRatesFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleRatesFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr scale);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///scale: QDAPI_ArrayOfScaleRates**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleRatesFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleRatesFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr scale);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///scale: QDAPI_ArrayOfScaleRates*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleRatesToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleRatesToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref QDAPI_ArrayOfScaleRates scale);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///scale: QDAPI_ArrayOfScaleRates*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleRatesToClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleRatesToClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref QDAPI_ArrayOfScaleRates scale);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCommissionScaleFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveCommissionScaleFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCommissionScaleFromClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveCommissionScaleFromClientTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName);


        /// Return Type: int
        ///firmCode: char*
        ///commissionTypeAndRate: QDAPI_ArrayClassCommissionType**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionByClassesFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionByClassesFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///commissionTypeAndRate: QDAPI_ArrayClassCommissionType*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionByClassesToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionByClassesToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayClassCommissionType commissionTypeAndRate);


        /// Return Type: int
        ///firmCode: char*
        ///lsBaseAssetCommission: QDAPI_ArrayBaseAssetCommissionRate**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetFuturesCommissionFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetFuturesCommissionFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsBaseAssetCommission);


        /// Return Type: int
        ///firmCode: char*
        ///lsBaseAssetCommission: QDAPI_ArrayBaseAssetCommissionRate*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetFuturesCommissionToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetFuturesCommissionToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayBaseAssetCommissionRate lsBaseAssetCommission);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithWeightAndRestrictionsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityWeightFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetSecurityWeightFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithWeightAndRestrictionsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityWeightFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetSecurityWeightFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithWeightAndRestrictionsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSecurityWeightFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetSecurityWeightFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithCoeffsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithCoefficientsFromGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithCoefficientsFromGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithCoeffsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithCoefficientsFromMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithCoefficientsFromMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithCoeffsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithCoefficientsFromClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithCoefficientsFromClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithRestrictionsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithPositionRestrictionFromGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithPositionRestrictionFromGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithRestrictionsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithPositionRestrictionFromMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithPositionRestrictionFromMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithRestrictionsList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithPositionRestrictionFromClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithPositionRestrictionFromClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithVarianceList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithVarianceList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithVarianceList**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref System.IntPtr lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithWeightAndRestrictionsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityWeightToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetSecurityWeightToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_SecsWithWeightAndRestrictionsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithWeightAndRestrictionsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityWeightToMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetSecurityWeightToMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_SecsWithWeightAndRestrictionsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithWeightAndRestrictionsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSecurityWeightToClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetSecurityWeightToClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_SecsWithWeightAndRestrictionsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///sec: QDAPI_SecWithCoeffs*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentCoefficientsToGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentCoefficientsToGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_SecWithCoeffs sec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///sec: QDAPI_SecWithCoeffs*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentCoefficientsToMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentCoefficientsToMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_SecWithCoeffs sec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///sec: QDAPI_SecWithCoeffs*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentCoefficientsToClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentCoefficientsToClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_SecWithCoeffs sec);


        /// Return Type: int
        ///firmCode: char*
        ///sec: QDAPI_SecWithRestrictions*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentPositionRestrictionToGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentPositionRestrictionToGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_SecWithRestrictions sec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///sec: QDAPI_SecWithRestrictions*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentPositionRestrictionToMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentPositionRestrictionToMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_SecWithRestrictions sec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///sec: QDAPI_SecWithRestrictions*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentPositionRestrictionToClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentPositionRestrictionToClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_SecWithRestrictions sec);


        /// Return Type: int
        ///firmCode: char*
        ///sec: QDAPI_SecWithVariance*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentRepoDiscountRestrictionToGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentRepoDiscountRestrictionToGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_SecWithVariance sec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///sec: QDAPI_SecWithVariance*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentRepoDiscountRestrictionToMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentRepoDiscountRestrictionToMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_SecWithVariance sec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///sec: QDAPI_SecWithVariance*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentRepoDiscountRestrictionToClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentRepoDiscountRestrictionToClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_SecWithVariance sec);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithCoeffsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithCoefficientsToGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithCoefficientsToGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_SecsWithCoeffsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithCoeffsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithCoefficientsToMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithCoefficientsToMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_SecsWithCoeffsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithCoeffsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithCoefficientsToClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithCoefficientsToClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_SecsWithCoeffsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithRestrictionsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithPositionRestrictionToGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithPositionRestrictionToGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_SecsWithRestrictionsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithRestrictionsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithPositionRestrictionToMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithPositionRestrictionToMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_SecsWithRestrictionsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithRestrictionsList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithPositionRestrictionToClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithPositionRestrictionToClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_SecsWithRestrictionsList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///lsSec: QDAPI_SecsWithVarianceList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithRepoDiscountRestrictionToGlobalSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithRepoDiscountRestrictionToGlobalSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_SecsWithVarianceList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithVarianceList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithRepoDiscountRestrictionToMarginTemplateSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithRepoDiscountRestrictionToMarginTemplateSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, ref QDAPI_SecsWithVarianceList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///lsSec: QDAPI_SecsWithVarianceList*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListWithRepoDiscountRestrictionToClientSettingsSecurityWeight", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListWithRepoDiscountRestrictionToClientSettingsSecurityWeight([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, ref QDAPI_SecsWithVarianceList lsSec);


        /// Return Type: int
        ///firmCode: char*
        ///secCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityWeightForInstrumentFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveSecurityWeightForInstrumentFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        ///secCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityWeightForInstrumentFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveSecurityWeightForInstrumentFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        ///secCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSecurityWeightForInstrumentFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveSecurityWeightForInstrumentFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


        /// Return Type: int
        ///firmCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllSecurityWeightFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllSecurityWeightFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///limitKind: int
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllSecurityWeightFromMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllSecurityWeightFromMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, int limitKind);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///limitKind: int
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllSecurityWeightFromClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllSecurityWeightFromClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, int limitKind);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedCPSC: QDAPI_ArrayProhibitedCPAndSettlementCurrency**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetProhibitedCPAndSettlementCurrencyFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetProhibitedCPAndSettlementCurrencyFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsProhibitedCPSC);


        /// Return Type: int
        ///firmCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedSC: QDAPI_ArrayProhibitedSettlementCurrency**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsProhibitedSC);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedCPSC: QDAPI_ArrayProhibitedCPAndSettlementCurrency*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetProhibitedCPAndSettlementCurrencyToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetProhibitedCPAndSettlementCurrencyToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayProhibitedCPAndSettlementCurrency lsProhibitedCPSC);


        /// Return Type: int
        ///firmCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedSC: QDAPI_ArrayProhibitedSettlementCurrency*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayProhibitedSettlementCurrency lsProhibitedSC);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///cP: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedCPSC: QDAPI_ArrayProhibitedCPAndSettlementCurrency**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetProhibitedCPAndSettlementCurrencyFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetProhibitedCPAndSettlementCurrencyFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsProhibitedCPSC);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedSC: QDAPI_ArrayProhibitedSettlementCurrency**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsProhibitedSC);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedCPSC: QDAPI_ArrayProhibitedCPAndSettlementCurrency*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetProhibitedCPAndSettlementCurrencyToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetProhibitedCPAndSettlementCurrencyToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayProhibitedCPAndSettlementCurrency lsProhibitedCPSC);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedSC: QDAPI_ArrayProhibitedSettlementCurrency*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayProhibitedSettlementCurrency lsProhibitedSC);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepoCP: QDAPI_ArrayRestrictREPOWithCPBasedOnTerm**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetRestrictREPOWithCPBasedOnTermFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetRestrictREPOWithCPBasedOnTermFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictRepoCP);


        /// Return Type: int
        ///firmCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepo: QDAPI_ArrayRestrictREPOBasedOnTerm**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictRepo);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepoCP: QDAPI_ArrayRestrictREPOWithCPBasedOnTerm*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetRestrictREPOWithCPBasedOnTermToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetRestrictREPOWithCPBasedOnTermToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictREPOWithCPBasedOnTerm lsRestrictRepoCP);


        /// Return Type: int
        ///firmCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepo: QDAPI_ArrayRestrictREPOBasedOnTerm*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictREPOBasedOnTerm lsRestrictRepo);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepoCP: QDAPI_ArrayRestrictREPOWithCPBasedOnTerm**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetRestrictREPOWithCPBasedOnTermFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetRestrictREPOWithCPBasedOnTermFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictRepoCP);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepo: QDAPI_ArrayRestrictREPOBasedOnTerm**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictRepo);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepoCP: QDAPI_ArrayRestrictREPOWithCPBasedOnTerm*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetRestrictREPOWithCPBasedOnTermToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetRestrictREPOWithCPBasedOnTermToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictREPOWithCPBasedOnTerm lsRestrictRepoCP);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictRepo: QDAPI_ArrayRestrictREPOBasedOnTerm*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictREPOBasedOnTerm lsRestrictRepo);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///cP: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string cP, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMVSC: QDAPI_ArrayRestrictMaxValueForSettlementCurrency**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetRestrictMaxValueForSettlementCurrencyFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetRestrictMaxValueForSettlementCurrencyFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictMVSC);


        /// Return Type: int
        ///firmCode: char*
        ///settlementCurrency: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMV: QDAPI_ArrayRestrictMaxValue**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settlementCurrency, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictMV);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMVSC: QDAPI_ArrayRestrictMaxValueForSettlementCurrency*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetRestrictMaxValueForSettlementCurrencyToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetRestrictMaxValueForSettlementCurrencyToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictMaxValueForSettlementCurrency lsRestrictMVSC);


        /// Return Type: int
        ///firmCode: char*
        ///settlementCurrency: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMV: QDAPI_ArrayRestrictMaxValue*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settlementCurrency, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictMaxValue lsRestrictMV);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///settlementCurrency: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settlementCurrency);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMVSC: QDAPI_ArrayRestrictMaxValueForSettlementCurrency**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictMVSC);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settlementCurrency: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMV: QDAPI_ArrayRestrictMaxValue**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settlementCurrency, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsRestrictMV);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMVSC: QDAPI_ArrayRestrictMaxValueForSettlementCurrency*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetRestrictMaxValueForSettlementCurrencyToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetRestrictMaxValueForSettlementCurrencyToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictMaxValueForSettlementCurrency lsRestrictMVSC);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settlementCurrency: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsRestrictMV: QDAPI_ArrayRestrictMaxValue*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settlementCurrency, QDAPI_SettingsScope settingsScope, ref QDAPI_ArrayRestrictMaxValue lsRestrictMV);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///settlementCurrency: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplat" +
            "e", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string settlementCurrency);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///lsClasses: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsClasses);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToInstrumentsWithoutCurrencyRiskMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_AddClassToInstrumentsWithoutCurrencyRiskMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        ///secCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        ///secCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///lsClasses: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsClasses);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddClassToInstrumentsWithoutCurrencyRiskClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_AddClassToInstrumentsWithoutCurrencyRiskClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        ///secCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        ///secCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskClientSettings([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string secCode);

        
        /// Return Type: int
        ///firmCode: char*
        ///lsTarifPlans: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTPList", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetTPList([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsTarifPlans);


        /// Return Type: int
        ///firmCode: char*
        ///tPName: char*
        ///lsClassGroups: QDAPI_ArrayClassGroups**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetTPSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetTPSettings([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string tPName, ref System.IntPtr lsClassGroups);


        /// Return Type: int
        ///firmCode: char*
        ///tPName: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveTPSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveTPSettings([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string tPName);


        /// Return Type: int
        ///firmCode: char*
        ///tPName: char*
        ///lsClassGroups: QDAPI_ArrayClassGroups*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetTPSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetTPSettings([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string tPName, ref QDAPI_ArrayClassGroups lsClassGroups);


        /// Return Type: int
        ///firmCode: char*
        ///useCommissionScale: boolean*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetUseCommissionScaleFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetUseCommissionScaleFromGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref bool useCommissionScale);


        /// Return Type: int
        ///firmCode: char*
        ///useCommissionScale: boolean
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetUseCommissionScaleToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetUseCommissionScaleToGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [MarshalAsAttribute(UnmanagedType.I1)] bool useCommissionScale);


        /// Return Type: int
        ///firmCode: char*
        ///useCommissionScaleJump: boolean*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleJumpFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleJumpFromGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref bool useCommissionScaleJump);


        /// Return Type: int
        ///firmCode: char*
        ///useCommissionScaleJump: boolean
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleJumpToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleJumpToGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [MarshalAsAttribute(UnmanagedType.I1)] bool useCommissionScaleJump);


        /// Return Type: int
        ///firmCode: char*
        ///minMaxTurnover: QDAPI_ScaleCommExParams**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleRestrictionsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleRestrictionsFromGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr minMaxTurnover);


        /// Return Type: int
        ///firmCode: char*
        ///minMaxTurnover: QDAPI_ScaleCommExParams*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleRestrictionsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleRestrictionsToGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ScaleCommExParams minMaxTurnover);


        /// Return Type: int
        ///firmCode: char*
        ///lsScalesAndRates: QDAPI_ArrayOfScaleRates**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetCommissionScaleRatesFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetCommissionScaleRatesFromGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsScalesAndRates);


        /// Return Type: int
        ///firmCode: char*
        ///lsScalesAndRates: QDAPI_ArrayOfScaleRates*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetCommissionScaleRatesToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetCommissionScaleRatesToGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayOfScaleRates lsScalesAndRates);


        /// Return Type: int
        ///firmCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveCommissionScaleFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveCommissionScaleFromGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///lsInstruments: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromSecurityAllowedRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListFromSecurityAllowedRestrictionTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///lsInstruments: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveInstrumentListFromSecurityAllowedRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveInstrumentListFromSecurityAllowedRestrictionTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllFromSecurityAllowedRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllFromSecurityAllowedRestrictionTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllFromSecurityRestrictedRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllFromSecurityRestrictedRestrictionTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllFromSecurityRestrictedGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllFromSecurityRestrictedGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedREPOInstruments: QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsProhibitedREPOInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///lsProhibitedREPOInstruments: QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, ref System.IntPtr lsProhibitedREPOInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        ///templateCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode);


        /// Return Type: int
        ///firmCode: char*
        ///settingsScope: QDAPI_SettingsScope
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, QDAPI_SettingsScope settingsScope);


        /// Return Type: int
        ///firmCode: char*
        ///lsClassCodes: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromRestrictOpenSecurityGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetClassListFromRestrictOpenSecurityGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsClassCodes);


        /// Return Type: int
        ///firmCode: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListForClassToRestrictOpenSecurityGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListForClassToRestrictOpenSecurityGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///classCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromRestrictOpenSecurityGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveClassFromRestrictOpenSecurityGlobal([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///lsClassCodes: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromRestrictOpenSecurityClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetClassListFromRestrictOpenSecurityClientTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, ref System.IntPtr lsClassCodes);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///templateName: char*
        ///classCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromRestrictOpenSecurityClientTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveClassFromRestrictOpenSecurityClientTemplate([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string templateName, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///lsClassCodes: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetClassListFromRestrictOpenSecurityClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetClassListFromRestrictOpenSecurityClientSettings([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsClassCodes);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientSettings([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref System.IntPtr lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        ///lsInstruments: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientSettings([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode, ref QDAPI_ArrayStrings lsInstruments);


        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///classCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint = "QDAPI_RemoveClassFromRestrictOpenSecurityClientSettings", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int QDAPI_RemoveClassFromRestrictOpenSecurityClientSettings([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string classCode);

        /// Return Type: int
        ///firmCode: char*
        ///value: boolean*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetComplexInstrumentsAccessControlFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetComplexInstrumentsAccessControlFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref bool value) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///value: boolean
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetComplexInstrumentsAccessControlToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetComplexInstrumentsAccessControlToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        ///lsApproves: QDAPI_ArrayClientFIApproves**
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetComplexFIApprovedClientsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetComplexFIApprovedClientsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode, ref System.IntPtr lsApproves) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///lsApproves: QDAPI_ArrayClientFIApproves*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_AddComplexFIApprovedClientsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_AddComplexFIApprovedClientsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayClientFIApproves lsApproves) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///lsApproves: QDAPI_ArrayClientFIApproves*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetComplexFIApprovedClientsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetComplexFIApprovedClientsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayClientFIApproves lsApproves) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///clientCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_RemoveComplexFIApprovedClientsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_RemoveComplexFIApprovedClientsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string clientCode) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///value: boolean*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetQualifiedInvestorsSignFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetQualifiedInvestorsSignFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref bool value) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///value: boolean
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetQualifiedInvestorsSignToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetQualifiedInvestorsSignToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///lsApproves: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetAccessToComplexInstrumentsFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetAccessToComplexInstrumentsFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsApproves) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///lsApproves: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetAccessToComplexInstrumentsToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetAccessToComplexInstrumentsToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayStrings lsApproves) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///complexityType: char*
        ///lsComplexSecs: QDAPI_ArrayComplexInstruments**
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetComplexInstrumentsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetComplexInstrumentsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string complexityType, ref System.IntPtr lsComplexSecs) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///lsComplexSecs: QDAPI_ArrayComplexInstruments*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_AddComplexInstrumentsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_AddComplexInstrumentsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayComplexInstruments lsComplexSecs) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///lsComplexSecs: QDAPI_ArrayComplexInstruments*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetComplexInstrumentsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetComplexInstrumentsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayComplexInstruments lsComplexSecs) ;


        /// Return Type: int
        ///firmCode: char*
        ///complexityType: char*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_RemoveComplexInstrumentsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_RemoveComplexInstrumentsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string complexityType) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///value: boolean*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetClientCvalSignFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetClientCvalSignFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref bool value) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///value: boolean
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetClientCvalSignToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetClientCvalSignToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [MarshalAsAttribute(UnmanagedType.I1)] bool value) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///lsClients: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetClientCvalListFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetClientCvalListFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr lsClients) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///lsClients: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetClientCvalListToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetClientCvalListToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings lsClients) ;


        /// Return Type: int
        ///firmCode: char*
        /// instrumentsTypes: QDAPI_ArrayStrings**
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetComplexInstrumentsTypesWithoutRestrictionsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetComplexInstrumentsTypesWithoutRestrictionsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref System.IntPtr instrumentsTypes) ;


        /// Return Type: int
        ///firmCode: char*
        /// instrumentsTypes: QDAPI_ArrayStrings*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetComplexInstrumentsTypesWithoutRestrictionsToGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetComplexInstrumentsTypesWithoutRestrictionsToGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, ref QDAPI_ArrayStrings instrumentsTypes) ;

    
        /// Return Type: int
        ///firmCode: char*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_RemoveComplexInstrumentsTypesWithoutRestrictionsFromGlobal", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_RemoveComplexInstrumentsTypesWithoutRestrictionsFromGlobal([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///lsLeverages: QDAPI_ArrayDoubleNumbers**
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_GetIncludeClientsWithLeverageFromRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_GetIncludeClientsWithLeverageFromRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref System.IntPtr lsLeverages) ;

    
        /// Return Type: int
        ///firmCode: char*
        ///templateCode: char*
        ///lsLeverages: QDAPI_ArrayDoubleNumbers*
        [DllImportAttribute("QDealerAPI", EntryPoint="QDAPI_SetIncludeClientsWithLeverageToRestrictionTemplate", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern  int QDAPI_SetIncludeClientsWithLeverageToRestrictionTemplate([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string firmCode, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string templateCode, ref QDAPI_ArrayDoubleNumbers lsLeverages) ;

    }
}