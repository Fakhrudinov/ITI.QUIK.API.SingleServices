// В тех настройках, где требуется указание <Кода клиента>, для получения глобальной настройки
//   используется в качестве <Кода клиента> значение NULL. Значение <Код клиента> равное ""
//   будет проигнорировано, поскольку задание настроек на пустой код клиента не допустимо.
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
	QDAPI_ERROR_SUCCESS                            = 0    // Успешное выполнение.
	, QDAPI_ERROR_QADMINSRV                        = 1    // Ошибка на стороне сервера QAdminSrv
	, QDAPI_ERROR_NOT_INITIALIZED                  = 2    // Неверный формат файла настроек библиотеки. Заданы не все параметры, необходимые для доступа к Серверу QA.
	, QDAPI_ERROR_CONNECT_FAILED                   = 3    // Соединение не может быть установлено. Ошибка установления соединения.
	, QDAPI_ERROR_CONNECT_ALREADYUSE               = 4    // Соединение не может быть установлено. Подключающийся UID уже используется в другом соединении.
	, QDAPI_ERROR_NOT_CONNECTED                    = 5    // Соединение не установлено. Соединение не было установлено. Работа невозможна.
	, QDAPI_ERROR_TIMEOUT                          = 6    // Ответ не получен. Возникает при длительном ожидании ответа от Сервера QA и превышении таймаута на такое ожидание.
	, QDAPI_ERROR_CONNECTION_LOST                  = 7    // Соединение потеряно. Возникает при разрыве соединения с Сервером QA. Статус выполнения последней команды не определён.
	, QDAPI_ERROR_NO_RIGHTS                        = 8    // Нехватка прав на данную операцию.
	, QDAPI_ERROR_DL_NOT_FOUND                     = 9    // По данной фирме отсутствуют настройки БРЛ.
	, QDAPI_ERROR_DL_READ_PROHIBITED               = 10   // Доступ к настройкам БРЛ запрещён. Отсутствие прав на доступ к настройкам БРЛ.
	, QDAPI_ERROR_DL_WRITE_PROHIBITED              = 11   // Доступ на запись к настройкам БРЛ запрещён. Отсутствие прав на изменение на доступ к настройкам БРЛ.
	, QDAPI_ERROR_DL_WRITE_NOT_AVAILABLE           = 12   // Текущий доступ к настройкам БРЛ не допускает их изменения.
	, QDAPI_ERROR_UPDATE_FILE                      = 13   // Ошибка сохранения файла.

	, QDAPI_ERROR_UNCLASSIFIED                     = 1001 // Общая ошибка.
	, QDAPI_ERROR_NOT_LOADED_SETTINGS_FOR_FIRM     = 1002 // Недопустимый код фирмы для доступа к настройкам БРЛ.
	, QDAPI_ERROR_INCORRECT_PARAMETER              = 1003 // Недопустимый параметр функции.
	, QDAPI_ERROR_DATA_NOT_FOUND                   = 1004 // Данные не найдены.
	, QDAPI_ERROR_FAILED_RELEASE_MEMORY            = 1005 // Ошибка освобождения памяти.
	, QDAPI_ERROR_IMPOSSIBLE_ALLOCATE_MEMORY       = 1006 // Ошибка выделения памяти.
	, QDAPI_ERROR_IMPOSSIBLE_OPEN_FILE             = 1007 // Ошибка открытия файла.
	, QDAPI_ERROR_IMPOSSIBLE_CLOSE_FILE            = 1008 // Ошибка сохранения файла.
	, QDAPI_ERROR_NO_VALID_LENGTH_CLASS_CODE       = 1009 // Недопустимая длина кода класса.
	, QDAPI_ERROR_NO_VALID_LENGTH_CLIENT_CODE      = 1010 // Недопустимая длина кода клиента.
	, QDAPI_ERROR_NO_VALID_LENGTH_CURR_CODE        = 1011 // Недопустимая длина кода валюты.
	, QDAPI_ERROR_NO_VALID_LENGTH_FIRM_CODE        = 1012 // Недопустимая длина кода фирмы.
	, QDAPI_ERROR_NO_VALID_LENGTH_SEC_CODE         = 1013 // Недопустимая длина кода инструмента.
	, QDAPI_ERROR_NO_VALID_LENGTH_TRADE_ACCOUNT    = 1014 // Недопустимая длина кода торгового счёта.
	, QDAPI_ERROR_TEMPLATE_NOT_FOUND               = 1015 // Шаблон не найден.
	, QDAPI_ERROR_DATA_ALREADY_EXIST               = 1016 // Такие данные уже существуют.
	, QDAPI_ERROR_NO_VALID_LENGTH_PARTNER_CODE     = 1017 // Недопустимая длина кода контрагента.
	, QDAPI_ERROR_NO_VALID_LENGTH_SETTLE_CODE      = 1018 // Недопустимая длина кода расчетов.
	, QDAPI_ERROR_NOT_SUPPORTED                    = 1019 // Данная настройка не поддерживается.
	, QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND        = 1020  // Клиентские настройки не найдены.
	, QDAPI_ERROR_NO_VALID_LENGTH_TEMPLATE_CODE    = 1021  // Недопустимая длина кода шаблона.
	, QDAPI_ERROR_NO_VALID_LENGTH_TAG_CODE         = 1022  // Недопустимая длина тэг-кода.
};

enum QDAPI_SettingsScope {
	QDAPI_SETTINGS_SCOPE_MAIN = 0
	, QDAPI_SETTINGS_SCOPE_ADDITIONAL = 1
};

#pragma pack(push)
#pragma pack(4)
//==============================================================================
// Объявления типов
//==============================================================================
// Массив строк
struct QDAPI_ArrayStrings {
	size_t count;
	char** elems;
};
//==============================================================================
// Массив целых чисел
struct QDAPI_ArrayIntNumbers {
	size_t count;
	int* elems;
};
//==============================================================================
// Пара (строка, строка)
struct QDAPI_StringToString {
	char* fst;
	char* snd;
};
//==============================================================================
// Ограничение торговли опционами
struct QDAPI_RestrictOptionOrdersBody {
	int day;                                                                    // День граничной даты исполнения
	int month;                                                                  // Месяц граничной даты исполнения
	int year;                                                                   // Год граничной даты исполнения
	double max_dev_strike;                                                      // Максимальное отклонение страйка
};
// Ограничение торговли опционами на базовый актив
struct QDAPI_RestrictOptionOrders {
	char* base_asset;
	QDAPI_RestrictOptionOrdersBody restrBody;
};
// Список ограничений торговли опционами на базовые активы
struct QDAPI_ArrayRestrictOptionOrders {
	size_t count;
	QDAPI_RestrictOptionOrders* elems;
};
//==============================================================================
// Дисконты
struct QDAPI_Discounts {
	double KLong;
	double KShort;
	double DLong;
	double DShort;
	double DLong_min;
	double DShort_min;
};
//==============================================================================
enum QDAPI_PriceType {                                                            // Идентификаторы типов цен
	QDAPI_PRICE_TYPE__DEFAULT = 0                                                 // Не задан
	, QDAPI_PRICE_TYPE__WAPRICE = 1                                               // Текущая средневзвешенная
	, QDAPI_PRICE_TYPE__LAST = 2                                                  // Цена последней сделки
	, QDAPI_PRICE_TYPE__OPEN = 3                                                  // Цена открытия
	, QDAPI_PRICE_TYPE__MARKETPRICE = 4                                           // Рыночная цена вчерашнего дня
	, QDAPI_PRICE_TYPE__PREVPRICE = 5                                             // Цена закрытия
	, QDAPI_PRICE_TYPE__THEORPRICE = 6                                            // Теоретическая цена опциона
	, QDAPI_PRICE_TYPES_COUNT
};
// Структура для описания параметров отклонений цен по классам или инструментам
struct QDAPI_PriceTypeAndPercent {
	QDAPI_PriceType priceType;                                                  // Тип цены
	double deviationPercent;                                                    // Отклонение цены в процентах
};
struct QDAPI_PriceLimit {
	char activeCode[13];                                                        // Код класса или инструмента (в зависимости от настройки)
	QDAPI_PriceType priceType;                                                  // Тип цены
	double deviationPercent;                                                    // Отклонение цены в процентах
};
struct QDAPI_ArrayPriceLimit {
	size_t count;
	QDAPI_PriceLimit* elems;
};
// Структура для описания параметров отклонений цен по классам или инструментам
struct QDAPI_VolumeRestrictionByAvgTurnover {
	QDAPI_ArrayStrings classList;                                               // список классов
	QDAPI_ArrayStrings instrList;                                               // список инструментов
	double restPercent;                                                         // Ограничение, %
	double alertPercent;                                                        // Предупреждение, %
	char valuationClass[13];                                                    // Класс оценки
};
struct QDAPI_ArrayVolumeRestrictionByAvgTurnover {
	size_t count;
	QDAPI_VolumeRestrictionByAvgTurnover* elems;
};
struct QDAPI_VolumeRestriction {
	char classCode[13];                                                         // Код класса
	double restPercent;                                                         // Ограничение, %
	double alertPercent;                                                        // Предупреждение, %
	char valuationClass[13];                                                    // Класс оценки
};
struct QDAPI_ArrayVolumeRestriction {
	size_t count;
	QDAPI_VolumeRestriction* elems;
};
// Структура для описания направленности операции
enum QDAPI_OperationSide {
	QDAPI_SIDE_NOT_CONSIDERED = 0                                               // Направленность не важна
	, QDAPI_SIDE_ANY = 1                                                        // Любая направленность
	, QDAPI_SIDE_BUY = 2                                                        // Покупка
	, QDAPI_SIDE_SELL = 3                                                       // Продажа
};
// Структура для описания списка инструментов (с учётом направленности)
struct QDAPI_SecurityBySide {
	char secCode[13];
	QDAPI_OperationSide side;
};
struct QDAPI_ArraySecurityBySide {
	size_t count;
	QDAPI_SecurityBySide* elems;
};
// Структура для описания списка классов (с учётом направленности)
struct QDAPI_ClassBySide {
	char classCode[13];
	QDAPI_OperationSide side;
};
struct QDAPI_ArrayClassBySide {
	size_t count;
	QDAPI_ClassBySide* elems;
};
// ПГО API
// Структура для описания списка пар - спот-актив/коэффициент лотности
struct QDAPI_AdditionalSpotActive {
	char spotCode[13];                                                          // код спот-актива
	double lotRatio;                                                            // коэффициент лотности. Значение 0 соответствует отсутствию значения коэффициента лотности в настройках
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
	char boardTag[13];                                                          // тег, пустая строка соответствует отсутствию настройки
	char currency[4];                                                           // валюта, пустая строка соответствует отсутствию настройки
	bool isLimitKind;                                                           // задан ли вид лимита
	int limitKind;                                                              // вид лимита
	int optionLiquidationValueByTheoreticalPrice;                               // учет теор. цены при расчете ликв. стоим. опционов. Возможные значения 0 и 1.
	bool isPortfolioValueMode;                                                  // задан ли режим учета вариационной маржи
	QDAPI_PortfolioValueMode portfolioValueMode;                                // режим учета вариационной маржи
	int useFullPortfolioValue;                                                  // использование полной стоимости портфеля. Возможные значения 0 (соответствует отсутствию значения) и 1.
};
struct QDAPI_SpreadTier {
	char tierName[13];                                                          // наименование слоя
	int tierTerm;                                                               // ограничение срока
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
	char firstTier[13];                                                         // первый слой
	char secondTier[13];                                                        // второй слой
	double longRate;                                                            // коэффициент лонг
	double shortRate;                                                           // коэффициент шорт, значение 0 соответствует отсутствию значения
};
struct QDAPI_InterSpread {
	char baseAsset[13];                                                         // базовый актив
	QDAPI_SpreadRatio spreadRatio;                                              // коэффициент для пары слоев
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
	QDAPI_OptionType optionType;                                                // тип опциона
	double strikeDeviation;                                                     // отклонение страйка
	double volatilityRatio;                                                     // коэффициент волатильности
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
	bool isBoundaryImpliedRisk;                                                 // задан ли вес краевых сценариев
	double boundaryImpliedRisk;                                                 // вес краевых сценариев
	bool isBoundaryPriceChange;                                                 // задан ли процент изменения цены для краевых сценариев
	double boundaryPriceChange;                                                 // процент изменения цены для краевых сценариев
	bool isExpMatDateTerm;                                                      // Задано ли количество дней до экспирации опциона
	double expMatDateTerm;                                                      // Количество дней до экспирации опциона
	bool isFuturesLiquidityFactor;                                              // Задана ли ставка ликвидности по фьючерсам
	double futuresLiquidityFactor;                                              // Ставка ликвидности по фьючерсам
	bool isKGO;                                                                 // Задан ли коэффициент клиентского ГО
	double KGO;                                                                 // Коэффициент клиентского ГО
	bool isMinShortOptionsIM;                                                   // Задана ли ставка минимального ГО по коротким опционам
	double minShortOptionsIM;                                                   // Ставка минимального ГО по коротким опционам
	bool isOptionDeltaType;                                                     // Задан ли способ учета дельты
	QDAPI_OptionDeltaType optionDeltaType;                                      // Способ учета дельты
	bool isOrderKGO;                                                            // Задано ли КГО для заявок
	double orderKGO;                                                            // КГО для заявок
	bool isOrderLimitationMode;                                                 // Задан ли порядок учета заявок
	QDAPI_OrderLimitationMode orderLimitationMode;                              // Порядок учета заявок
	bool isPriceScanRange;                                                      // Задана ли область сканирования
	double priceScanRange;                                                      // Область сканирования
	bool isPriceScanRangeType;                                                  // Задан ли способ определения области сканирования
	QDAPI_PriceScanRangeType priceScanRangeType;                                // Способ определения области сканирования
	bool isRestrictMaxVolatility;                                               // Задано ли ограничение максимальной волатильности
	double restrictMaxVolatility;                                               // Ограничение максимальной волатильности
	bool isRiskFreeRate;                                                        // Задана ли безрисковая ставка
	double riskFreeRate;                                                        // Безрисковая ставка
	bool isSpotVarMarginNeg;                                                    // Задана ли отрицательная вармаржа спот-актива
	double spotVarMarginNeg;                                                    // Отрицательная вармаржа спот-актива
	bool isSpotVarMarginPos;                                                    // Задана ли положительная вармаржа спот-актива
	double spotVarMarginPos;                                                    // Положительная вармаржа спот-актива
	QDAPI_ArrayInterSpread interSpread;                                         // Ставки межпортфельного спредового ГО
	QDAPI_ArrayIntraSpread intraSpread;                                         // Ставки межмесячного и межгруппового спредового ГО внутри портфеля
	bool isUseSpotNetting;                                                      // Задан ли взаимный неттинг спот-активов и фьючерсов
	int useSpotNetting;                                                         // Взаимный неттинг спот-активов и фьючерсов
	bool isVolatility;                                                          // Задана ли волатильность
	double volatility;                                                          // Волатильность
	bool isVolatilityChange;                                                    // Задано ли изменение волатильности
	double volatilityChange;                                                    // Изменение волатильности
	QDAPI_ArrayVolatilitySlope volatilitySlope;                                 // Волатильность по страйкам опционов
	bool isVolatilityType;                                                      // Задан ли способ задания волатильности опционов
	QDAPI_VolatilityType volatilityType;                                        // Способ задания волатильности опционов
};
struct QDAPI_PortfolioRiskConfigTemplateIdentifier {
	char* templateCode;                                                         // наименование шаблона
	char mainAsset[13];                                                         // код базового актива
};
struct QDAPI_ArrayPortfolioRiskConfigTemplateIdentifier {
	size_t count;
	QDAPI_PortfolioRiskConfigTemplateIdentifier* elems;
};
struct QDAPI_BaseAssetsSpreadOrder {
	char firstBaseAsset[13];                                                    // первый базовый актив
	char secondBaseAsset[13];                                                   // второй базовый актив
	int seqNumber;                                                              // порядковый номер вычисления спредового ГО
};
struct QDAPI_ArrayBaseAssetsSpreadOrder {
	size_t count;
	QDAPI_BaseAssetsSpreadOrder* elems;
};
struct QDAPI_TranoutTag {
	char nonTradeInstrument[13];                                                // инструмент МНП
	char classCode[13];                                                         // класс
	char currency[5];                                                           // валюта
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
	QDAPI_ArrayStrings lsInstruments;                                           // список инструментов
	bool isLongPosLimit;                                                        // признак задания ограничения максимального размера длинной позиции
	long long longPosLimit;                                                     // ограничение максимального размера длинной позиции
	bool isShortPosLimit;                                                       // признак задания ограничения максимального размера короткой позиции
	long long shortPosLimit;                                                    // ограничение максимального размера короткой позиции
};
struct QDAPI_ArrayMaxPositionLimit {
	size_t count;
	QDAPI_MaxPositionLimit* elems;
};
// Структура для описания запрещения по классу (с учётом торговых счетов и интервала времени)
struct QDAPI_RestrictSecurityByClass {
	QDAPI_ArrayStrings lsTradeAccounts;                                         // список торговых счетов (может быть пуст)
	bool isPeriodExists;                                                        // задан ли временной период
	int FromTimeHours;                                                          // начало периода: часы
	int FromTimeMinutes;                                                        // начало периода: минуты
	int TillTimeHours;                                                          // конец периода: часы
	int TillTimeMinutes;                                                        // конец периода: минуты
};
struct QDAPI_ArrayRestrictSecurityByClass {
	size_t count;
	QDAPI_RestrictSecurityByClass* elems;
};
// Структура для описания настроек запрещенных/разрешенных контрагентов и кодов расчетов
struct QDAPI_PartnersAndSettleCodesRestrictions {
	char classCode[15];                                                         // код класса
	QDAPI_ArrayStrings lsSettleCodes;                                           // список кодов расчетов
	QDAPI_OperationSide operationSide;                                          // направленность операции
	long long maxTerm;                                                          // максимальный срок РЕПО
	QDAPI_ArrayStrings lsCP;                                                    // список кодов контрагентов
};
struct QDAPI_ArrayPartnersAndSettleCodesRestrictions {
	size_t count;
	QDAPI_PartnersAndSettleCodesRestrictions* elems;
};
// Ограничения на минимальный объем
struct QDAPI_MinOrderQty {
	QDAPI_ArrayStrings lsClasses;                                               // список классов
	QDAPI_ArrayStrings lsInstruments;                                           // список инструментов
	long long qty;                                                              // ограничение минимального количества
};
struct QDAPI_ArrayMinOrderQty {
	size_t count;
	QDAPI_MinOrderQty* elems;
};
struct QDAPI_MinOrderValue {
	QDAPI_ArrayStrings lsClasses;                                               // список классов
	QDAPI_ArrayStrings lsInstruments;                                           // список инструментов
	double value;                                                               // ограничение минимального объема
	char currency[5];                                                           // валюта
};
struct QDAPI_ArrayMinOrderValue {
	size_t count;
	QDAPI_MinOrderValue* elems;
};
struct QDAPI_ClassMinOrderQty {
	char classCode[13];                                                         // класс
	long long qty;                                                              // ограничение минимального количества
};
struct QDAPI_ArrayClassMinOrderQty {
	size_t count;
	QDAPI_ClassMinOrderQty* elems;
};
struct QDAPI_ClassMinOrderValue {
	char classCode[13];                                                         // класс
	double value;                                                               // ограничение минимального количества
	char currency[5];                                                           // валюта
};
struct QDAPI_ArrayClassMinOrderValue {
	size_t count;
	QDAPI_ClassMinOrderValue* elems;
};

enum QDAPI_CommissionType {
	QDAPI_COMMISSION_TYPE_FIXED = 0                                             // процент от объема, значение по умолчанию
	, QDAPI_COMMISSION_TYPE_TRADE_MAX = 1                                       // максимум из процента от объема и суммы за сделку
	, QDAPI_COMMISSION_TYPE_TRADE_MIN = 2                                       // минимум из процента от объема и суммы за сделку
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
	QDAPI_BROK_COMM_TYPE_NO = 0                                                 // не задано
	, QDAPI_BROK_COMM_TYPE_FIXED = 1                                            // фиксированная комиссия в % от объема
	, QDAPI_BROK_COMM_TYPE_TURNOVER_SCALE = 2                                   // шкала комиссии от оборота
	, QDAPI_BROK_COMM_TYPE_TRADE = 3                                            // комиссия за сделку
	, QDAPI_BROK_COMM_TYPE_TRADE_FIXED_MAX = 4                                  // максимум между комиссией за сделку и фиксированной комиссией в % от объема
	, QDAPI_BROK_COMM_TYPE_ONESEC = 5                                           // комиссия за одну бумагу
	, QDAPI_BROK_COMM_TYPE_LOT = 6                                              // комиссия за один лот
	, QDAPI_BROK_COMM_TYPE_TRADE_LOT_MAX = 7                                    // максимум между комиссией за сделку и комиссией за одну бумагу
	, QDAPI_BROK_COMM_TYPE_COUNT
};

// Тип комиссии для классов, нужен так как для классов не существует шкальной комиссии
enum QDAPI_BrokCommTypeByClasses {
	QDAPI_BROK_COMM_TYPE_BY_CLASSES_NO = 0                                      // не задано
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_FIXED = 1                                 // фиксированная комиссия в % от объема
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE = 2                                 // комиссия за сделку
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_FIXED_MAX = 3                       // максимум между комиссией за сделку и фиксированной комиссией в % от объема
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_ONESEC = 4                                // комиссия за одну бумагу
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_LOT = 5                                   // комиссия за один лот
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_TRADE_LOT_MAX = 6                         // максимум между комиссией за сделку и комиссией за одну бумагу
	, QDAPI_BROK_COMM_TYPE_BY_CLASSES_COUNT
};

struct QDAPI_CommissionTypeAndRate {
	QDAPI_BrokCommType commissionType;                                          // тип комисии
	char TPName[13] = {};                                                       // название тарифного плана
	double brokerCommissionRate = -1;                                           // ставка фикисрованной комиссии в % от объема
	double tradeCommissionRate = -1;                                            // ставка комиссии за сделку в денежных ед
	double tradeLotCommissionRate = -1;                                         // ставка комиссии за один лот
	double oneSecCommissionRate = -1;                                           // ставка комиссии за бумагу
	double repoBrokerRate = -1;                                                 // ставка комиссии РЕПО % от объема за каждый день
};

struct QDAPI_ClassCommissionType {
	char classCode[13] = {};                                                    // код класса
	QDAPI_BrokCommTypeByClasses commissionType;                                 // тип комисии
	double rate1 = -1;                                                          // величина брокерской комиссии для типов комиссии FIXED, TRADE, TRADELOT, 1SEC. Для комиссий с выбором максимума (TRADE_MAX и TRADE_MAX_1SEC) – величина брокерской комиссии за сделку.
	double rate2 = -1;                                                          // только для типов комиссии с выбором максимума: для TRADE_MAX – фиксированная величина брокерской комиссии. Для TRADE_MAX_1SEC – величина брокерской комиссии за бумагу.
};

struct QDAPI_ArrayClassCommissionType {
	size_t count;
	QDAPI_ClassCommissionType* elems;
};

struct QDAPI_BaseAssetCommissionRate {
	char baseAsset[13];                                                         // код базового актива
	double rate = -1;                                                           // ставка комиссии
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
	double minValue = 0;                                                        // минимальное значение брокерской комиссии за день
	double maxValue = 0;                                                        // максимальное значение брокерской комиссии за день
	double minTurnover = 0;                                                     // минимальный дневной оборот, с которого начисляется комиссия по шкале
};

struct QDAPI_ScaleRate {
	double volume;                                                              // объем
	double rate;                                                                // ставка комиссии
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
	char groupName[256];	//имя множества
	char baseIndicator[13]; //базовый показатель
};

struct  QDAPI_ArrayGroupsWithDependentPrices {
	size_t count;
	QDAPI_GroupWithDependentPrices* elems;
};

struct QDAPI_Instrument {
	char secCode[13]; // наименование инструмента
	double relativeRiskRate; //риск
	int dependencyTrend; //тренд
};

struct QDAPI_ArrayInstruments {
	size_t	count;
	QDAPI_Instrument* elems;
};

struct QDAPI_SecWithWeightAndRestrictions {
	char secCode[13];                                                           // код инструмента
	double longCoeff;                                                           // дисконтирующий коэффициент для длиной позиции [0;1]
	double shortCoeff;                                                          // дисконтирующий коэффициент для короткой позиции [1;?]
	double longRestriction;                                                     // ограничение длиной позиции по инструменту [0;?]
	double shortRestriction;                                                    // ограничение короткой позиции по инструменту [0;?]
	double maxVariancePercent;                                                 // максимальный процент отклонения дисконта операции РЕПО-М от нижнего дисконта для операций покупки и от верхнего дисконта для операций  продажи. [0;100?]
};

struct QDAPI_WeightAndRestrictionForSec { 
	double longCoeff;                                                           // дисконтирующий коэффициент для длиной позиции [0;1]
	double shortCoeff;                                                          // дисконтирующий коэффициент для короткой позиции [1;?]
	double longRestriction;                                                     // ограничение длиной позиции по инструменту [0;?]
	double shortRestriction;                                                    // ограничение короткой позиции по инструменту [0;?]
	double maxVariancePercent;                                                 // максимальный процент отклонения дисконта операции РЕПО-М от нижнего дисконта для операций покупки и от верхнего дисконта для операций  продажи. [0;100?]
};

struct QDAPI_SecsWithWeightAndRestrictionsList {
	size_t  count;
	QDAPI_SecWithWeightAndRestrictions* elems;
};

struct QDAPI_SecWithVariance {
	char secCode[13];                                                           // код инструмента
	double maxVariancePercent;                                                 // максимальный процент отклонения дисконта операции РЕПО-М от нижнего дисконта для операций покупки и от верхнего дисконта для операций  продажи. [0;100?]
};

struct QDAPI_SecsWithVarianceList {
	size_t  count;
	QDAPI_SecWithVariance* elems;
};

struct QDAPI_SecWithRestrictions {
	char secCode[13];                                                           // код инструмента
	double longRestriction;                                                     // ограничение длиной позиции по инструменту [0;?]
	double shortRestriction;                                                    // ограничение короткой позиции по инструменту [0;?]
};

struct QDAPI_SecsWithRestrictionsList {
	size_t  count;
	QDAPI_SecWithRestrictions* elems;
};

struct QDAPI_SecWithCoeffs {
	char secCode[13];                                                           // код инструмента
	double longCoeff;                                                           // дисконтирующий коэффициент для длиной позиции [0;1]
	double shortCoeff;                                                          // дисконтирующий коэффициент для короткой позиции [1;?]
};

struct QDAPI_SecsWithCoeffsList {
	size_t  count;
	QDAPI_SecWithCoeffs* elems;
};

enum QDAPI_ClientLagType {
	QDAPI_LAG_BY_LIMIT = 1                                                      // по лимиту
	, QDAPI_LAG_BY_LEVERAGE = 2                                                 // по плечу
	, QDAPI_LAG_LIMIT_ON_OPEN_POSITION = 3                                      // лимит на открытую позицию
	, QDAPI_LAG_BY_DISCOUNTS = 4                                                // по дисконтам 
	, QDAPI_LAG_MDPLUS = 5                                                      // МД+
	, QDAPI_LAG_COUNT
};

struct QDAPI_ClientLag {
	char clientCode[13];                                                        // код клиента
	QDAPI_ClientLagType clientLag;                                              // тип кредитования
};

struct QDAPI_ArrayClientLag {
	size_t count = 0;
	QDAPI_ClientLag* elems;
};

struct QDAPI_ClientCodeToTrdAcc {
	char clientCode[13];                                                        // код клиента
	char tradeAcc[13];                                                          // торговый счет
};

struct QDAPI_ArrayClientCodeToTrdAcc {
	size_t count;
	QDAPI_ClientCodeToTrdAcc* elems;
};


struct QDAPI_ProhibitedCPAndSettlementCurrency {
	char cP[13];                                                                // код контрагента
	char settlementCurrency[5];                                                 // код валюты расчетов
	QDAPI_ArrayStrings lsClassCodes;                                            // список классов
	QDAPI_ArrayStrings lsInstrumentCodes;                                       // список инструментов
};

struct QDAPI_ArrayProhibitedCPAndSettlementCurrency {
	size_t count;
	QDAPI_ProhibitedCPAndSettlementCurrency* elems;
};

struct QDAPI_ProhibitedSettlementCurrency {
	char settlementCurrency[5];                                                 // код валюты расчетов
	QDAPI_ArrayStrings lsClassCodes;                                            // список классов
	QDAPI_ArrayStrings lsInstrumentCodes;                                       // список инструментов
};

struct QDAPI_ArrayProhibitedSettlementCurrency {
	size_t count;
	QDAPI_ProhibitedSettlementCurrency* elems;
};

struct QDAPI_RestrictREPOWithCPBasedOnTerm {
	char cP[13];                                                                // код контрагента
	char settlementCurrency[5];                                                 // код валюты расчетов
	char faceValueCurrency[5];                                                  // код валюты наминала
	QDAPI_ArrayStrings lsClassCodes;                                            // список классов
	int maxTerm;                                                                // максимальны срок репо
};

struct QDAPI_ArrayRestrictREPOWithCPBasedOnTerm {
	size_t count;
	QDAPI_RestrictREPOWithCPBasedOnTerm* elems;
};

struct QDAPI_RestrictREPOBasedOnTerm {
	char settlementCurrency[5];                                                 // код валюты расчетов
	char faceValueCurrency[5];                                                  // код валюты наминала
	QDAPI_ArrayStrings lsClassCodes;                                            // список классов
	int maxTerm;                                                                // максимальны срок репо
};

struct QDAPI_ArrayRestrictREPOBasedOnTerm {
	size_t count;
	QDAPI_RestrictREPOBasedOnTerm* elems;
};

struct QDAPI_RestrictMaxValueForSettlementCurrency {
	char settlementCurrency[5];                                                 // код валюты расчетов
	QDAPI_ArrayStrings lsClassCodes;                                            // список классов
	QDAPI_OperationSide side;                                                   // направление операции
	double maxValue;                                                            // максимальное значение
};

struct QDAPI_ArrayRestrictMaxValueForSettlementCurrency {
	size_t count;
	QDAPI_RestrictMaxValueForSettlementCurrency* elems;
};

struct QDAPI_RestrictMaxValue {
	QDAPI_ArrayStrings lsClassCodes;                                            // список классов
	QDAPI_OperationSide side;                                                   // направление операции
	double maxValue;                                                            // максимальное значение
};

struct QDAPI_ArrayRestrictMaxValue {
	size_t count;
	QDAPI_RestrictMaxValue* elems;
};

struct QDAPI_REPOBySideToTerm {
	bool isSideUsed = false;           // задано ли для данного направления
	QDAPI_ArrayIntNumbers maxTerms;    // список максимальных сроков РЕПО
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
	QDAPI_ArrayStrings lsClassCodes;        // список классов
	QDAPI_ScaleCommExParams scaleParams;    // minValue, maxValue, MinVolume
	QDAPI_ArrayOfScaleRates scaleRates;     // шкала комиссии
};

struct QDAPI_ArrayClassGroups {
	size_t count;
	QDAPI_ClassGroupWithScale* elems;
};

struct QDAPI_ComplexInstruments {
	char complexityType[13];                                                    // тип сложности 
	QDAPI_ArrayStrings lsClasses;                                               // список классов
	QDAPI_ArrayStrings lsInstruments;                                           // список инструментов
};

struct QDAPI_ArrayComplexInstruments {
	size_t count;
	QDAPI_ComplexInstruments* elems;
};

struct QDAPI_ClientFIApproves {
	char clientCode[13];                                                        // код клиента
	QDAPI_ArrayStrings lsApproves;                                              // списк разрешений
};
struct QDAPI_ArrayClientFIApproves {
	size_t count;
	QDAPI_ClientFIApproves* elems;
};
#pragma pack(pop)

// Инициирует установку соединения с Сервером QA
// В случае ошибки выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_Connect(
		const char* lpszIniFile                                                 // (in) файл настроек
		, const char* lpszUserName                                              // (in) логин
		, const char* lpszUserPassword                                          // (in) пароль
		, char** lpszError );                                                   // (out) сообщение об ошибке, в функцию передаётся адрес указателя

// Завершает работу и разрывает соединение
QDEALERAPI_API int _stdcall QDAPI_Disconnect();

// Получение списка фирм, по которым имеются настройки БРЛ
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_DLGetFirmList(
	    QDAPI_ArrayStrings** ppFirmCodes );                                     // (out) список кодов фирм дилерских библиотек, в функцию передаётся адрес указателя

// Начало работы с настройками БРЛ
QDEALERAPI_API int _stdcall QDAPI_DLOpenFile(
		const char* lpszFirmCode                                                // (in) код фирмы
		, int nMode );                                                          // режим открытия файла; 0 - чтение/запись, 1 - только чтение

// Сохранение изменённых настроек
QDEALERAPI_API int _stdcall QDAPI_DLUpdateFile(
		const char* lpszFirmCode );                                             // (in) код фирмы

// Закрытие файла настроек БРЛ без сохранения изменений
QDEALERAPI_API int _stdcall QDAPI_DLCloseFile(
		const char* lpszFirmCode );                                             // (in) код фирмы

// Освобождение памяти
QDEALERAPI_API int _stdcall QDAPI_FreeMemory(
		void** pMem );                                                          // (in-out) адрес указателя на освобождаемую область памяти

//ClientTemplate
#pragma region //======================== AllowedPartnersAndSettleCodes =======================
// Добавление указанных "кода расчета РЕПО/РПС" и "кода контрагента" в настройки на класс
// В случае необходимости добавления только "кода расчета РЕПО/РПС", параметр "код контрагента" задаётся как NULL или ""
// В случае необходимости добавления только "кода контрагента", параметр "код расчета РЕПО/РПС" задаётся как NULL или ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode );                                             // (in) код расчета РЕПО/РПС
, "'QDAPI_AddItemToGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode );                                             // (in) код расчета РЕПО/РПС
, "'QDAPI_AddItemToClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToClientSettingsAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode );                                             // (in) код расчета РЕПО/РПС
, "'QDAPI_AddItemToClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToClientTemplateAllowedPartnersAndSettleCodes'. ");

// Получение "списка кодов расчетов РЕПО/РПС" и "списка кодов контрагентов" из настроек на класс
// В случае необходимости получения только "списка кодов расчетов РЕПО/РПС", параметр "список кодов контрагентов" задаётся как NULL
// В случае необходимости получения только "списка кодов контрагентов", параметр "список кодов расчетов РЕПО/РПС" задаётся как NULL
// Под возвращаемые значения выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) список кодов контрагентов, в функцию передаётся адрес указателя
	, QDAPI_ArrayStrings** lsSettleCodes );                                 // (out) список кодов расчетов РЕПО/РПС, в функцию передаётся адрес указателя
, "'QDAPI_GetItemFromGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) список кодов контрагентов, в функцию передаётся адрес указателя
	, QDAPI_ArrayStrings** lsSettleCodes );                                 // (out) список кодов расчетов РЕПО/РПС, в функцию передаётся адрес указателя
, "'QDAPI_GetItemFromClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromClientSettingsAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) список кодов контрагентов, в функцию передаётся адрес указателя
	, QDAPI_ArrayStrings** lsSettleCodes );                                 // (out) список кодов расчетов РЕПО/РПС, в функцию передаётся адрес указателя
, "'QDAPI_GetItemFromClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromClientTemplateAllowedPartnersAndSettleCodes'. ");

// Удаление указанных "кода расчета РЕПО/РПС" и "кода контрагента" из настроек на класс
// В случае отсутствия необходимости удаления "кода расчета РЕПО/РПС" или "кода контрагента" соответствующий параметр задаётся как NULL или ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode );                                             // (in) код расчета РЕПО/РПС
, "'QDAPI_RemoveItemFromGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode );                                             // (in) код расчета РЕПО/РПС
, "'QDAPI_RemoveItemFromClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromClientSettingsAllowedPartnersAndSettleCodes'. ");


DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode );                                             // (in) код расчета РЕПО/РПС
, "'QDAPI_RemoveItemFromClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromClientTemplateAllowedPartnersAndSettleCodes'. ");

// Установка "списка кодов расчетов РЕПО/РПС" и "списка кодов контрагентов" в настройке на класс
// В случае отсутствия необходимости установки "списка кодов расчетов РЕПО/РПС" или "списка кодов контрагентов",
// с сохранением данного списка неизменным, соответствующий параметр задаётся как NULL
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) список кодов контрагентов
	, const QDAPI_ArrayStrings* lsSettleCodes );                            // (in) список кодов расчетов РЕПО/РПС
, "'QDAPI_SetItemToGlobalAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToGlobalAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) список кодов контрагентов
	, const QDAPI_ArrayStrings* lsSettleCodes );                            // (in) список кодов расчетов РЕПО/РПС
, "'QDAPI_SetItemToClientSettingsAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToClientSettingsAllowedPartnersAndSettleCodes'. ");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) список кодов контрагентов
	, const QDAPI_ArrayStrings* lsSettleCodes );                            // (in) список кодов расчетов РЕПО/РПС
, "'QDAPI_SetItemToClientTemplateAllowedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToClientTemplateAllowedPartnersAndSettleCodes'. ");
#pragma endregion
#pragma region //================================ PriceLimit ==================================
// Ограничения на цены заявок (по классам)
QDEALERAPI_API int _stdcall QDAPI_AddClassSettingsToGlobalPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, double deviationPercent                                               // (in) отклонение цены в процентах
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_AddClassSettingsToClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, double deviationPercent                                               // (in) отклонение цены в процентах
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_AddClassSettingsToClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, double deviationPercent                                               // (in) отклонение цены в процентах
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены

QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromGlobalPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_PriceType* priceType);                                          // (out) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, QDAPI_PriceType* priceType);                                          // (out) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_PriceType* priceType);                                          // (out) идентификатор типа цены

// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromGlobalPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) список настроек на коды классов, в функцию передаётся адрес указателя
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) список настроек на коды классов, в функцию передаётся адрес указателя
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) список настроек на коды классов, в функцию передаётся адрес указателя

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromGlobalPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode);                                               // (in) код класса
QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode);                                               // (in) код класса
QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode);                                               // (in) код класса

QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToGlobalPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены

QDEALERAPI_API int _stdcall QDAPI_SetSettingListToGlobalPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) список настроек на коды классов
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientSettingsPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) список настроек на коды классов
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientTemplatePriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) список настроек на коды классов
#pragma endregion
#pragma region //=============================== ClientTemplate ===============================
// Добавление одного кода клиента в клиентский шаблон
QDEALERAPI_API int _stdcall QDAPI_AddClientToClientTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, const char* clientCode );                                             // (in) код клиента

// Получение полного списка клиентов в клиентском шаблоне
// Коды клиентов упорядочены лексикографически
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientsListOfClientTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, QDAPI_ArrayStrings** lsClientCodes );                                 // (out) список кодов клиентов, в функцию передаётся адрес указателя

// Перемещение одного кода клиента из клиентского шаблона в другой клиентский шаблон
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenClientTemplates(
		const char* firmCode                                                    // (in) код фирмы
		, const char* fromTemplateCode                                          // (in) название шаблона, из которого удалятся клиент
		, const char* toTemplateCode                                            // (in) название шаблона, в который добавляется клиент
		, const char* clientCode );                                             // (in) код клиента

// Удаление одного кода клиента из клиентского шаблона
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromClientTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, const char* clientCode );                                             // (in) код клиента

// Изменение полного списка клиентов в клиентском шаблоне
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfClientTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, const QDAPI_ArrayStrings* lsClientCodes );                            // (in) список кодов клиентов
#pragma endregion
#pragma region //====================== ProhibitedPartnersAndSettleCodes ======================
// Добавление указанных "кода расчета РЕПО/РПС" и "кода контрагента" в настройки на класс
// В случае необходимости добавления только "кода расчета РЕПО/РПС", параметр "код контрагента" задаётся как NULL или ""
// В случае необходимости добавления только "кода контрагента", параметр "код расчета РЕПО/РПС" задаётся как NULL или ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode);                                              // (in) код расчета РЕПО/РПС
, "'QDAPI_AddPartnerAndSettleCodeToGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_AddCPListToGlobalProhibitedPartnersAndSettleCodes'.");

QDEALERAPI_API int _stdcall QDAPI_AddPartnerAndSettleCodeToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode);                                              // (in) код расчета РЕПО/РПС

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddPartnerAndSettleCodeToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode);                                              // (in) код расчета РЕПО/РПС
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

// Получение "списка кодов расчетов РЕПО/РПС" и "списка кодов контрагентов" из настроек на класс
// В случае необходимости получения только "списка кодов расчетов РЕПО/РПС", параметр "список кодов контрагентов" задаётся как NULL
// В случае необходимости получения только "списка кодов контрагентов", параметр "список кодов расчетов РЕПО/РПС" задаётся как NULL
// Под возвращаемые значения выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) список кодов контрагентов, в функцию передаётся адрес указателя
	, QDAPI_ArrayStrings** lsSettleCodes);                                  // (out) список кодов расчетов РЕПО/РПС, в функцию передаётся адрес указателя
, "'QDAPI_GetPartnerAndSettleCodeListFromGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_GetSettingsFromGlobalProhibitedPartnersAndSettleCodes'.");
QDEALERAPI_API int _stdcall QDAPI_GetPartnerAndSettleCodeListFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) список кодов контрагентов, в функцию передаётся адрес указателя
	, QDAPI_ArrayStrings** lsSettleCodes);                                  // (out) список кодов расчетов РЕПО/РПС, в функцию передаётся адрес указателя
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetPartnerAndSettleCodeListFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsPartnerCodes                                   // (out) список кодов контрагентов, в функцию передаётся адрес указателя
	, QDAPI_ArrayStrings** lsSettleCodes);                                  // (out) список кодов расчетов РЕПО/РПС, в функцию передаётся адрес указателя
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

// Удаление указанных "кода расчета РЕПО/РПС" и "кода контрагента" из настроек на класс
// В случае отсутствия необходимости удаления "кода расчета РЕПО/РПС" или "кода контрагента" соответствующий параметр задаётся как NULL или ""
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode);                                              // (in) код расчета РЕПО/РПС
, "'QDAPI_RemovePartnerAndSettleCodeFromGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_RemoveCPListFromGlobalProhibitedPartnersAndSettleCodes'.");

QDEALERAPI_API int _stdcall QDAPI_RemovePartnerAndSettleCodeFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode);                                              // (in) код расчета РЕПО/РПС

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemovePartnerAndSettleCodeFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, const char* partnerCode                                               // (in) код контрагента
	, const char* settleCode);                                              // (in) код расчета РЕПО/РПС
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

// Установка "списка кодов расчетов РЕПО/РПС" и "списка кодов контрагентов" в настройке на класс
// В случае отсутствия необходимости установки "списка кодов расчетов РЕПО/РПС" или "списка кодов контрагентов",
// с сохранением данного списка неизменным, соответствующий параметр задаётся как NULL
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) список кодов контрагентов
	, const QDAPI_ArrayStrings* lsSettleCodes);                             // (in) список кодов расчетов РЕПО/РПС
, "'QDAPI_SetPartnerAndSettleCodeListToGlobalProhibitedPartnersAndSettleCodes': was declared deprecated. Instead, use 'QDAPI_SetSettingsToGlobalProhibitedPartnersAndSettleCodes'.");

QDEALERAPI_API int _stdcall QDAPI_SetPartnerAndSettleCodeListToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) список кодов контрагентов
	, const QDAPI_ArrayStrings* lsSettleCodes);                             // (in) список кодов расчетов РЕПО/РПС

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetPartnerAndSettleCodeListToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsPartnerCodes                              // (in) список кодов контрагентов
	, const QDAPI_ArrayStrings* lsSettleCodes);                             // (in) список кодов расчетов РЕПО/РПС
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
// Ограничения на цены заявок (по инструментам)
QDEALERAPI_API int _stdcall QDAPI_AddSecuritySettingsToGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, double deviationPercent                                               // (in) отклонение цены в процентах
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_AddSecuritySettingsToClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* secCode                                                   // (in) код инструмента
	, double deviationPercent                                               // (in) отклонение цены в процентах
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_AddSecuritySettingsToClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, double deviationPercent                                               // (in) отклонение цены в процентах
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены

QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_PriceType* priceType);                                          // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, QDAPI_PriceType* priceType);                                          // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_GetMiddlePriceFromClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_PriceType* priceType);                                          // (in) идентификатор типа цены

// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) список настроек на коды инструментов, в функцию передаётся адрес указателя
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) список настроек на коды инструментов, в функцию передаётся адрес указателя
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_ArrayPriceLimit** pPriceLimitList);                             // (out) список настроек на коды инструментов, в функцию передаётся адрес указателя

QDEALERAPI_API int _stdcall QDAPI_RemoveSecuritySettingsFromGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode);                                                 // (in) код инструмента
QDEALERAPI_API int _stdcall QDAPI_RemoveSecuritySettingsFromClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const char* secCode);                                                 // (in) код инструмента
QDEALERAPI_API int _stdcall QDAPI_RemoveSecuritySettingsFromClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode);                                                 // (in) код инструмента

QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены
QDEALERAPI_API int _stdcall QDAPI_SetMiddlePriceToClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_PriceType priceType);                                           // (in) идентификатор типа цены

QDEALERAPI_API int _stdcall QDAPI_SetSettingListToGlobalSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) список настроек на коды классов
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientSettingsSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) список настроек на коды классов
QDEALERAPI_API int _stdcall QDAPI_SetSettingListToClientTemplateSecPriceLimit(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const QDAPI_ArrayPriceLimit* classCodes);                             // (in) список настроек на коды классов
#pragma endregion
//PGO
#pragma region //============================== Секция [General] ==============================
// возвращает значение глобальной настройки UsePGO
QDEALERAPI_API int _stdcall QDAPI_GetUsePGOFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int* usePGO);                                                         // (out) значение настройки

// возвращает значение индивидуальной настройки UsePGO на код клиента
QDEALERAPI_API int _stdcall QDAPI_GetUsePGOFromClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int* usePGO);                                                         // (out) значение настройки

// возвращает значение настройки UsePGO в маржинальном шаблоне
QDEALERAPI_API int _stdcall QDAPI_GetUsePGOFromMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона
	, int* usePGO);                                                         // (out) значение настройки

// устанавливает значение глобальной настройки UsePGO
QDEALERAPI_API int _stdcall QDAPI_SetUsePGOToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int usePGO);                                                          // (in) значение настройки

// устанавливает значение индивидуальной настройки UsePGO на код клиента
QDEALERAPI_API int _stdcall QDAPI_SetUsePGOToClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int usePGO);                                                          // (in) значение настройки

// устанавливает значение глобальной настройки UsePGO в маржинальном шаблоне
QDEALERAPI_API int _stdcall QDAPI_SetUsePGOToMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона
	, int usePGO);                                                          // (in) значение настройки

#pragma endregion
#pragma region //============================= Секция [BaseAssets] ============================
// возвращает список базовых активов, для которых заданы соответствия
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsListFromBaseAssetsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsBaseAssets);                                   // (out) список базовых активов

// возвращает настройки для указанного базового актива
QDEALERAPI_API int _stdcall QDAPI_GetSpotListForBaseAssetFromBaseAssetsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, QDAPI_ArraySpotListForBaseAsset** lsSpotCodes);                       // (out) список спот-активов

// устанавливает (перезаписывает или удаляет) настройку для указанного базового актива
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToBaseAssetsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, const QDAPI_ArraySpotListForBaseAsset* lsSpotCodes);                  // (in) список

#pragma endregion
#pragma region //================= Секция [BaseAssets_Template_<TemplateName>] ================
// получение списка всех шаблонов настроек соответствий базовых активов
QDEALERAPI_API int _stdcall QDAPI_GetListOfBaseAssetsTemplates(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsBaseAssetsTemplateCodes);                      // (out) список наименований шаблонов

// добавление (создание) шаблона настроек соответствий базовых активов. Если указанный шаблон уже существует – возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_AddBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) название шаблона

// удаление шаблона настроек соответствий базовых активов
QDEALERAPI_API int _stdcall QDAPI_RemoveBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) название шаблона

// добавление клиента в шаблон
QDEALERAPI_API int _stdcall QDAPI_AddClientToBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* clientCode);                                              // (in) код клиента

// получение списка клиентов в шаблоне
QDEALERAPI_API int _stdcall QDAPI_GetClientsListFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_ArrayStrings** lsClientCodes);                                  // (out) список кодов клиентов

// перемещение клиента между шаблонами
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenBaseAssetsTemplates(
	const char* firmCode                                                    // (in) код фирмы
	, const char* fromTemplateCode                                          // (in) название шаблона, из которого удалятся клиент
	, const char* toTemplateCode                                            // (in) название шаблона, в который добавляется клиент
	, const char* clientCode);                                              // (in) код клиента

// удаление клиента из шаблона
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* clientCode);                                              // (in) код клиента

// задание (изменение) списка клиентов в шаблоне
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const QDAPI_ArrayStrings* lsClientCodes);                             // (in) список кодов клиентов

// возвращает список базовых активов конкретного шаблона
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsListFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings** lsBaseAssets);                                   // (out) список базовых активов

// возвращает настройки для указанного базового актива в конкретном шаблоне
QDEALERAPI_API int _stdcall QDAPI_GetSpotListForBaseAssetFromBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* baseAsset                                                 // (in) базовый актив
	, QDAPI_ArraySpotListForBaseAsset** lsSpotCodes);                       // (out) список спот-активов

// устанавливает (перезаписывает или удаляет) настройку для указанного базового актива в конкретном шаблоне
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToBaseAssetsTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* baseAsset                                                 // (in) базовый актив
	, const QDAPI_ArraySpotListForBaseAsset* lsSpotCodes);                  // (in) список соответствий

#pragma endregion
#pragma region //======================== Секция [PortfolioRiskConfig] ========================
// возвращает значения всех настроек группы
QDEALERAPI_API int _stdcall QDAPI_GetMainSettingsFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_MainSettingsOfPortfolioRiskConfigGlobal** settings);            // (out) список настроек

// задает значения настроек группы, а также позволяет удалять любую из настроек путем задания соответствующего значения самой настройки или специального флага
QDEALERAPI_API int _stdcall QDAPI_SetMainSettingsToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const QDAPI_MainSettingsOfPortfolioRiskConfigGlobal* settings);       // (in) список настроек

// возвращает значение настройки временных слоев
QDEALERAPI_API int _stdcall QDAPI_GetSpreadTiersFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayOfSpreadTiers** lsTiers);                                  // (out) список кастомизированных слоев

// задает настройку временных слоев
QDEALERAPI_API int _stdcall QDAPI_SetSpreadTiersToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const QDAPI_ArrayOfSpreadTiers* lsTiers);                             // (in) список кастомизированных слоев

// возвращает значения всех настроек группы
QDEALERAPI_API int _stdcall QDAPI_GetCommonSettingsFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) общие настройки ПГО

// задает новые значения настроек группы
QDEALERAPI_API int _stdcall QDAPI_SetCommonSettingsToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) общие настройки ПГО

// возвращает список счетов, для которых задана хотя бы одна индивидуальная настройка
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccListFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsTrdAccs);                                      // (out) список счетов, для которых задана хотя бы одна индивидуальная настройка

// возвращает значения всех настроек группы, заданных на торговый счет. Если настройки отсутствуют – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_GetIndividualSettingsFromPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* tradingAccount                                            // (in) торговый счет
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) настройки ПГО на торговый счет

// задает значения настроек группы на торговый счет. При попытке записи значения в отсутствующую секцию – такая секция создается
QDEALERAPI_API int _stdcall QDAPI_SetIndividualSettingsToPortfolioRiskConfigGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* tradingAccount                                            // (in) торговый счет
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) настройки ПГО на торговый счет

#pragma endregion
#pragma region //================== Секция [PortfolioRiskConfig_<BaseAsset>] ==================
// возвращает список базовых активов, для которых заданы секции настроек на базовый актив. Шаблонные секции в выборку не попадают
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsListWithPortfolioRiskConfigOnBaseAssetSection(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsBaseAssets);                                   // (out) список базовых активов, для которых заданы секции с указанием этого базового актива

// добавляет секцию с указанием конкретного базового актива. Если указанная секция уже существует – возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_AddPortfolioRiskConfigOnBaseAssetSection(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset);                                               // (in) базовый актив;

// удаляет секцию, заданную на конкретный базовый актив. Необходимо учесть, что это именно секция на базовый актив. При указании базового актива, для которого нет секции, возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_RemovePortfolioRiskConfigOnBaseAssetSection(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset);                                               // (in) базовый актив;

// возвращает список дополнительных базовых активов
QDEALERAPI_API int _stdcall QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, QDAPI_ArrayStrings** lsAdditionalBaseAssets);                         // (out) список дополнительных базовых активов

// задает список дополнительных базовых активов, а также позволяет удалять настройку
QDEALERAPI_API int _stdcall QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, const QDAPI_ArrayStrings* lsAdditionalBaseAssets);                    // (in) список дополнительных базовых активов

// возвращает значение настройки временных слоев
QDEALERAPI_API int _stdcall QDAPI_GetSpreadTiersFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, QDAPI_ArrayOfSpreadTiers** lsTiers);                                  // (out) список кастомизированных слоев

// задает настройку временных слоев (т.ч. удаляет).
QDEALERAPI_API int _stdcall QDAPI_SetSpreadTiersToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, const QDAPI_ArrayOfSpreadTiers* lsTiers);                             // (in) список кастомизированных слоев

// возвращает значения всех настроек группы
QDEALERAPI_API int _stdcall QDAPI_GetCommonSettingsFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) общие настройки ПГО

// задает значения настроек группы, а также позволяет удалять настройки
QDEALERAPI_API int _stdcall QDAPI_SetCommonSettingsToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) общие настройки ПГО

// возвращает список счетов, для которых задана хотя бы одна индивидуальная настройка
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccListFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, QDAPI_ArrayStrings** lsTrdAccs);                                      // (out) список счетов, для которых задана хотя бы одна индивидуальная настройка

// возвращает значения всех настроек группы, заданных на торговый счет. Если настройки отсутствуют (не путать с отсутствием самого шаблона) – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_GetIndividualSettingsFromPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, const char* tradingAccount                                            // (in) торговый счет
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) настройки ПГО на торговый счет

// задает значения настроек группы на торговый счет
QDEALERAPI_API int _stdcall QDAPI_SetIndividualSettingsToPortfolioRiskConfigOnBaseAsset(
	const char* firmCode                                                    // (in) код фирмы
	, const char* baseAsset                                                 // (in) базовый актив
	, const char* tradingAccount                                            // (in) торговый счет
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) настройки ПГО на торговый счет

#pragma endregion
#pragma region //================= Секция [PortfolioRiskConfig_<TemplateName>] ================
// возвращает список уникальных шаблонных секций настроек ПГО (в виде уникальны пар «код шаблона – код базового актива MainAsset»). Секции на базовый актив в выборку не попадают
QDEALERAPI_API int _stdcall QDAPI_GetPortfolioRiskConfigTemplatesList(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayPortfolioRiskConfigTemplateIdentifier** lsTemplates);      // (out) список шаблонов настроек ПГО

// добавляет (создает) шаблонную секцию настроек ПГО. Необходимо учесть, что это именно шаблонная секция, а не секция  на базовый актив. Если указанная шаблонная секция уже существует – возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_AddPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const QDAPI_PortfolioRiskConfigTemplateIdentifier* templateId);       // (in) шаблон;

// удаляет шаблонную секцию настроек ПГО. Необходимо учесть, что это именно шаблонная секция, а не секция  на базовый актив
QDEALERAPI_API int _stdcall QDAPI_RemovePortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName);                                            // (in) шаблон;

// добавление клиента в шаблон
QDEALERAPI_API int _stdcall QDAPI_AddClientToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char*	templateName                                            // (in) шаблон;
	, const char* clientCode);                                              // (in) код клиента

// получение списка клиентов в шаблоне
QDEALERAPI_API int _stdcall QDAPI_GetClientsListFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, QDAPI_ArrayStrings** lsClientCodes);                                  // (out) список кодов клиентов

// перемещение клиента между шаблонами
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenPortfolioRiskConfigTemplates(
	const char* firmCode                                                    // (in) код фирмы
	, const char* fromTemplate                                              // (in) шаблон, из которого удалятся клиент
	, const char* toTemplate                                                // (in) шаблон, в который добавляется клиент
	, const char* clientCode);                                              // (in) код клиента

// удаление клиента из шаблона
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, const char* clientCode);                                              // (in) код клиента

// задание (изменение) списка клиентов в шаблоне
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, const QDAPI_ArrayStrings* lsClientCodes);                             // (in) список кодов клиентов

// возвращает тег, на котором учитываются операции клиентов шаблона
QDEALERAPI_API int _stdcall QDAPI_GetBoardTagFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, char** tag);                                                          // (out) тег

// устанавливает (а также перезаписывает или удаляет) значение тега, на котором учитываются операции клиентов шаблона
QDEALERAPI_API int _stdcall QDAPI_SetBoardTagToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, const char* tag);                                                     // (in) тег

// устанавливает (перезаписывает) базовый актив шаблона. Если в результате изменения базового актива произойдет дублирование существующего шаблона – возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST
QDEALERAPI_API int _stdcall QDAPI_SetMainAssetToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, const char* baseAsset);                                               // (in) базовый актив

// возвращает список дополнительных базовых активов
QDEALERAPI_API int _stdcall QDAPI_GetAdditionalBaseAssetsListFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, QDAPI_ArrayStrings** lsAdditionalBaseAssets);                         // (out) список дополнительных базовых активов

// задает список дополнительных базовых активов, а также позволяет удалить настройку
QDEALERAPI_API int _stdcall QDAPI_SetAdditionalBaseAssetsListToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, const QDAPI_ArrayStrings* lsAdditionalBaseAssets);                    // (in) список дополнительных базовых активов

// возвращает значение настройки временных слоев
QDEALERAPI_API int _stdcall QDAPI_GetSpreadTiersFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, QDAPI_ArrayOfSpreadTiers** lsTiers);                                  // (out) список кастомизированных слоев

// задает настройку временных слоев, а также позволяет удалить настройку
QDEALERAPI_API int _stdcall QDAPI_SetSpreadTiersToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, const QDAPI_ArrayOfSpreadTiers* lsTiers);                             // (in) список кастомизированных слоев

// возвращает значения всех настроек группы
QDEALERAPI_API int _stdcall QDAPI_GetCommonSettingsFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) общие настройки ПГО

// задает значения настроек группы, а также позволяет удалять настройки
QDEALERAPI_API int _stdcall QDAPI_SetCommonSettingsToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон;
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) общие настройки ПГО

// возвращает список счетов, для которых задана хотя бы одна индивидуальная настройка. Строка с перечнем счетов в шаблоне не анализируется
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccListFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон
	, QDAPI_ArrayStrings** lsTrdAccs);                                      // (out) список счетов, для которых задана хотя бы одна индивидуальная настройка

// возвращает значения всех настроек группы, заданных на торговый счет. Если настройки отсутствуют (не путать с отсутствием самого шаблона) – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND
QDEALERAPI_API int _stdcall QDAPI_GetIndividualSettingsFromPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон
	, const char* tradingAccount                                            // (in) торговый счет
	, QDAPI_PortfolioRiskConfigSettings** settings);                        // (out) настройки ПГО на торговый счет

// задает значения настроек группы на торговый счет, а также позволяет удалять такие настройки
QDEALERAPI_API int _stdcall QDAPI_SetIndividualSettingsToPortfolioRiskConfigTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) шаблон
	, const char* tradingAccount                                            // (in) торговый счет
	, const QDAPI_PortfolioRiskConfigSettings* settings);                   // (in) настройки ПГО на торговый счет

#pragma endregion
#pragma region //======================== Секция [PortfolioSpreadOrder] =======================
// возвращает все настройки последовательности вычисления межпортфельных спредов
QDEALERAPI_API int _stdcall QDAPI_GetSettingsListFromPortfolioSpreadOrder(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayBaseAssetsSpreadOrder** lsSpreadOrderSettings);            // (out) список настроек

// задает(перезаписывает или удаляет) значение для пары базовых активов. При попытке записи значения в отсутствующую секцию – такая секция создается
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToPortfolioSpreadOrder(
	const char* firmCode                                                    // (in) код фирмы
	, const QDAPI_BaseAssetsSpreadOrder* lsSpreadOrderSettings);            // (in) список соответствий

#pragma endregion
//Global
#pragma region //================= Global -> General -> AddSubClientDelimiter  ================
QDEALERAPI_API int _stdcall QDAPI_GetAdditionalSubClientDelimiterFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, char* value);                                                         // (out) значение параметра

QDEALERAPI_API int _stdcall QDAPI_SetAdditionalSubClientDelimiterToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, char newValue);                                                       // (in) новое значение параметра
#pragma endregion
#pragma region //===================== Global -> General -> SecPricePrior =====================
QDEALERAPI_API int _stdcall QDAPI_GetSecPricePriorityFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int* secPricePriority);                                               // (out) значение параметра

QDEALERAPI_API int _stdcall QDAPI_SetSecPricePriorityToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int secPricePriority);                                                // (int) новое значение параметра
#pragma endregion
#pragma region //============================ ChangeFutClientCodes ============================
// Учёт операций срочного рынка->Идентификатор фирмы срочного рынка
// Коды фирм упорядочиваются лексикографически.
// Учёт операций срочного рынка->Соответствие клиентских кодов
// Соответствия "Код клиента"->"Торговый счёт на срочном рынке" упорядочиваются лексикографически по коду клиента.
// [ChangeFutClientCodes_FirmCode]
// <Код клиента 1> = <Торговый счёт 1>
// <Код клиента 2> = <Торговый счёт 2>
// ...
// <Код клиента N> = <Торговый счёт N>

// Получить список фирм срочного рынка
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetListOfFirmsGlobalChangeFutClientCodes(
		const char* firmCode                                                    // (in) код фирмы
		, QDAPI_ArrayStrings** lsFirmCodesOnDerivMarket );                      // (out) список кодов фирм на срочном рынке, в функцию передаётся адрес указателя

// Добавить одно соответствие клиентских кодов для заданной фирмы срочного рынка
QDEALERAPI_API int _stdcall QDAPI_AddCorrespToGlobalChangeFutClientCodes(
		const char* firmCode                                                    // (in) код фирмы
		, const char* firmCodeOnDerivMarket                                     // (in) код фирмы на срочном рынке
		, const QDAPI_StringToString* clientCodeToTrdAcc );                     // (in) пара {код клиента, торговый счёт на срочном рынке}

// Получить код клиента по заданной фирме срочного рынка и торговому счёту
// Возвращаемое значение: указатель на код клиента
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientCodeGlobalChangeFutClientCodesByTrdAcc(
		const char* firmCode                                                    // (in) код фирмы
		, const char* firmCodeOnDerivMarket                                     // (in) код фирмы на срочном рынке
		, const char* trdAcc                                                    // (in) торговый счёт на срочном рынке
		, char** clientCode );                                                  // (out) код клиента, в функцию передаётся адрес указателя

// Получить торговый счёт на срочном рынке по заданной фирме срочного рынка и коду клиента
// Возвращаемое значение: указатель на торговый счёт
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetTrdAccGlobalChangeFutClientCodesByClientCode(
		const char* firmCode                                                    // (in) код фирмы
		, const char* firmCodeOnDerivMarket                                     // (in) код фирмы на срочном рынке
		, const char* clientCode                                                // (in) код клиента
		, char** trdAcc );                                                      // (out) торговый счёт на срочном рынке, в функцию передаётся адрес указателя

// Удалить все соответствия клиентских кодов для заданной фирмы срочного рынка
QDEALERAPI_API int _stdcall QDAPI_RemoveAllCorrespsFromGlobalChangeFutClientCodes(
		const char* firmCode                                                    // (in) код фирмы
		, const char* firmCodeOnDerivMarket );                                  // (in) код фирмы на срочном рынке

// Удалить одно соответствие клиентских кодов по заданной фирме срочного рынка и коду клиента
QDEALERAPI_API int _stdcall QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByClientCode(
		const char* firmCode                                                    // (in) код фирмы
		, const char* firmCodeOnDerivMarket                                     // (in) код фирмы на срочном рынке
		, const char* clientCode );                                             // (in) код клиента

// Удалить одно соответствие клиентских кодов по заданной фирме срочного рынка и торговому счёту
QDEALERAPI_API int _stdcall QDAPI_RemoveCorrespFromGlobalChangeFutClientCodesByTrdAcc(
		const char* firmCode                                                    // (in) код фирмы
		, const char* firmCodeOnDerivMarket                                     // (in) код фирмы на срочном рынке
		, const char* trdAcc );                                                 // (in) торговый счёт на срочном рынке
#pragma endregion
#pragma region //============================ GlobalProhibedTrdAcc ============================
// Другие параметры->Торговые счета, запрещённые для торговых операций
// Торговые счета упорядочиваются лексикографически.
// [GlobalProhibedTrdAcc]
// GlobalProhibedTrdAcc = <Торговый счёт 1>, <Торговый счёт 2>, ..., <Торговый счёт N>

// Добавить торговый счёт к "Торговым счетам, запрещённым для торговых операций"
QDEALERAPI_API int _stdcall QDAPI_AddTrdAccToGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) код фирмы
		, const char* tradeAccount );                                           // (in) торговый счёт

// Получить список торговых счётов, запрещённых для торговых операций
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) код фирмы
		, QDAPI_ArrayStrings** tradeAccounts );                                 // (out) список торговых счетов, в функцию передаётся адрес указателя

// Удалить торговый счёт из "Торговых счетов, запрещённых для торговых операций"
QDEALERAPI_API int _stdcall QDAPI_RemoveTrdAccFromGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) код фирмы
		, const char* tradeAccount );                                           // (in) торговый счёт

// Установить список торговых счётов, запрещённых для торговых операций
QDEALERAPI_API int _stdcall QDAPI_SetGlobalProhibedTrdAcc(
		const char* firmCode                                                    // (in) код фирмы
		, const QDAPI_ArrayStrings* tradeAccounts );                            // (in) список торговых счетов
#pragma endregion
#pragma region //=============================== ProhibitOrders ===============================
// Другие параметры->Клиенты, для которых запрещено проведение торговых операций
// Коды клиентов упорядочиваются лексикографически.
// [ProhibitOrders]
// Clients = <Код клиента 1>, <Код клиента 2>, ..., <Код клиента N>

// Добавить клиента, для которого запрещено проведение торговых операций
QDEALERAPI_API int _stdcall QDAPI_AddClientToGlobalProhibitOrders(
		const char* firmCode                                                    // (in) код фирмы
		, const char* clientCode );                                             // (in) код клиента

// Получить весь список клиентов, для которых запрещено проведение торговых операций
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetGlobalProhibitOrders(
		const char* firmCode                                                    // (in) код фирмы
		, QDAPI_ArrayStrings** clientCodes );                                   // (out) список кодов клиентов, в функцию передаётся адрес указателя

// Удалить запрет проведения торговых операций для заданного клиента
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromGlobalProhibitOrders(
		const char* firmCode                                                    // (in) код фирмы
		, const char* clientCode );                                             // (in) код клиента

// Установить список клиентов, для которых запрещено проведение торговых операций
QDEALERAPI_API int _stdcall QDAPI_SetGlobalProhibitOrders(
		const char* firmCode                                                    // (in) код фирмы
		, const QDAPI_ArrayStrings* clientCodes );                              // (in) список кодов клиентов
#pragma endregion
#pragma region //========================= RestOrdVolumeByAvgTurnover =========================
// Чтение RestOrdVolumeByAvgTurnover
QDEALERAPI_API int _stdcall QDAPI_GetBasePeriodFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, int* basePeriod);                                                     // (out) базовый период

// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
// Параметры lsClasses и lsInstruments выполняют роль «фильтров» и могут быть заданы как NULL. В этом случае, соответственно,
// должны быть получены ограничения по всем классам или по всем инструментам. Если задан lsClasses или lsInstruments не NULL, но с count = 0, то возвращает QDAPI_ERROR_INCORRECT_PARAMETER
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnoverEx(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) список инструментов
	, QDAPI_ArrayVolumeRestrictionByAvgTurnover** restrs);                  // (out) список ограничений, заданных на коды классов. В функцию передаётся адрес указателя

// Параметры lsClasses и lsInstruments выполняют роль «фильтров» и могут быть заданы как NULL. В этом случае, соответственно,
// должны быть получены ограничения по всем классам или по всем инструментам. Если задан lsClasses или lsInstruments не NULL, но с count = 0, то возвращает QDAPI_ERROR_INCORRECT_PARAMETER
QDEALERAPI_API int _stdcall QDAPI_GetSettingListFromRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) список инструментов
	, QDAPI_ArrayVolumeRestrictionByAvgTurnover** restrs);                  // (out) список ограничений, заданных на коды классов. В функцию передаётся адрес указателя);

// Запись RestOrdVolumeByAvgTurnover
QDEALERAPI_API int _stdcall QDAPI_SetBasePeriodToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, int basePeriod);                                                      // (in) базовый период

QDEALERAPI_API int _stdcall QDAPI_SetSettingToGlobalRestOrdVolumeByAvgTurnoverEx(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const QDAPI_ArrayVolumeRestrictionByAvgTurnover* restrs);	            // (in) список

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode									                // (in) код фирмы
	, QDAPI_SettingsScope settingsScope   					                // (in) тип настроек
	, const char* templateCode            				                    // (in) название шаблона
	, const QDAPI_ArrayVolumeRestrictionByAvgTurnover* restrs);	            // (in) список ограничений

QDEALERAPI_API int _stdcall QDAPI_AddSettingsToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode									                // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings* classList                                         // (in) список классов
	, QDAPI_ArrayStrings* instrList                                         // (in) список инструментов
	, double restPercent                                                    // (in) ограничение, %
	, double alertPercent                                                   // (in) предупреждение, %
	, const char* valuationClass);                                          // (in) код класса оценки

QDEALERAPI_API int _stdcall QDAPI_AddSettingsToRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode									                // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_ArrayStrings* classList                                         // (in) список классов
	, QDAPI_ArrayStrings* instrList                                         // (in) список инструментов
	, double restPercent                                                    // (in) ограничение, %
	, double alertPercent                                                   // (in) предупреждение, %
	, const char* valuationClass);                                          // (in) код класса оценки

// Удаление RestOrdVolumeByAvgTurnover
QDEALERAPI_API int _stdcall QDAPI_RemoveSettingsFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings* classList                                         // (in) список классов
	, QDAPI_ArrayStrings* instrList);                                       // (in) список инструментов

QDEALERAPI_API int _stdcall QDAPI_RemoveSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode            				                    // (in) название шаблона
	, QDAPI_ArrayStrings* classList                                         // (in) список классов
	, QDAPI_ArrayStrings* instrList);                                       // (in) список инструментов

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSettingsFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode				                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope);   	                            // (in) тип настроек

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSettingsFromRestrictionTemplateRestOrdVolumeByAvgTurnover(
	const char* firmCode				                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope  	                                // (in) тип настроек
	, const char* templateCode); 	                                        // (in) название шаблона

// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции FreeMemory
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayVolumeRestriction** restrs)                                // (out) список ограничений, заданных на коды классов. В функцию передаётся адрес указателя
	, "'QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_GetSettingListFromGlobalRestOrdVolumeByAvgTurnoverEx'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddClassSettingsToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса ограничения
	, double restPercent                                                    // (in) ограничение, %
	, double alertPercent                                                   // (in) предупреждение, %
	, const char* valuationClass)                                           // (in) код класса оценки
	, "'QDAPI_AddClassSettingsToGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_AddSettingsToGlobalRestOrdVolumeByAvgTurnover'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveClassSettingsFromGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode)                                                // (in) код класса ограничения
	, "'QDAPI_RemoveClassSettingsFromGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_RemoveSettingsFromGlobalRestOrdVolumeByAvgTurnover'.");

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetSettingListToGlobalRestOrdVolumeByAvgTurnover(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const QDAPI_ArrayVolumeRestriction* restrs)                           // (in) список ограничений, заданных на коды классов
	, "'QDAPI_SetSettingListToGlobalRestOrdVolumeByAvgTurnover': was declared deprecated. Instead, use 'QDAPI_SetSettingToGlobalRestOrdVolumeByAvgTurnoverEx'.");
#pragma endregion
#pragma region //============================ RestrictOptionOrders ============================
// Ограничения на ...->Доступные бумаги->Ограничение торговли опционами
// Ограничения лексикографически упорядочиваются по базовому активу.
// [RestrictOptionOrders]
// <Базовый актив 1> = <Граничная дата исполнения 1>, <Максимальное отклонение страйка 1>
// <Базовый актив 2> = <Граничная дата исполнения 2>, <Максимальное отклонение страйка 2>
// ...
// <Базовый актив N> = <Граничная дата исполнения N>, <Максимальное отклонение страйка N>
// <Граничная дата исполнения> хранится в формате <День>.<Месяц>.<Год>
// Пример:
// BaseAsset1 = 01.07.2018, 134.7

// Добавить ограничение к ограничениям торговли опционами
QDEALERAPI_API int _stdcall QDAPI_AddRestrictToGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) код фирмы
		, const QDAPI_RestrictOptionOrders* restr );                            // (in) ограничение торговли опционами

// Получить список базовых активов на которые заданы ограничения торговли опционами
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetBaseAssetsGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) код фирмы
		, QDAPI_ArrayStrings** baseAssets );                                    // (out) список базовых активов, в функцию передаётся адрес указателя

// Получить ограничение торговли опционами по базовому активу
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetRestrictionGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) код фирмы
		, const char* baseAsset                                                 // (in) базовый актив
		, QDAPI_RestrictOptionOrdersBody** restrBody );                         // (out) ограничение торговли опционами, в функцию передаётся адрес указателя

// Получить все ограничения торговли опционами
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetAllRestrictionsGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) код фирмы
		, QDAPI_ArrayRestrictOptionOrders** restrsList );                       // (out) список ограничений торговли опционами, в функцию передаётся адрес указателя

// Удалить ограничение из ограничений торговли опционами
QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictFromGlobalRestrictOptionOrders(
		const char* firmCode                                                    // (in) код фирмы
		, const char* baseAsset );                                              // (in) базовый актив
#pragma endregion
#pragma region //=================== RestrictSecuritiesPropotionInCollateral ==================
// Инструменты->Инструменты с ограничением доли в обеспечении
// Инструменты упорядочиваются лексикографически.
// [RestrictSecuritiesPropotionInCollateral]
// <Инструмент 1> =
// <Инструмент 2> =
// ...
// <Инструмент N> =

// Добавить инструмент с ограничением доли в обеспечении
QDEALERAPI_API int _stdcall QDAPI_AddSecurityToGlobalRestrictSecuritiesProportionInCollateral(
		const char* firmCode                                                    // (in) код фирмы
		, const char* secCode );                                                // (in) код инструмента

// Получить весь список инструментов с ограничением доли в обеспечении
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetGlobalRestrictSecuritiesProportionInCollateral(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_ArrayStrings** secCodes );                                          // (out) список кодов инструментов, в функцию передаётся адрес указателя

// Удалить инструмент из списка инструментов с ограничением доли в обеспечении
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityFromGlobalRestrictSecuritiesProportionInCollateral(
		const char* firmCode                                                    // (in) код фирмы
		, const char* secCode );                                                // (in) код инструмента

// Установить список инструментов с ограничением доли в обеспечении
QDEALERAPI_API int _stdcall QDAPI_SetGlobalRestrictSecuritiesProportionInCollateral(
		const char* firmCode                                                    // (in) код фирмы
		, const QDAPI_ArrayStrings* secCodes );                                 // (in) список кодов инструментов
#pragma endregion
#pragma region //========================= Global -> RestrictSecurity =========================
// Список запрещений по торгуемым инструментам
// Ограничения на – Доступные бумаги – По классам – Запрещения по торгуемым инструментам
// В качестве значения параметра settingsScope значение QDAPI_SETTINGS_SCOPE_ADDITIONAL не поддерживается.
// Список инструментов задаётся на комбинацию параметров: класс, список торговых счетов (может быть пуст),
//   границы временного периода (может быть не задан). В качестве списка инструментов может быть указана
//   строка «<ALL>», что означает запрещение торговли по всем инструментам класса, с учётом списка
//   торговых счетов и границ периода.
// [RestrictSecurity]
// INDX_TIME_11:19,11:03_TRDACC_AC3,Ac7=Sc2, Sc4                                ; заданы все параметры настройки
// GAZ_TIME_15:18,16:24_TRDACC_Ac2=<ALL>                                        ; список инструментов задан как "все инструменты"
// GTS=Sc8                                                                      ; настройка задана только на класс, без указания временного интервала и списка торговых счетов
// GTS_TIME_13:00,13:17=Sc1                                                     ; настройка задана на <класс, интервал времени>, без указания списка торговых счетов
// GTS_TIME_13:00,13:19=Sc1                                                     ; настройка задана на <класс, интервал времени>, без указания списка торговых счетов

// Получение списка классов, на которые заданы настройки данного типа
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) список классов, в функцию передаётся адрес указателя

// Получение списка запрещений из настройки на класс
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayRestrictSecurityByClass** restrictions);                   // (out) список запрещений, в функцию передаётся адрес указателя

// Добавление запрещённых инструментов в настройку на <класс, список торговых счетов, интервал времени>
QDEALERAPI_API int _stdcall QDAPI_AddSecurityListToGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) список торговых счетов, в функцию передаётся адрес объекта
	, bool isPeriodExists                                                   // (in) задан ли временной период
	, int fromTimeHours                                                     // (in) начало периода: часы
	, int fromTimeMinutes                                                   // (in) начало периода: минуты
	, int tillTimeHours                                                     // (in) конец периода: часы
	, int tillTimeMinutes                                                   // (in) конец периода: минуты
	, const QDAPI_ArrayStrings* lsSecurityCodes);                           // (in) список инструментов, в функцию передаётся адрес объекта

// Получение списка запрещённых инструментов из настройки на <класс, список торговых счетов, интервал времени>
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) список торговых счетов, в функцию передаётся адрес объекта
	, bool isPeriodExists                                                   // (in) задан ли временной период
	, int fromTimeHours                                                     // (in) начало периода: часы
	, int fromTimeMinutes                                                   // (in) начало периода: минуты
	, int tillTimeHours                                                     // (in) конец периода: часы
	, int tillTimeMinutes                                                   // (in) конец периода: минуты
	, QDAPI_ArrayStrings** lsSecurityCodes);                                // (out) список инструментов, в функцию передаётся адрес указателя

// Удаление запрещённых инструментов из настройки на <класс, список торговых счетов, интервал времени>
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityListFromGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) список торговых счетов, в функцию передаётся адрес объекта
	, bool isPeriodExists                                                   // (in) задан ли временной период
	, int fromTimeHours                                                     // (in) начало периода: часы
	, int fromTimeMinutes                                                   // (in) начало периода: минуты
	, int tillTimeHours                                                     // (in) конец периода: часы
	, int tillTimeMinutes                                                   // (in) конец периода: минуты
	, const QDAPI_ArrayStrings* lsSecurityCodes);                           // (in) список инструментов, в функцию передаётся адрес объекта

// Замена списка инструментов в настройке на <класс, список торговых счетов, интервал времени>
QDEALERAPI_API int _stdcall QDAPI_SetSecurityListToGlobalRestrictSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsTradeAccounts                             // (in) список торговых счетов, в функцию передаётся адрес объекта
	, bool isPeriodExists                                                   // (in) задан ли временной период
	, int fromTimeHours                                                     // (in) начало периода: часы
	, int fromTimeMinutes                                                   // (in) начало периода: минуты
	, int tillTimeHours                                                     // (in) конец периода: часы
	, int tillTimeMinutes                                                   // (in) конец периода: минуты
	, const QDAPI_ArrayStrings* lsSecurityCodes);                           // (in) список инструментов, в функцию передаётся адрес объекта
#pragma endregion
#pragma region //============================ Global -> SubBrokers ============================
// Функционал работы со списком субброкеров
// Получить список субброкеров
// Под "список кодов субброкеров" выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSubBrokerListFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** subBrokers);                                     // (out) список кодов субброкеров. В функцию передаётся адрес указателя

// Удалить субброкера и все настройки на него, включая список его субклиентов.
QDEALERAPI_API int _stdcall QDAPI_RemoveSubBrokerFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* subBroker);                                               // (in) код субброкера

// Добавить субклиента заданному субброкеру
QDEALERAPI_API int _stdcall QDAPI_AddSubClientToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* subBroker                                                 // (in) код субброкера
	, const char* subClient);                                               // (in) код субклиента

// Получить список субклиентов заданного субброкера
// Под "список кодов субклиентов" выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSubClientListFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* subBroker                                                 // (in) код субброкера
	, QDAPI_ArrayStrings** subClientList);                                  // (out) список кодов субклиентов. В функцию передаётся адрес указателя

QDEALERAPI_API int _stdcall QDAPI_RemoveSubClientFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* subBroker                                                 // (in) код субброкера
	, const char* subClient);                                               // (in) код субклиента

QDEALERAPI_API int _stdcall QDAPI_SetSubClientListToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* subBroker                                                 // (in) код субброкера
	, const QDAPI_ArrayStrings* subClientList);                             // (in) список кодов субклиентов

// Получить настройки субброкера
// Под возвращаемое значение "globalLimit" выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSubBrokerSettingsFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* subBroker                                                 // (in) код субброкера
	, int* flagNotAffectedOnGlobalLimit                                    // (out) признак того, что операции субброкера не влияют на глобальный лимит фирмы
	, int* flagAffectedOnGlobalLimit                                       // (out) признак того, что операции субброкера влияют на глобальный лимит фирмы. Содержится в секции [SubBrokerYesGlobals]
	, int* flagWithoutNetting                                              // (out) признак того, что не неттируются лимиты субклиентов. Содержится в секции [SubBrokerWithoutNetting]
	, char** globalLimit);                                                  // (out) глобальный лимит субброкера. В функцию передаётся адрес указателя

// Установить настройки субброкера
QDEALERAPI_API int _stdcall QDAPI_SetSubBrokerSettingsToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* subBroker                                                 // (in) код субброкера
	, const int flagNotAffectedOnGlobalLimit                               // (in) признак того, что операции субброкера не влияют на глобальный лимит фирмы
	, const int flagAffectedOnGlobalLimit                                  // (in) признак того, что операции субброкера влияют на глобальный лимит фирмы. Содержится в секции [SubBrokerYesGlobals]
	, const int flagWithoutNetting                                         // (in) признак того, что не неттируются лимиты субклиентов. Содержится в секции [SubBrokerWithoutNetting]
	, const char* globalLimit);                                             // (in) глобальный лимит субброкера. В функцию передаётся указатель на начало строки
#pragma endregion
//MarginTemplate
#pragma region //=============================== MarginTemplate ===============================
// Добавление одного кода клиента в маржинальный шаблон
QDEALERAPI_API int _stdcall QDAPI_AddClientToMarginTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, const char* clientCode );                                             // (in) код клиента

// Получение полного списка клиентов в маржинальном шаблоне
// Коды клиентов упорядочены лексикографически
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientsListOfMarginTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, QDAPI_ArrayStrings** lsClientCodes );                                 // (out) список кодов клиентов, в функцию передаётся адрес указателя

// Перемещение одного кода клиента из маржинального шаблона в другой маржинальный шаблон
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenMarginTemplates(
		const char* firmCode                                                    // (in) код фирмы
		, const char* fromTemplateCode                                          // (in) название шаблона, из которого удалятся клиент
		, const char* toTemplateCode                                            // (in) название шаблона, в который добавляется клиент
		, const char* clientCode );                                             // (in) код клиента

// Удаление одного кода клиента из маржинального шаблона
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromMarginTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, const char* clientCode );                                             // (in) код клиента

// Изменение полного списка клиентов в маржинальном шаблоне
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfMarginTemplate(
		const char* firmCode                                                    // (in) код фирмы
		, const char* templateCode                                              // (in) название шаблона
		, const QDAPI_ArrayStrings* lsClientCodes );                            // (in) список кодов клиентов
#pragma endregion
#pragma region //============================== SecurityDiscounts =============================
// Получить настройку "Дисконты" (глобальная настройка)
// Секция: [SecurityDiscounts]
QDEALERAPI_API int _stdcall QDAPI_GetSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* secCode                                                   // (in) код бумаги
	, QDAPI_Discounts* discounts );                                         // (out) дисконты, в функцию передаётся адрес объекта

// Получить настройку "Дисконты" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, const char* secCode                                                   // (in) код бумаги
	, QDAPI_Discounts* discounts);                                          // (out) дисконты, в функцию передаётся адрес объекта

// Получить настройку "Дисконты" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, const char* secCode                                                   // (in) код бумаги
	, QDAPI_Discounts* discounts);                                          // (out) дисконты, в функцию передаётся адрес объекта

// Удалить настройку "Дисконты" на заданную бумагу (глобальная настройка)
// Секция: [SecurityDiscounts]
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* secCode);                                                 // (in) код бумаги

// Удалить настройку "Дисконты" на заданную бумагу (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, const char* secCode);                                                 // (in) код бумаги

// Удалить настройку "Дисконты" на заданную бумагу (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, const char* secCode);                                                 // (in) код бумаги


// Установить настройку "Дисконты" (глобальная настройка)
// Секция: [SecurityDiscounts], [General]
QDEALERAPI_API int _stdcall QDAPI_SetSecurityDiscountsToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, const char* secCode                                                   // (in) код бумаги
	, const QDAPI_Discounts* discounts );                                   // (in) дисконты


// Установить настройку "Дисконты" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetSecurityDiscountsToClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, const char* secCode                                                   // (in) код бумаги
	, const QDAPI_Discounts* discounts );                                   // (in) дисконты



// Установить настройку "Дисконты" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetSecurityDiscountsToMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, const char* secCode                                                   // (in) код бумаги
	, const QDAPI_Discounts* discounts );                                   // (in) дисконты
#pragma endregion
#pragma region //============================== UseDiscountsType ==============================
// Получить настройку "Уровень ставки рыночного риска" (глобальная настройка)
// Секция: [General]
QDEALERAPI_API int _stdcall QDAPI_GetUseDiscountsTypeFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int* useDiscountsType );                                              // (out) уровень ставки рыночного риска, в функцию передаётся адрес объекта

// Получить настройку "Уровень ставки рыночного риска" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetUseDiscountsTypeFromClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, int* useDiscountsType );                                              // (out) уровень ставки рыночного риска, в функцию передаётся адрес объекта

// Получить настройку "Уровень ставки рыночного риска" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetUseDiscountsTypeFromMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, int* useDiscountsType );                                              // (out) уровень ставки рыночного риска, в функцию передаётся адрес объекта

// Установить настройку "Уровень ставки рыночного риска" (глобальная настройка)
// Секция: [General]
QDEALERAPI_API int _stdcall QDAPI_SetUseDiscountsTypeToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int useDiscountsType );                                               // (in) уровень ставки рыночного риска

// Установить настройку "Уровень ставки рыночного риска" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetUseDiscountsTypeToClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, int useDiscountsType );                                               // (in) уровень ставки рыночного риска

// Установить настройку "Уровень ставки рыночного риска" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetUseDiscountsTypeToMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, int useDiscountsType );                                               // (in) уровень ставки рыночного риска
#pragma endregion
#pragma region //=========================== UseCHSecurityDiscounts ===========================
// Получить настройку "Использовать дисконты КЦ" (глобальная настройка)
// Секция: [General]
QDEALERAPI_API int _stdcall QDAPI_GetUseCHSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int* useCHSecurityDiscounts );                                        // (out) использовать дисконты КЦ, в функцию передаётся адрес объекта

// Получить настройку "Использовать дисконты КЦ" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetUseCHSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, int* useCHSecurityDiscounts );                                        // (out) использовать дисконты КЦ, в функцию передаётся адрес объекта

// Получить настройку "Использовать дисконты КЦ" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetUseCHSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, int* useCHSecurityDiscounts );                                        // (out) использовать дисконты КЦ, в функцию передаётся адрес объекта

// Установить настройку "Использовать дисконты КЦ" (глобальная настройка)
// Секция: [General]
QDEALERAPI_API int _stdcall QDAPI_SetUseCHSecurityDiscountsToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int useCHSecurityDiscounts );                                         // (in) использовать дисконты КЦ

// Установить настройку "Использовать дисконты КЦ" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetUseCHSecurityDiscountsToClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, int useCHSecurityDiscounts );                                         // (in) использовать дисконты КЦ

// Установить настройку "Использовать дисконты КЦ" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetUseCHSecurityDiscountsToMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, int useCHSecurityDiscounts );                                         // (in) использовать дисконты КЦ
#pragma endregion
#pragma region //============================ UseSecurityDiscounts ============================
// Получить настройку "Использовать настроенные дисконты" (глобальная настройка)
// Секция: [General]
QDEALERAPI_API int _stdcall QDAPI_GetUseSecurityDiscountsFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int* useSecurityDiscounts );                                          // (out) использовать настроенные дисконты, в функцию передаётся адрес объекта

// Получить настройку "Использовать настроенные дисконты" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetUseSecurityDiscountsFromClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, int* useSecurityDiscounts );                                          // (out) использовать настроенные дисконты, в функцию передаётся адрес объекта

// Получить настройку "Использовать настроенные дисконты" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_GetUseSecurityDiscountsFromMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, int* useSecurityDiscounts );                                          // (out) использовать настроенные дисконты, в функцию передаётся адрес объекта

// Установить настройку "Использовать настроенные дисконты" (глобальная настройка)
// Секция: [General]
QDEALERAPI_API int _stdcall QDAPI_SetUseSecurityDiscountsToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, int useSecurityDiscounts );                                           // (in) использовать настроенные дисконты

// Установить настройку "Использовать настроенные дисконты" (индивидуальная настройка на клиента)
// Секция: [cl<код клиента>_Margin], [cl<код клиента>_Margin_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetUseSecurityDiscountsToClientSettings(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, int useSecurityDiscounts );                                           // (in) использовать настроенные дисконты

// Установить настройку "Использовать настроенные дисконты" (настройка маржинального шаблона)
// Секция: [cl<имя шаблона>_Margin_Template], [cl<имя шаблона>_Margin_Template_LimitKind_<вид лимита>]
QDEALERAPI_API int _stdcall QDAPI_SetUseSecurityDiscountsToMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, int limitKind                                                         // (in) вид лимита
	, int useSecurityDiscounts );                                           // (in) использовать настроенные дисконты

#pragma endregion
//RestrictionTemplate
#pragma region //============================= RestrictionTemplate ============================
// Добавление шаблона «По ограничениям»
QDEALERAPI_API int _stdcall QDAPI_AddRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) название шаблона

// Получение списка шаблонов «По ограничениям»
QDEALERAPI_API int _stdcall QDAPI_GetListOfRestrictionTemplates(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsRestrictionTemplateCodes);                     // (out) список наименований шаблонов

// Удаление шаблона «По ограничениям»
QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) название шаблона

// Добавление одного кода клиента в шаблон по ограничениям
QDEALERAPI_API int _stdcall QDAPI_AddClientToRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* clientCode );                                             // (in) код клиента

// Получение полного списка клиентов в шаблоне по ограничениям
// Коды клиентов упорядочены лексикографически
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClientsListOfRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, QDAPI_ArrayStrings** lsClientCodes );                                 // (out) список кодов клиентов, в функцию передаётся адрес указателя

// Перемещение одного кода клиента из шаблона по ограничениям в другой шаблон по ограничениям
QDEALERAPI_API int _stdcall QDAPI_MoveClientBetweenRestrictionTemplates(
	const char* firmCode                                                    // (in) код фирмы
	, const char* fromTemplateCode                                          // (in) название шаблона, из которого удалятся клиент
	, const char* toTemplateCode                                            // (in) название шаблона, в который добавляется клиент
	, const char* clientCode );                                             // (in) код клиента

// Удаление одного кода клиента из шаблона по ограничениям
QDEALERAPI_API int _stdcall QDAPI_RemoveClientFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* clientCode );                                             // (in) код клиента

// Изменение полного списка клиентов в шаблоне по ограничениям
QDEALERAPI_API int _stdcall QDAPI_SetClientsListOfRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const QDAPI_ArrayStrings* lsClientCodes );                            // (in) список кодов клиентов
#pragma endregion
#pragma region //===================== ProhibitRepoByFirstPartSideAndTerm =====================
// Добавить код класса в настройку на <инструмент, направленность первой части, срок РЕПО>
QDEALERAPI_API int _stdcall QDAPI_AddClassToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, const char* classCode);                                               // (in) код класса

QDEALERAPI_API int _stdcall QDAPI_AddClassToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, const char* classCode);                                               // (in) код класса

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode );
, "'QDAPI_AddItemToGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_AddClassToGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode );
, "'QDAPI_AddItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_AddClassToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");

// Получить список кодов классов из настройки на <инструмент, направленность первой части, срок РЕПО>
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, QDAPI_ArrayStrings** lsClassCodes);                                  // (out) список кодов классов, в функцию передаётся адрес указателя

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) список кодов классов, в функцию передаётся адрес указателя

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, QDAPI_ArrayStrings** lsClassCodes );
, "'QDAPI_GetItemFromGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_GetClassListFromGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, QDAPI_ArrayStrings** lsClassCodes );
, "'QDAPI_GetItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_GetClassListFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");

// Удалить код класса из настроек на <инструмент, направленность первой части, срок РЕПО>
QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, const char* classCode);                                               // (in) код класса

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, const char* classCode);                                               // (in) код класса

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode);
, "'QDAPI_RemoveItemFromGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const char* classCode);
, "'QDAPI_RemoveItemFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");

// Установить список кодов классов в настройке на <инструмент, направленность первой части, срок РЕПО>
QDEALERAPI_API int _stdcall QDAPI_SetClassListToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) список кодов классов

QDEALERAPI_API int _stdcall QDAPI_SetClassListToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задана ли направленность первой части
	, char side                                                             // (in) направленность первой части. Возможные значения: 'B' и 'S'
	, int isRepoTermExist                                                   // (in) задан ли срок РЕПО
	, int repoTerm                                                          // (in) срок РЕПО. Возможные значения: целочисленное значение больше либо равное 0
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) список кодов классов

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToGlobalProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToGlobalProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_SetClassListToGlobalProhibitRepoByFirstPartSideAndTerm'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, int isRepoTermExist, int repoTerm, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm': was declared deprecated. Instead, use 'QDAPI_SetClassListToRestrictionTemplateProhibitRepoByFirstPartSideAndTerm'.");
#pragma endregion
#pragma region //========================= RestrictRepoByFirstPartSide ========================
QDEALERAPI_API int _stdcall QDAPI_AddSecurityToRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, const char* templateCode                                                // (in) название шаблона
	, const char* classCode                                                   // (in) код класса
	, QDAPI_OperationSide side                                                // (in) направленность
	, const char* secCode);                                                   // (in) код инструмента

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, const char* templateCode                                                // (in) название шаблона
	, QDAPI_OperationSide side                                                // (in) направленность
	, QDAPI_ArrayClassBySide** lsClassCodes);                                 // (out) список кодов классов с указанием направленности

QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, const char* templateCode                                                // (in) название шаблона
	, const char* classCode                                                   // (in) код класса
	, QDAPI_OperationSide side                                                // (in) направленность
	, QDAPI_ArrayStrings** lsSecurityCodes);                                  // (out) список кодов инструментов

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, const char* templateCode                                                // (in) название шаблона
	, const char* classCode                                                   // (in) код класса
	, QDAPI_OperationSide side);                                              // (in) направленность

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityFromRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, const char* templateCode                                                // (in) название шаблона
	, const char* classCode                                                   // (in) код класса
	, QDAPI_OperationSide side                                                // (in) направленность
	, const char* secCode);                                                   // (in) код инструмента

QDEALERAPI_API int _stdcall QDAPI_SetSecurityListToRestrictionTemplateRestrictRepoByFirstPartSide(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, const char* templateCode                                                // (in) название шаблона
	, const char* classCode                                                   // (in) код класса
	, QDAPI_OperationSide side                                                // (in) направленность
	, const QDAPI_ArrayStrings* lsSecurityCodes);                             // (in) список кодов инструментов
#pragma endregion
#pragma region //=============================== SecurityAllowed ==============================
// Шаблонная настройка:
//   [cl<TemplateName>_Restriction_Template]
//   SecurityAllowed_<Security>=<Class1>,<Class2>,…,<ClassN>
// <Security> - код инструмента
// <Class1>,<Class2>,…,<ClassN> - список кодов классов.

// Добавить код класса в настройку на инструмент
QDEALERAPI_API int _stdcall QDAPI_AddItemToRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, const char* classCode );                                              // (in) код класса

// Получить список кодов классов из настройки на инструмент
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetItemFromRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, QDAPI_ArrayStrings** lsClassCodes );                                  // (out) список кодов классов, в функцию передаётся адрес указателя

// Удалить код класса из настроек на инструмент
QDEALERAPI_API int _stdcall QDAPI_RemoveItemFromRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, const char* classCode );                                              // (in) код класса

// Установить список кодов классов в настройке на инструмент
QDEALERAPI_API int _stdcall QDAPI_SetItemToRestrictionTemplateSecurityAllowed(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, const QDAPI_ArrayStrings* lsClassCodes );                             // (in) список кодов классов
#pragma endregion
#pragma region //============================= SecurityRestricted =============================
// Глобальная настройка:
//   [SecurityRestricted]
//   <Security>,<Side>=<Class1>,<Class2>,…,<ClassN>
// Шаблонная настройка:
//   [cl<TemplateName>_Restriction_Template]
//   SecurityRestricted_<Security>,<Side>=<Class1>,<Class2>,…,<ClassN>
// <Security> - код инструмента
// <Side> - направление, может принимать следующие значения:
//   <пусто> – соответствует любому направлению заявки, значение по умолчанию
//   B – соответствует направленности «Покупка».
//   S – соответствует направленности «Продажа».
// <Class1>,<Class2>,…,<ClassN> - список кодов классов, может принимать значение <ALL>.

// Получить список кодов инструментов с указанием направленности, на которые заданы настройки (<инструмент,направление>)
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_OperationSide side                                              // (in) направленность
	, QDAPI_ArraySecurityBySide** lsSecurityCodes);                         // (out) список кодов инструментов с указанием направленности, в функцию передаётся адрес указателя

QDEALERAPI_API int _stdcall QDAPI_GetSecurityListFromRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) код шаблона
	, QDAPI_OperationSide side                                              // (in) направленность
	, QDAPI_ArraySecurityBySide** lsSecurityCodes);                         // (out) список кодов инструментов с указанием направленности, в функцию передаётся адрес указателя

// Добавить код класса в настройку на <инструмент,направление>
QDEALERAPI_API int _stdcall QDAPI_AddClassToGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, const char* classCode);                                               // (in) код класса

QDEALERAPI_API int _stdcall QDAPI_AddClassToRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, const char* classCode);                                               // (in) код класса

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, const char* classCode);
, "'QDAPI_AddItemToGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_AddClassToGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_AddItemToRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, const char* classCode);
, "'QDAPI_AddItemToRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_AddClassToRestrictionTemplateSecurityRestricted'.");

// Получить список кодов классов из настройки на <инструмент,направление>
// Под возвращаемое значение выделяется память, которую необходимо освободить явным вызовом функции QDAPI_FreeMemory
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) список кодов классов, в функцию передаётся адрес указателя

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, QDAPI_ArrayStrings** lsClassCodes);                                   // (out) список кодов классов, в функцию передаётся адрес указателя

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, QDAPI_ArrayStrings** lsClassCodes);
, "'QDAPI_GetItemFromGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_GetClassListFromGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_GetItemFromRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, QDAPI_ArrayStrings** lsClassCodes);
, "'QDAPI_GetItemFromRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_GetClassListFromRestrictionTemplateSecurityRestricted'.");

// Удалить код класса из настроек на <инструмент,направление>
QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, const char* classCode);                                               // (in) код класса
QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, const char* classCode);                                               // (in) код класса

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, const char* classCode );
, "'QDAPI_RemoveItemFromGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_RemoveItemFromRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, const char* classCode );
, "'QDAPI_RemoveItemFromRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_RemoveClassFromRestrictionTemplateSecurityRestricted'.");

// Установить список кодов классов в настройке на <инструмент,направление>
QDEALERAPI_API int _stdcall QDAPI_SetClassListToGlobalSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) список кодов классов

QDEALERAPI_API int _stdcall QDAPI_SetClassListToRestrictionTemplateSecurityRestricted(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const char* secCode                                                   // (in) код инструмента
	, int isSideExist                                                       // (in) задано ли направление
	, char side                                                             // (in) направление
	, const QDAPI_ArrayStrings* lsClassCodes);                              // (in) список кодов классов

DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToGlobalSecurityRestricted(
	const char* firmCode, const char* secCode, int isSideExist, char side, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToGlobalSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_SetClassListToGlobalSecurityRestricted'.");
DEPRECATED(QDEALERAPI_API, int _stdcall QDAPI_SetItemToRestrictionTemplateSecurityRestricted(
	const char* firmCode, const char* templateCode, const char* secCode, int isSideExist, char side, const QDAPI_ArrayStrings* lsClassCodes);
, "'QDAPI_SetItemToRestrictionTemplateSecurityRestricted': was declared deprecated. Instead, use 'QDAPI_SetClassListToRestrictionTemplateSecurityRestricted'.");
#pragma endregion

// 1.8
#pragma region //===================== ClientTemplate -> SecurityDiscounts ====================
//Получение списка инструментов из глобальной настройки собственных дисконтов.Данная настройка задается в секции[SecurityDiscounts].
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromGlobalSecurityDiscounts(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

//Получение списка инструментов из шаблонной настройки собственных дисконтов.
//Настройка задается в секциях вида [cl<TemplateID>_Margin_Template_<LimitKind>] (для лимита Т0 секции имеют вид [cl<TemplateID>_Margin_Template]).
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromMarginTemplateSecurityDiscounts(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона
	, int limitKind                                                         // (in) вид лимита
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

// Получение списка инструментов из индивидуальной настройки собственных дисконтов. Настройка задается в секциях вида [cl<ClientID>_Margin_<LimitKind>] (для лимита Т0 секции имеют вид [cl<ClientID>_Margin]).
// Если настройка не задана – возвращается пустой список. Если для указанного кода клиента настроек нет (нет секций на этот код клиента/префикс) – возвращается ошибка QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND
// Если для указанного кода клиента/префикса существуют индивидуальные настройки «По плечу», но для заданного вида лимита настройка не задана – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromClientSettingsSecurityDiscounts(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента
	, int limitKind                                                         // (in) вид лимита
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов
#pragma endregion
#pragma region //============================= Global -> TranoutTag ===========================
// Получение всех значений настройки, т.е. всех значений из секции [TranoutTag]. Если настройка не задана – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromTranoutTagGlobal(
	const char* firmCode                                                    // (in)  код фирмы
	, QDAPI_ArrayTranoutTag** lsSettings);                                  // (out) список значений

// Устанавливает (перезаписывает) настройку. При записи пустого списка настройка (секция [TranoutTag]) удаляется.
QDEALERAPI_API int _stdcall QDAPI_SetSettingsToTranoutTagGlobal(
	const char* firmCode                                                    // (in)  код фирмы
	, const QDAPI_ArrayTranoutTag* lsSettings);                             // (in) список значений

#pragma endregion
#pragma region //=========================== SecurityProhibitedTrdAcc =========================
// Получение списка всех торговых счетов, для которых заданы ограничения. Если секция [SecurityProhibitedTrdAcc] не задана,
// или задана, но не содержит ни одного торгового счета, то возвращается пустой список.
// Если на один и тот же торговый счет задано несколько настроек, то дубликаты из списка не удаляются, а возвращаются как есть.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) список торговых счетов

// Получение списка инструментов, на которые задано ограничение хотя бы для одного торгового счета.
// Если секция[SecurityProhibitedTrdAcc] не задана, или задана, но не содержит ни одного кода инструмента, то возвращается пустой список.Дубликаты из списка удаляются.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

// Получение списка инструментов для конкретного торгового счета.Если данные не найдены, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
// Если для одного и того же торгового счета задано несколько списков – возвращается ошибка QDAPI_ERROR_INVALID_SETTINGS_FORMAT.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForTrdAccFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

// Получение списка торговых счетов, для которых заданы ограничения на конкретный инструмент.Если данные не найдены, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsForInstrFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* instrument                                                // (in) инструмент
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) список торговых счетов

// Добавление кода инструмента к списку инструментов для конкретного счета.Если счет не найден – он добавляется.
// Если для счета уже задан данный инструмент, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.Если для счета задано более одного списка – возвращается ошибка QDAPI_ERROR_INVALID_SETTINGS_FORMAT.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForTradeAccToSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, const char* instrument);                                              // (in) инструмент

// Задание списка инструментов для конкретного торгового счета. Если список инструментов пуст, то ограничение для указанного торгового счета не сохраняется / удаляется.
// Таким образом, данная функция реализует возможности удаления настроек. Если ошибочно задано несколько настроек на один торговый счет (или префикс) – при задании пустого списка удаляются все строки с этим торговым счетов.
// Если происходит попытка записи непустого списка в ситуации, когда для торгового счета УЖЕ существует более одной строки в настройках – все строки с указанным счетом удаляются и создается одна новая строка с заданными настройками.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForTradeAccToSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) список инструментов

// Удаление кода инструмента из списка инструментов для конкретного счета.Если счет или бумага не найдены – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
// Если в результате удаления кода инструмента список становится пустым – строка с торговым счетом удаляется.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForTradeAccFromSecProhibitedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, const char* instrument);                                              // (in) инструмент

#pragma endregion
#pragma region //======================== Global -> SecurityAllowedTrdAcc =====================
// Получение списка всех торговых счетов, для которых заданы разрешения. Если секция [SecurityAllowedTrdAcc] не задана, или задана,
// но не содержит ни одного торгового счета, то возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) список торговых счетов

// Получение списка инструментов, на которые задано разрешение хотя бы для одного торгового счета. Если секция [SecurityAllowedTrdAcc] не задана,
// или задана, но не содержит ни одного кода инструмента, то возвращается пустой список. Дубликаты из списка удаляются.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

// Получение списка инструментов для конкретного торгового счета. Если данные не найдены, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForTrdAccFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

// Получение списка торговых счетов, для которых заданы разрешения на конкретный инструмент. Если данные не найдены, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfTradeAccsForInstrFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* instrument                                                // (in) инструмент
	, QDAPI_ArrayStrings** lsTradeAccounts);                                // (out) список торговых счетов

// Добавление кода инструмента к списку инструментов для конкретного счета. Если счет не найден – он добавляется. Если для счета уже задан данный инструмент,
// то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForTradeAccToSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, const char* instrument);                                              // (in) инструмент

// Задание списка инструментов для конкретного торгового счета. Если список инструментов пуст, то разрешение для указанного торгового счета не сохраняется / удаляется.
// Таким образом, данная функция реализует возможности удаления настроек.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForTradeAccToSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) список инструментов

// Удаление кода инструмента из списка инструментов для конкретного счета. Если счет или бумага не найдены – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
// Если в результате удаления кода инструмента список становится пустым – строка с торговым счетом удаляется.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForTradeAccFromSecAllowedTrdAccsGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* tradeAccount                                              // (in) торговый счет
	, const char* instrument);                                              // (in) инструмент

#pragma endregion
#pragma region //=========================== RESTSECURITY_IN_TEMPLATE =========================
// Получение списка всех классов, заданных в настройке для конкретного шаблона по комиссии.Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// Если настройка не содержит ни одного класса(не задана), то возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetListOfClassesFromClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings** lsClasses);                                      // (out) список классов

// Получение списка всех классов, заданных в настройке для конкретного клиента / префикса.Если настроек на указанный код клиента или префикс не существует, то возвращается ошибка QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// Если настройка не содержит ни одного класса(не задана), то возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetListOfClassesFromClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента или префикс
	, QDAPI_ArrayStrings** lsClasses);                                      // (out) список классов

// Получение списка инструментов, заданных для класса в конкретном шаблоне по комиссии.Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// Если данные не найдены(для класса настройка не задана), то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForClassFromClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

// Получение списка инструментов, заданных для класса для конкретного клиента / префикса.Если настроек на указанный код клиента или префикс не существует, то возвращается ошибка QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// Если данные не найдены(для класса настройка не задана), то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetListOfInstrumentsForClassFromClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента или префикс
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsInstruments);                                  // (out) список инструментов

// Добавление кода инструмента в список инструментов для определенного класса в рамках конкретного шаблона по комиссии.Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// Если класс не найден – он добавляется.Если для класса уже задан данный инструмент, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForClassToClientTemplateRestrictedSecurity(
	const char*  firmCode                                                   // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, const char* instrument);                                              // (in) инструмент

// Добавление кода инструмента в список инструментов для определенного класса в рамках настроек для конкретного клиента / префикса.Если настроек на указанный код клиента или префикс не существует, то возвращается ошибка QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// Если класс не найден – он добавляется.Если для класса уже задан данный инструмент, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddInstrForClassToClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента или префикс
	, const char* classCode                                                 // (in) код класса
	, const char* instrument);                                              // (in) инструмент

// Задание списка инструментов для определенного класса в рамках конкретного шаблона по комиссии.Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// Если список инструментов пуст, то ограничение для указанного класса не сохраняется / удаляется.Таким образом, данная функция реализует возможности удаления настроек.Если класс не найден – он добавляется.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForClassToClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsInstruments);                             // (in) список инструментов

// Задание списка инструментов для определенного класса в рамках настроек для конкретного клиента / префикса.Если настроек на указанный код клиента или префикс не существует, то возвращается ошибка QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// Если список инструментов пуст, то ограничение для указанного класса не сохраняется / удаляется.Таким образом, данная функция реализует возможности удаления настроек.Если класс не найден – он добавляется.
QDEALERAPI_API int _stdcall QDAPI_SetInstrListForClassToClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента или префикс
	, const char* classCode                                                 // (in) код класса
	, const QDAPI_ArrayStrings* lsInstruments);                             // (in) список инструментов

// Удаление кода инструмента из списка для определенного класса в рамках конкретного шаблона по комиссии.Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// Если класс или бумага не найдены – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.Если в результате удаления кода инструмента список становится пустым – строка для указанного класса удаляется.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForClassFromClientTemplateRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, const char* instrument);                                              // (in) инструмент

// Удаление кода инструмента из списка для определенного класса в рамках настроек для  конкретного клиента / префикса. Если настроек на указанный код клиента или префикс не существует, то возвращается ошибка QDAPI_ERROR_CLIENT_SETTINGS_NOT_FOUND.
// Если класс или бумага не найдены – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.Если в результате удаления кода инструмента список становится пустым – строка для указанного класса удаляется.
QDEALERAPI_API int _stdcall QDAPI_RemoveInstrForClassFromClientSettingsRestrictedSecurity(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* clientCode                                                // (in) код клиента или префикс
	, const char* classCode                                                 // (in) код класса
	, const char* instrument);                                              // (in) инструмент
#pragma endregion
#pragma region //=============================== MaxPositionLimit =============================
// Получение всех заданных в глобальной настройке ограничений на максимальный размер позиции, или ограничений на конкретный список инструментов.Если ограничений нет – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMaxPositionLimitFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const  QDAPI_ArrayStrings* lsInstruments                              // (in) список инструментов
	, QDAPI_ArrayMaxPositionLimit** lsRestrs);                              // (out) список ограничений

// Получение всех заданных в шаблоне «По ограничениям» ограничений на максимальный размер позиции, или ограничений на конкретный список инструментов.
// Если ограничений нет – возвращается пустой список.Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetMaxPositionLimitFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const  QDAPI_ArrayStrings* lsInstruments                              // (in) список инструментов
	, QDAPI_ArrayMaxPositionLimit** lsRestrs);                              // (out) список ограничений

// Установка ограничений на перечень инструментов в глобальной настройке.Если настройка для такого перечня уже существует(полностью совпадающая), то она полностью перезаписывается,
// а если не существует – создается.Если в указанном списке инструментов есть хотя бы один код инструмента, который встречается в других сочетаниях в этой же настройке,
// но при этом сами списки не совпадают, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST(так как задание нескольких ограничений для одного и того же инструмента не допускается).
QDEALERAPI_API int _stdcall QDAPI_SetMaxPositionLimitToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const  QDAPI_ArrayMaxPositionLimit* lsRestrs);                        // (in) список ограничений

// Установка ограничений на перечень инструментов в шаблоне «По ограничениям».Если настройка для такого перечня уже существует(полностью совпадающая), то она полностью перезаписывается,
// а если не существует – создается.Если в указанном списке инструментов есть хотя бы один код инструмента, который встречается в других сочетаниях в этой же настройке,
// но при этом сами списки не совпадают, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST(так как задание нескольких ограничений для одного и того же инструмента не допускается).
// Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_SetMaxPositionLimitToRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const  QDAPI_ArrayMaxPositionLimit* lsRestrs);                        // (in) список ограничений

// Удаление ограничений на перечень инструментов в глобальной настройке.Если указанный перечень(полностью совпадающий) не существует, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMaxPositionLimitFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const  QDAPI_ArrayStrings* lsInstruments);                            // (in) список инструментов

// Удаление ограничений на перечень инструментов в шаблоне «По ограничениям».Если указанный перечень(полностью совпадающий) не существует, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
// Если шаблон не существует, то возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMaxPositionLimitFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) название шаблона
	, const  QDAPI_ArrayStrings* lsInstruments);                            // (in) список инструментов
#pragma endregion
#pragma region //================================ ClientTemplate ==============================
// Добавление шаблона «По комиссии».Если шаблон уже существует – возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddClientTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) код шаблона

// Удаление шаблона «По комиссии».Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveClientTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) код шаблона

// Получение списка всех шаблонов «По комиссии».Если ни одного шаблона не найдено – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetListOfClientTemplates(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsClientTemplateCodes);                          // (out)список кодов шаблонов

// Получение списка значений плеч из настройки «Включать в шаблон клиентов со значением плеча» в конкретном шаблоне «По комиссии».
// Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND. Если значение плеча не задано – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetIncludeClientsWithLeverageFromClientTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона «По комиссии»
	, QDAPI_ArrayDoubleNumbers** lsLeverages);                              // (out) настройки плеча

// Задание списка значений плеч в настройке «Включать в шаблон клиентов со значением плеча» в конкретном шаблоне «По комиссии». Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// При попытке задания плеча, совпадающего со значением в другом шаблоне того же типа, возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST. Функция также реализует функционал удаления настройки, для чего необходимо задать пустой список.
QDEALERAPI_API int _stdcall QDAPI_SetIncludeClientsWithLeverageToClientTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона «По комиссии»
	, const QDAPI_ArrayDoubleNumbers* lsLeverages);                         // (in) настройки плеча
#pragma endregion
#pragma region //================================ MarginTemplate ==============================
// Добавление шаблона «По плечу».Если шаблон уже существует – возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) код шаблона

// Удаление шаблона «По плечу».Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode);                                            // (in) код шаблона

// Получение списка всех шаблонов «По плечу».Если ни одного шаблона не найдено – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetListOfMarginTemplates(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsMarginTemplateCodes);                          // (out)список

// Получение списка значений плеч из настройки «Включать в шаблон клиентов со значением плеча» в конкретном шаблоне «По плечу». Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// Если значение плеча не задано – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetIncludeClientsWithLeverageFromMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона «По плечу»
	, QDAPI_ArrayDoubleNumbers** lsLeverages);                              // (out) настройки плеча

// Задание списка значений плеч в настройке «Включать в шаблон клиентов со значением плеча» в конкретном шаблоне «По плечу». Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// При попытке задания плеча, совпадающего со значением в другом шаблоне того же типа, возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST. Функция также реализует функционал удаления настройки, для чего необходимо задать пустой список.
QDEALERAPI_API int _stdcall QDAPI_SetIncludeClientsWithLeverageToMarginTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона «По плечу»
	, const QDAPI_ArrayDoubleNumbers* lsLeverages);                         // (in) настройки плеча
#pragma endregion

// 1.9
#pragma region //================================== LimitKinds =================================
// Получение индивидуальной настройки цепочки лимитов для конкретного вида лимита.При отсутствии настройки возвращается пустой список.
// Если указанный в качестве входящего параметра вид лимита, для которого необходимо получить настройку, отсутствует в глобальной настройке – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetClientSettingsLimitKinds(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, int limitKind                                                         // (in) вид лимита
	, QDAPI_ArrayIntNumbers** lsLimitKinds);                                // (out) список лимитов
// Получение цепочки лимитов для конкретного вида лимита шаблона «По плечу».При отсутствии настройки возвращается пустой список.\
// Если указанный в качестве входящего параметра вид лимита, для которого необходимо получить настройку, отсутствует в глобальной настройке – возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_GetMarginTemplateLimitKinds(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) наименование шаблона
	, int limitKind                                                         // (in) вид лимита
	, QDAPI_ArrayIntNumbers** lsLimitKinds);                                // (out) список лимитов
// Получение цепочки лимитов из глобальной настройки.При отсутствии настройки возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetGlobalLimitKinds(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayIntNumbers** lsLimitKinds);                                // (out) список лимитов
// Задание индивидуальной настройки цепочки лимитов для конкретного вида лимита.Удаление настройки реализуется при помощи задания пустого списка.
// Если вид лимита, для которого необходимо задать настройку, не задан в глобальной настройке - возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_SetClientSettingsLimitKinds(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, int limitKind                                                         // (in) вид лимита
	, QDAPI_ArrayIntNumbers* lsLimitKinds);                                 // (in) список лимитов
// Задание цепочки лимитов для конкретного вида лимита шаблона «По плечу».Удаление настройки реализуется при помощи задания пустого списка.
// Если вид лимита, для которого необходимо задать настройку, не задан в глобальной настройке - возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_SetMarginTemplateLimitKinds(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) наименование шаблона
	, int limitKind                                                         // (in) вид лимита
	, QDAPI_ArrayIntNumbers* lsLimitKinds);                                 // (in) список лимитов
// Задание цепочки лимитов из глобальной настройки.Удаление настройки реализуется при помощи задания пустого списка.
QDEALERAPI_API int _stdcall QDAPI_SetGlobalLimitKinds(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayIntNumbers* lsLimitKinds);                                 // (in) список лимитов
#pragma endregion
#pragma region //========================= AllowedPartnersAndSettleCodes =======================
QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) список контрагентов для указанного сочетания ключевых параметров

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm                                                     // (in) максимальный срок РЕПО
	, QDAPI_ArrayStrings** lsCP);                                           // (out) список кодов контрагентов

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm);                                                   // (in) максимальный срок РЕПО

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientSettingsAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) список контрагентов для указанного сочетания ключевых параметров

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm                                                     // (in) максимальный срок РЕПО
	, QDAPI_ArrayStrings** lsCP);                                           // (out) список кодов контрагентов

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm);                                                   // (in) максимальный срок РЕПО

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientTemplateAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_AddCPListToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) список контрагентов для указанного сочетания ключевых параметров

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm                                                     // (in) максимальный срок РЕПО
	, QDAPI_ArrayStrings** lsCP);                                           // (out) список кодов контрагентов

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm);                                                   // (in) максимальный срок РЕПО

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToGlobalAllowedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) списки контрагентов

#pragma endregion
#pragma region //======================= ProhibitedPartnersAndSettleCodes ======================
QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) список контрагентов для указанного сочетания ключевых параметров

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm                                                     // (in) максимальный срок РЕПО
	, QDAPI_ArrayStrings** lsCP);                                           // (out) список кодов контрагентов

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm);                                                   // (in) максимальный срок РЕПО

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientSettingsProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) код клиента/префикс
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_AddCPListToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) список контрагентов для указанного сочетания ключевых параметров

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm                                                     // (in) максимальный срок РЕПО
	, QDAPI_ArrayStrings** lsCP);                                           // (out) список кодов контрагентов

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm);                                                   // (in) максимальный срок РЕПО

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToClientTemplateProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_AddCPListToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_PartnersAndSettleCodesRestrictions* lsCP);                      // (in) список контрагентов для указанного сочетания ключевых параметров

QDEALERAPI_API int _stdcall QDAPI_GetSettingsFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions** lsSettings);          // (out) списки контрагентов

QDEALERAPI_API int _stdcall QDAPI_GetCPListFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm                                                     // (in) максимальный срок РЕПО
	, QDAPI_ArrayStrings** lsCP);                                           // (out) список кодов контрагентов

QDEALERAPI_API int _stdcall QDAPI_RemoveCPListFromGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings* lsSettleCodes                                     // (in) список кодов расчетов
	, QDAPI_OperationSide operationSide                                     // (in) направленность операции
	, long long maxTerm);                                                   // (in) максимальный срок РЕПО

QDEALERAPI_API int _stdcall QDAPI_SetSettingsToGlobalProhibitedPartnersAndSettleCodes(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayPartnersAndSettleCodesRestrictions* lsSettings);           // (in) списки контрагентов
#pragma endregion
#pragma region  //========================== Global -> MinOrderQty ==============================
// Получение всех заданных в глобальной настройке ограничений. Возможно указание конкретных значений классов и инструментов в качестве фильтрующих условий.
// При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromGlobal(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, QDAPI_ArrayStrings* lsClasses                                           // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments                                       // (in) список инструментов
	, QDAPI_ArrayMinOrderQty** lsRestrictions);                               // (out) список ограничений

// добавление глобального ограничения для конкретного списка классов и инструментов. Если хотя бы для одного сочетания  «класс + инструмент»(анализируются все возможные сочетания
// заданных в списках классов и инструментов) уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST. Пустое значение списка инструментов рассматривается как полноценное значение.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToGlobal(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, QDAPI_MinOrderQty* restriction);                                        // (in) ограничение

// задание ограничений в глобальной настройке. Функция полностью перезаписывает все настройки. Если в функции задан пустой список – удаляются все текущие ограничения.
// При попытке задания в одном вызове функции более одного ограничения для одного и того же сочетания класса и инструмента (с учетом варианта задания пустого списка инструментов) возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToGlobal(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, QDAPI_ArrayMinOrderQty* restriction);                                   // (in) ограничение

// удаление глобального ограничения для конкретного списка классов и инструментов. Если для заданного множества ключевых параметров (список классов + список инструментов) ограничение не задано,
// то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND. В отличие от функций другого типа для удаления требуется полное совпадение списка классов и инструментов (с учетом того, что список инструментов может быть пустым).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromGlobal(
	const char* firmCode                                                      // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                       // (in) тип настроек
	, QDAPI_ArrayStrings* lsClasses                                           // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments);                                     // (in) список инструментов


#pragma endregion
#pragma region //========================== Global -> OrderMinValue ============================
// получение всех заданных в глобальной настройке ограничений. Возможно указание конкретных значений классов и инструментов в качестве фильтрующих условий.
// При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) список инструментов
	, QDAPI_ArrayMinOrderValue** lsRestrictions);                           // (out) список ограничений

// добавление глобального ограничения для конкретного списка классов и инструментов.Если хотя бы для одного сочетания  «класс + инструмент»(анализируются все возможные сочетания
//заданных в списках классов и инструментов) уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.Пустое значение списка инструментов рассматривается как полноценное значение.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_MinOrderValue* restriction);                                    // (in) ограничение

// задание ограничений в глобальной настройке. Функция полностью перезаписывает все настройки. Если в функции задан пустой список – удаляются все текущие ограничения.
// При попытке задания в одном вызове функции более одного ограничения для одного и того же сочетания класса и инструмента (с учетом варианта задания пустого списка инструментов) возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayMinOrderValue* restrictions);                              // (in) ограничения

// удаление глобального ограничения для конкретного списка классов и инструментов. Если для заданного множества ключевых параметров (список классов + список инструментов) ограничение не задано,
// то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND. В отличие от функций другого типа для удаления требуется полное совпадение списка классов и инструментов (с учетом того, что список инструментов может быть пустым).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) список инструментов
#pragma endregion
#pragma region //====================== RestrictionTemplate -> MinOrderQty =====================
// Gолучение всех заданных в шаблоне настройке ограничений. Возможно указание конкретных значений классов и инструментов в качестве фильтрующих условий.
// При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) список инструментов
	, QDAPI_ArrayMinOrderQty** lsRestrictions);                             // (out) список ограничений

// добавление шаблонного ограничения для конкретного списка классов и инструментов. Если хотя бы для одного сочетания  «класс + инструмент»(анализируются все возможные сочетания
// заданных в списках классов и инструментов) уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST. Пустое значение списка инструментов рассматривается как полноценное значение.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_MinOrderQty* restriction);                                      // (in) ограничение

// задание ограничений в шаблонной настройке. Функция полностью перезаписывает все настройки. Если в функции задан пустой список – удаляются все текущие ограничения.
// При попытке задания в одном вызове функции более одного ограничения для одного и того же сочетания класса и инструмента (с учетом варианта задания пустого списка инструментов) возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayMinOrderQty* restriction);                                 // (in) ограничение

// удаление шаблонного ограничения для конкретного списка классов и инструментов. Если для заданного множества ключевых параметров (список классов + список инструментов) ограничение не задано,
// то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND. В отличие от функций другого типа для удаления требуется полное совпадение списка классов и инструментов (с учетом того, что список инструментов может быть пустым).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) список инструментов
#pragma endregion
#pragma region //===================== RestrictionTemplate -> OrderMinValue ====================
// получение всех заданных в шаблоне ограничений. Возможно указание конкретных значений классов и инструментов в качестве фильтрующих условий.
// При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments                                     // (in) список инструментов
	, QDAPI_ArrayMinOrderValue** lsRestrictions);                           // (out) список ограничений

// добавление шаблонного ограничения для конкретного списка классов и инструментов.Если хотя бы для одного сочетания  «класс + инструмент»(анализируются все возможные сочетания
//заданных в списках классов и инструментов) уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.Пустое значение списка инструментов рассматривается как полноценное значение.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_MinOrderValue* restriction);                                    // (in) ограничение

// задание ограничений в шаблонной настройке. Функция полностью перезаписывает все настройки. Если в функции задан пустой список – удаляются все текущие ограничения.
// При попытке задания в одном вызове функции более одного ограничения для одного и того же сочетания класса и инструмента (с учетом варианта задания пустого списка инструментов) возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayMinOrderValue* restrictions);                              // (in) ограничения

// удаление шаблонного ограничения для конкретного списка классов и инструментов. Если для заданного множества ключевых параметров (список классов + список инструментов) ограничение не задано,
// то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND. В отличие от функций другого типа для удаления требуется полное совпадение списка классов и инструментов (с учетом того, что список инструментов может быть пустым).
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                     // (in) тип настроек
	, const char* templateCode                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayStrings* lsInstruments);                                   // (in) список инструментов
#pragma endregion
#pragma region //====================== ClientTemplate -> MinOrderQuantity =====================
// получение всех заданных в шаблоне ограничений.Возможно указание конкретного значения класса в качестве фильтрующего условия.При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, const char* classCode                                                     // (in) класс
	, QDAPI_ArrayClassMinOrderQty** lsRestrictions);                            // (out) список ограничений

// добавление шаблонного ограничения для конкретного класса.Если для указанного класса уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, QDAPI_ClassMinOrderQty* restriction);                                     // (in) ограничение

// задание ограничений в шаблонной настройке.Функция полностью перезаписывает все настройки.Если в функции задан пустой список – удаляются все текущие ограничения.При попытке задания в одном вызове функции более одного ограничения для одного и того же класса возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, QDAPI_ArrayClassMinOrderQty* restrictions);                               // (in) ограничения

// удаление шаблонного ограничения для конкретного класса.Если для указанного класса ограничение не задано, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, const char* classCode);                                                   // (in) код класса

// получение всех заданных в индивидуальных / префиксных настройках ограничений.Возможно указание конкретного значения класса в качестве фильтрующего условия.При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderQtyFromClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, const char* classCode                                                     // (in) класс
	, QDAPI_ArrayClassMinOrderQty** lsRestrictions);                            // (out) список ограничений

// добавление индивидуального / префиксного ограничения для конкретного класса.Если для указанного класса уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderQtyToClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, QDAPI_ClassMinOrderQty* restriction);                                     // (in) ограничение

// задание ограничений в индивидуальной / префиксной настройке.Функция полностью перезаписывает все настройки.Если в функции задан пустой список – удаляются все текущие ограничения.При попытке задания в одном вызове функции более одного ограничения для одного и того же класса возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderQtyToClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, QDAPI_ArrayClassMinOrderQty* restrictions);                               // (in) ограничения

// удаление индивидуального / префиксного ограничения для конкретного класса.Если для указанного класса ограничение не задано, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderQtyFromClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, const char* classCode);                                                   // (in) код класса
#pragma endregion
#pragma region //======================== ClientTemplate -> OrderMinValue ======================
// получение всех заданных в шаблоне ограничений.Возможно указание конкретного значения класса в качестве фильтрующего условия.При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, const char* classCode                                                     // (in) класс
	, QDAPI_ArrayClassMinOrderValue** lsRestrictions);                          // (out) список ограничений

// добавление шаблонного ограничения для конкретного класса.Если для указанного класса уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, QDAPI_ClassMinOrderValue* restriction);                                   // (in) ограничение

// задание ограничений в шаблонной настройке.Функция полностью перезаписывает все настройки.Если в функции задан пустой список – удаляются все текущие ограничения.При попытке задания в одном вызове функции более одного ограничения для одного и того же класса возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, QDAPI_ArrayClassMinOrderValue* restrictions);                             // (in) ограничения

// удаление шаблонного ограничения для конкретного класса.Если для указанного класса ограничение не задано, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromClientTemplate(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                           // (in) тип настроек
	, const char* templateCode                                                  // (in) наименование шаблона
	, const char* classCode);                                                   // (in) код класса

// получение всех заданных в индивидуальных / префиксных настройках ограничений.Возможно указание конкретного значения класса в качестве фильтрующего условия.При отсутствии ограничений возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetMinOrderValueFromClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, const char* classCode                                                     // (in) класс
	, QDAPI_ArrayClassMinOrderValue** lsRestrictions);                          // (out) список ограничений

// добавление индивидуального / префиксного ограничения для конкретного класса.Если для указанного класса уже задано ограничение, то возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_AddMinOrderValueToClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, QDAPI_ClassMinOrderValue* restriction);                                   // (in) ограничение

// задание ограничений в индивидуальной / префиксной настройке.Функция полностью перезаписывает все настройки.Если в функции задан пустой список – удаляются все текущие ограничения.При попытке задания в одном вызове функции более одного ограничения для одного и того же класса возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST.
QDEALERAPI_API int _stdcall QDAPI_SetMinOrderValueToClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, QDAPI_ArrayClassMinOrderValue* restrictions);                             // (in) ограничения

// удаление индивидуального / префиксного ограничения для конкретного класса.Если для указанного класса ограничение не задано, то возвращается ошибка QDAPI_ERROR_DATA_NOT_FOUND.
QDEALERAPI_API int _stdcall QDAPI_RemoveMinOrderValueFromClientSettings(
	const char* firmCode                                                        // (in) код фирмы
	, QDAPI_SettingsScope settingsScope                                         // (in) тип настроек
	, const char* clientCode                                                    // (in) код клиента/префикс
	, const char* classCode);                                                   // (in) код класса
#pragma endregion
#pragma region //=================== ClientTemplate -> VolumeBasedCommission ===================

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) наименование шаблона
	, QDAPI_ArrayOfStringArrays** lsClassLists);                            // (out) списки классов

QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsFromClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsClasses                                        // (out) список классов
	, QDAPI_ArrayOfVolumeBasedCommissionRates** rates);                     // (out) ставки комиссии

QDEALERAPI_API int _stdcall QDAPI_AddClassToClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, const char* classCode);                                               // (in) код класса

QDEALERAPI_API int _stdcall QDAPI_SetClassListSettingsToClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayOfVolumeBasedCommissionRates* rates);                      // (in) ставки комиссии

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientTemplateVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateName                                              // (in) наименование шаблона
	, const char* classCode);                                               // (in) код класса

#pragma endregion
#pragma region //=================== ClientSettings -> VolumeBasedCommission ===================

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) наименование шаблона
	, QDAPI_ArrayOfStringArrays** lsClassLists);                            // (out) списки классов

QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsFromClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) наименование шаблона
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsClasses                                        // (out) список классов
	, QDAPI_ArrayOfVolumeBasedCommissionRates** rates);                     // (out) ставки комиссии

QDEALERAPI_API int _stdcall QDAPI_AddClassToClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, const char* classCode);                                               // (in) код класса

QDEALERAPI_API int _stdcall QDAPI_SetClassListSettingsToClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) наименование шаблона
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayOfVolumeBasedCommissionRates* rates);                      // (in) ставки комиссии

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromClientSettingsVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* clientCode                                                // (in) наименование шаблона
	, const char* classCode);                                               // (in) код класса

#pragma endregion
#pragma region //================ Global -> ClassesWithPriceExportForMarketOrders ==============

QDEALERAPI_API int _stdcall QDAPI_GetClassesWithPriceExportForMarketOrdersFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings** lsClasses);                                      // (out) список классов

QDEALERAPI_API int _stdcall QDAPI_SetClassesWithPriceExportForMarketOrdersToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings* lsClasses);                                       // (in) список классов

#pragma endregion
#pragma region //===================== Global -> CommissionSettingsCurrency ====================

QDEALERAPI_API int _stdcall QDAPI_GetCommissionSettingsCurrencyFromGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayClassListForCurrency** lsSettings);                        // (out) список соответствий валют и классов

QDEALERAPI_API int _stdcall QDAPI_SetCommissionSettingsCurrencyToGlobal(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayClassListForCurrency* lsSettings);                         // (in) список соответствий валют и классов

#pragma endregion
#pragma region //======================== Global -> VolumeBasedCommission ======================

QDEALERAPI_API int _stdcall QDAPI_GetClassListsFromGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayOfStringArrays** lsClassLists);                            // (out) списки классов

QDEALERAPI_API int _stdcall QDAPI_GetClassSettingsFromGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* classCode                                                 // (in) код класса
	, QDAPI_ArrayStrings** lsClasses                                        // (out) список классов
	, QDAPI_ArrayOfVolumeBasedCommissionRates** rates);                     // (out) ставки комиссии

QDEALERAPI_API int _stdcall QDAPI_AddClassToGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, const char* classCode);                                               // (in) код класса

QDEALERAPI_API int _stdcall QDAPI_SetClassListSettingsToGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, QDAPI_ArrayStrings* lsClasses                                         // (in) список классов
	, QDAPI_ArrayOfVolumeBasedCommissionRates* rates);                      // (in) ставки комиссии

QDEALERAPI_API int _stdcall QDAPI_RemoveClassSettingsFromGlobalVolumeBasedCommission(
	const char* firmCode                                                    // (in) код фирмы
	, const char* classCode);                                               // (in) код класса

#pragma endregion

#pragma region
//Множества инструментов с зависимыми ценами (Set of Instruments&)
QDEALERAPI_API int _stdcall QDAPI_GetGroupsWithDependentPricesListFromGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	QDAPI_ArrayGroupsWithDependentPrices** lsGroups                         // (out) – список множеств
);

QDEALERAPI_API int _stdcall QDAPI_AddGroupWithDependentPricesToGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	const QDAPI_GroupWithDependentPrices* group                            // (in) – множество [наименование, базовый индикатор]
);

QDEALERAPI_API int _stdcall QDAPI_RemoveGroupWithDependentPricesFromGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	const char* groupCode                                                     // (in) – наименование множества
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	const char* groupCode,                                                    // (in) – наименование множества
	QDAPI_ArrayInstruments** lsInstruments                                  // (out) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentToGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	const char* groupCode,                                                    // (in) – наименование множества
	const QDAPI_Instrument* instrument                                      // (in) -  инструмент
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListToGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	const char* groupCode,                                                    // (in) – наименование множества
	const QDAPI_ArrayInstruments* lsInstruments                             // (in) – список значений
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentFromGroupWithDependentPricesGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	const char* groupCode,                                                    // (in) – код множества
	const char* secCode                                                     // (in) – код инструмента
);

QDEALERAPI_API int _stdcall QDAPI_GetGroupsWithDependentPricesListFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – наименование шаблона
	QDAPI_ArrayGroupsWithDependentPrices** lsGroups                         // (out) – список множеств [наименование, базовый индикатор]
);

QDEALERAPI_API int _stdcall QDAPI_AddGroupWithDependentPricesToMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – наименование шаблона
	const QDAPI_GroupWithDependentPrices* group                            // (in) – множество [множество +базовый индикатор]
);

QDEALERAPI_API int _stdcall QDAPI_RemoveGroupWithDependentPricesFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – наименование шаблона
	const char* groupCode                                                    // (in) – наименование множества
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromGroupWithDependentMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – наименование шаблона
	const char* groupCode,                                                  // (in)  - наименоване множества
	QDAPI_ArrayInstruments** lsInstruments                                 // (out) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentToGroupWithDependentPricesMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – наименование шаблона
	const char* groupCode,                                                  // (in) – наименование множества
	const QDAPI_Instrument* instrument                                     // (in) –инструмент [имя, риск, тренд]
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListToGroupWithDependentPricesMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – наименование шаблона
	const char* groupCode,                                                   // (in) –наименование множества
	const QDAPI_ArrayInstruments* lsInstruments                            // (in) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentFromGroupWithDependentPricesMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – наименование шаблона
	const char* groupCode,                                                   // (in) – наименование множества
	const char* secCode                                                    // (in) – код инструмента
);

//Использовать множества для клиентов, не входящих в шаблон
QDEALERAPI_API int _stdcall QDAPI_GetUseGroupsForNonTemplateClientsFromGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	bool* value                                                            // (out) –значение настройки
);

QDEALERAPI_API int _stdcall QDAPI_SetUseGroupsForNonTemplateClientsToGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	bool value                                                             // (in) – значение настройки
);

//Использовать глобальные множества при расчете маржи
QDEALERAPI_API int _stdcall QDAPI_GetUseGlobalGroupsInMarginCalculationFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – код шаблона
	bool* value                                                            // (out) – значение настройки
);

QDEALERAPI_API int _stdcall QDAPI_SetUseGlobalGroupsInMarginCalculationToMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – код шаблона
	bool value                                                             // (in) – значение
);

//Определение дисконта фьючерса из размера ГО
QDEALERAPI_API int _stdcall QDAPI_GetFuturesDiscountFromCollateralAmountFromGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	bool* value                                                            // (out) – значение настройки
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesDiscountFromCollateralAmountToGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	bool value                                                             // (in) – значение настройки
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesDiscountFromCollateralAmountToMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* tempalteCode,                                              // (in) - код шаблона
	bool value                                                             // (in) – значение 
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesDiscountFromCollateralAmountFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* tempalteCode,                                              // (in) - код шаблона
	bool* value                                                            // (out) – значение 
);


//Клиенты с повышенным уровнем риска
QDEALERAPI_API int _stdcall QDAPI_GetHighRiskLevelClientsFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – код шаблона
	bool* value                                                            // (out) – значение настройки
);

QDEALERAPI_API int _stdcall QDAPI_SetHighRiskLevelClientsToMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) – код шаблона
	bool value                                                             // (in) – значение
);

//Коэффициент для расчета минимальной маржи в схеме МД+
QDEALERAPI_API int _stdcall QDAPI_GetMDPlusMinMarginCalcRateFromGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	double* value                                                          // (out) – значение настройки
);

QDEALERAPI_API int _stdcall QDAPI_SetMDPlusMinMarginCalcRateToGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	double value                                                           // (in) – значение
);


//Инструменты без учета валютного риска
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_ArrayStrings** lsClasses                                         // (out)  - список классов
);

QDEALERAPI_API int _stdcall QDAPI_AddClassToInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* classCode                                                  // (in) – код класса
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* classCode                                                  // (in) – код класса
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                   // (in) – код фирмы
	const char* classCode,                                                  // (in) – код класса
	QDAPI_ArrayStrings** lsInstruments                                      // (out) –список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* classCode,                                                 // (in) – код класса
	const char* secCode                                                    // (in)  - код инструмента
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* classCode,                                                 // (in) – код класса
	QDAPI_ArrayStrings* lsInstruments                                      // (in) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* classCode,                                                 // (in) – код класса
	const char* secCode                                                    // (in) – код инструмента
);

#pragma endregion

#pragma region 
QDEALERAPI_API int _stdcall QDAPI_GetClientMarginSchemeListFromGlobal(
	const char* firmCode                                                   // (in) – код фирмы
	, QDAPI_ArrayClientLag** lsClientLags                                  // (out) список соответствий кодов клиента и схем кредитования
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClientMarginSchemeFromGlobal(
	const char* firmCode                                                   // (in) – код фирмы
	, const char* clientCode                                               // (in) - код клиента
);

QDEALERAPI_API int _stdcall QDAPI_AddClientMarginSchemeToGlobal(
	const char* firmCode                                                   // (in) – код фирмы
	, const char* clientCode                                               // (in) - код клиента
	, QDAPI_ClientLagType lagType                                          // (in) - схема кредитования клиента
);

QDEALERAPI_API int _stdcall QDAPI_SetClientMarginSchemeListToGlobal(
	const char* firmCode                                                   // (in) – код фирмы
	, QDAPI_ArrayClientLag* lsClientLags                                   // (in) список соответствий кодов клиента и схем кредитования
);

QDEALERAPI_API int _stdcall QDAPI_GetChangeFutClientCodesByFirmFromGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* futTrdacc,                                                 // (in) – код класса
	QDAPI_ArrayClientCodeToTrdAcc** lsClientCodeToTrdAcc                   // (out) – список соответствий кодов клинета и торговых счетов
);


QDEALERAPI_API int _stdcall QDAPI_GetCommissionTypeAndSimpleRatesFromClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		QDAPI_CommissionTypeAndRate** commissionTypeAndRate                // (out) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionTypeAndSimpleRatesFromClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	QDAPI_CommissionTypeAndRate** commissionTypeAndRate                // (out) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionTypeAndSimpleRatesToClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		QDAPI_CommissionTypeAndRate* commissionTypeAndRate                 // (in) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionTypeAndSimpleRatesToClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) – код клиента
	QDAPI_CommissionTypeAndRate* commissionTypeAndRate                 // (in) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_GetTPNameFromClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		char** TPName                                                      // (out) - имя тарифного плана
);

QDEALERAPI_API int _stdcall QDAPI_GetTPNameFromClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) – код клиента
	char** TPName                                                      // (out) - имя тарифного плана
);

QDEALERAPI_API int _stdcall QDAPI_SetTPNameToClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		const char* TPName                                                 // (in) - имя тарифного плана
);

QDEALERAPI_API int _stdcall QDAPI_SetTPNameToClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	const char* TPName                                                 // (in) - имя тарифного плана
);

QDEALERAPI_API int _stdcall QDAPI_GetRepoBrokerRateFromClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		double* repoCommissionRate                                         // (out) - ставка комиссии РЕПО в % от объема за каждый день срока сделки
);

QDEALERAPI_API int _stdcall QDAPI_GetRepoBrokerRateFromClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	double* repoCommissionRate                                         // (out) - ставка комиссии РЕПО в % от объема за каждый день срока сделки
);

QDEALERAPI_API int _stdcall QDAPI_SetRepoBrokerRateToClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		double repoCommissionRate                                          // (in) - ставка комиссии РЕПО в % от объема за каждый день срока сделки
);

QDEALERAPI_API int _stdcall QDAPI_SetRepoBrokerRateToClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	double repoCommissionRate                                          // (in) - ставка комиссии РЕПО в % от объема за каждый день срока сделки
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionByClassesFromClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		QDAPI_ArrayClassCommissionType** commissionTypeAndRate             // (out) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionByClassesFromClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	QDAPI_ArrayClassCommissionType** commissionTypeAndRate             // (out) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionByClassesToClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		QDAPI_ArrayClassCommissionType* commissionTypeAndRate              // (in) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionByClassesToClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	QDAPI_ArrayClassCommissionType* commissionTypeAndRate              // (in) - тип и ставки комиссии
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesCommissionFromClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		QDAPI_ArrayBaseAssetCommissionRate** lsBaseAssetCommission         // (out) - список (имя инструмента, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesCommissionFromClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	QDAPI_ArrayBaseAssetCommissionRate** lsBaseAssetCommission         // (out) - список (имя инструмента, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesCommissionToClientTemplate(
		const char* firmCode,                                              // (in) – код фирмы
		const char* templateName,                                          // (in) – код шаблона
		QDAPI_ArrayBaseAssetCommissionRate* lsBaseAssetCommission          // (in) - список (имя инструмента, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesCommissionToClientSettings(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                            // (in) - код клиента
	QDAPI_ArrayBaseAssetCommissionRate* lsBaseAssetCommission          // (in) - список (имя инструмента, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleJumpFromClientSettings(
		const char* firmCode,                                              // (in) – код фирмы
		const char* clientCode,                                            // (in) - код клиента
		int* commissionScaleJump                                           // (out) - «-1» (по умолчанию) – используется значение глобальной настройки.«0» - выключено, используется шкала без пересчета.	«1» – включено, используется шкала с пересчетом.
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleJumpFromClientTemplate(
	const char* firmCode,                                              // (in) – код фирмы
	const char* clientCode,                                          // (in) – код клиента
	int* commissionScaleJump                                           // (out) - «-1» (по умолчанию) – используется значение глобальной настройки.«0» - выключено, используется шкала без пересчета.	«1» – включено, используется шкала с пересчетом.
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleJumpToClientSettings(
		const char* firmCode,                                              // (in) – код фирмы
		const char* clientCode,                                            // (in) - код клиента
		int commissionScaleJump                                            // (in) - «-1» (по умолчанию) – используется значение глобальной настройки.«0» - выключено, используется шкала без пересчета.	«1» – включено, используется шкала с пересчетом.
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleJumpToClientTemplate(
	const char* firmCode,                                              // (in) – код фирмы
	const char* templateName,                                          // (in) – код шаблона
	int commissionScaleJump                                            // (in) - «-1» (по умолчанию) – используется значение глобальной настройки.«0» - выключено, используется шкала без пересчета.	«1» – включено, используется шкала с пересчетом.
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRestrictionsFromClientSettings(
		const char* firmCode,                                              // (in) – код фирмы
		const char* clientCode,                                            // (in) - код клиента
		QDAPI_ScaleCommExParams** minMaxTurnover                           // (out) -Максимальная комиссия, Минимальная комиссия, Минимальный оборот
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRestrictionsFromClientTemplate(
	const char* firmCode,                                              // (in) – код фирмы
	const char* templateName,                                          // (in) – код шаблона
	QDAPI_ScaleCommExParams** minMaxTurnover                           // (out) -Максимальная комиссия, Минимальная комиссия, Минимальный оборот
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRestrictionsToClientSettings(
		const char* firmCode,                                              // (in) – код фирмы
		const char* clientCode,                                            // (in) - код клиента
		QDAPI_ScaleCommExParams* minMaxTurnover                            // (in) -Максимальная комиссия, Минимальная комиссия, Минимальный оборот
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRestrictionsToClientTemplate(
	const char* firmCode,                                              // (in) – код фирмы
	const char* templateName,                                          // (in) – код шаблона
	QDAPI_ScaleCommExParams* minMaxTurnover                            // (in) -Максимальная комиссия, Минимальная комиссия, Минимальный оборот
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRatesFromClientSettings(
		const char* firmCode,                                               // (in) – код фирмы
		const char* clientCode,                                             // (in) - код клиента
		QDAPI_ArrayOfScaleRates** scale                                     // (out) - количество ступеней шкалы и элементы (нижня граница, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRatesFromClientTemplate(
	const char* firmCode,                                              // (in) – код фирмы
	const char* templateName,                                          // (in) – код шаблона
	QDAPI_ArrayOfScaleRates** scale                                    // (out) - количество ступеней шкалы и элементы (нижня граница, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRatesToClientSettings(
		const char* firmCode,                                              // (in) – код фирмы
		const char* clientCode,                                            // (in) - код клиента
		QDAPI_ArrayOfScaleRates* scale                                     // (in) - количество ступеней шкалы и элементы (нижня граница, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRatesToClientTemplate(
	const char* firmCode,                                              // (in) – код фирмы
	const char* templateName,                                          // (in) – код шаблона
	QDAPI_ArrayOfScaleRates* scale                                     // (in) - количество ступеней шкалы и элементы (нижня граница, ставка)
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCommissionScaleFromClientSettings(
		const char* firmCode,                                              // (in) – код фирмы
		const char* clientCode                                             // (in) - код клиента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCommissionScaleFromClientTemplate(
	const char* firmCode,                                              // (in) – код фирмы
	const char* templateName                                           // (in) – код шаблона
);

QDEALERAPI_API int _stdcall QDAPI_GetCommissionByClassesFromGlobal(
		const char* firmCode,                                              // (in) – код фирмы
		QDAPI_ArrayClassCommissionType** commissionTypeAndRate             // (out) - тип коммиссии и ее ставка
);

QDEALERAPI_API int _stdcall QDAPI_SetCommissionByClassesToGlobal(
		const char* firmCode,                                              // (in) – код фирмы
		QDAPI_ArrayClassCommissionType* commissionTypeAndRate              // (in) - тип коммиссии и ее ставка
);

QDEALERAPI_API int _stdcall QDAPI_GetFuturesCommissionFromGlobal(
		const char* firmCode,                                              // (in) – код фирмы
		QDAPI_ArrayBaseAssetCommissionRate** lsBaseAssetCommission         // (out) - список пар базовый (актив; ставка комиссии)
);

QDEALERAPI_API int _stdcall QDAPI_SetFuturesCommissionToGlobal(
		const char* firmCode,                                              // (in) – код фирмы
		QDAPI_ArrayBaseAssetCommissionRate* lsBaseAssetCommission          // (in) - список пар базовый (актив; ставка комиссии)
);

QDEALERAPI_API int _stdcall QDAPI_GetSecurityWeightFromGlobal(
	const char* firmCode,                                                  // (in) – код фирмы 
	QDAPI_SecsWithWeightAndRestrictionsList** lsSec                        // (out) - список коэффицентов по бумагам
);

QDEALERAPI_API int _stdcall QDAPI_GetSecurityWeightFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithWeightAndRestrictionsList** lsSec                        // (out) - список коэффицентов по бумагам
);

QDEALERAPI_API int _stdcall QDAPI_GetSecurityWeightFromClientSettings(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithWeightAndRestrictionsList** lsSec                        // (out) - список коэффицентов по бумагам
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithCoefficientsFromGlobalSecurityWeight(
	const char* firmCode,                                                   // (in) – код фирмы
	QDAPI_SecsWithCoeffsList** lsSec                                        // (out) - список инструментов со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithCoefficientsFromMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithCoeffsList** lsSec                                       // (out) - список инструментов со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithCoefficientsFromClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithCoeffsList** lsSec                                       // (out) - список инструментов со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithPositionRestrictionFromGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecsWithRestrictionsList** lsSec                                 // (out) - список инструментов со значениями ограничений на размер позиции 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithPositionRestrictionFromMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithRestrictionsList** lsSec                                 // (out) - список инструментов со значениями ограничений на размер позиции 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithPositionRestrictionFromClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithRestrictionsList** lsSec                                 // (out) - список инструментов со значениями ограничений на размер позиции 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecsWithVarianceList** lsSec                                     // (out) -список инструментов со значениями максимального отклонения дисконта РЕПО 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithVarianceList** lsSec                                     // (out) -список инструментов со значениями максимального отклонения дисконта РЕПО 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListWithRepoDiscountRestrictionFromClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithVarianceList** lsSec                                     // (out) -список инструментов со значениями максимального отклонения дисконта РЕПО 
);

QDEALERAPI_API int _stdcall QDAPI_SetSecurityWeightToGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecsWithWeightAndRestrictionsList* lsSec                         // (in) - список коэффицентов по бумагам
);

QDEALERAPI_API int _stdcall QDAPI_SetSecurityWeightToMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithWeightAndRestrictionsList* lsSec                         // (in) - список коэффицентов по бумагам
);

QDEALERAPI_API int _stdcall QDAPI_SetSecurityWeightToClientSettings(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithWeightAndRestrictionsList* lsSec                         // (in) - список коэффицентов по бумагам
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentCoefficientsToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecWithCoeffs* sec                                               // (in) - инструмент со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentCoefficientsToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecWithCoeffs* sec                                               // (in) - инструмент со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentCoefficientsToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecWithCoeffs* sec                                               // (in) - инструмент со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentPositionRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecWithRestrictions* sec                                         // (in) - коэффиценты по бумаге
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentPositionRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecWithRestrictions* sec                                         // (in) - коэффиценты по бумаге
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentPositionRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecWithRestrictions* sec                                         // (in) - коэффиценты по бумаге
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentRepoDiscountRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecWithVariance* sec                                             // (in) - максимальное отклонения дисконта РЕПО для бумаги
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentRepoDiscountRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecWithVariance* sec                                             // (in) - максимальное отклонения дисконта РЕПО для бумаги
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentRepoDiscountRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecWithVariance* sec                                             // (in) - максимальное отклонения дисконта РЕПО для бумаги
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithCoefficientsToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecsWithCoeffsList* lsSec                                        // (in) - список инструментов со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithCoefficientsToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithCoeffsList* lsSec                                        // (in) - список инструментов со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithCoefficientsToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithCoeffsList* lsSec                                        // (in) - список инструментов со значеними дисконтирующих коэфицентов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithPositionRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecsWithRestrictionsList* lsSec                                  // (in) - список инструментов со значениями ограничений на размер позиции 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithPositionRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithRestrictionsList* lsSec                                  // (in) - список инструментов со значениями ограничений на размер позиции 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithPositionRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithRestrictionsList* lsSec                                  // (in) - список инструментов со значениями ограничений на размер позиции 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithRepoDiscountRestrictionToGlobalSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	QDAPI_SecsWithVarianceList* lsSec                                      // (in) -список инструментов со значениями максимального отклонения дисконта РЕПО 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithRepoDiscountRestrictionToMarginTemplateSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithVarianceList* lsSec                                      // (in) -список инструментов со значениями максимального отклонения дисконта РЕПО 
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListWithRepoDiscountRestrictionToClientSettingsSecurityWeight(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	QDAPI_SecsWithVarianceList* lsSec                                      // (in) -список инструментов со значениями максимального отклонения дисконта РЕПО 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityWeightForInstrumentFromGlobal(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* secCode                                                    // (in) – код инструмента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityWeightForInstrumentFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind,                                                   // (in) - вид лимита
	const char* secCode                                                    // (in) – код инструмента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSecurityWeightForInstrumentFromClientSettings(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind,                                                   // (in) - вид лимита
	const char* secCode                                                    // (in) – код инструмента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSecurityWeightFromGlobal(
	const char* firmCode                                                   // (in) – код фирмы
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSecurityWeightFromMarginTemplate(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* templateCode,                                              // (in) - код шаблона
	const int limitKind                                                    // (in) - вид лимита
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllSecurityWeightFromClientSettings(
	const char* firmCode,                                                  // (in) – код фирмы
	const char* clientCode,                                                // (in) - код клиента
	const int limitKind                                                    // (in) - вид лимита
);
#pragma endregion

#pragma region
QDEALERAPI_API int _stdcall QDAPI_GetProhibitedCPAndSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency** lsProhibitedCPSC      // (out) - список запретов операций с контрагентом по валюте расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedSettlementCurrency** lsProhibitedSC             // (out) - список запретов операций по валюте расчетов для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_SetProhibitedCPAndSettlementCurrencyToGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency* lsProhibitedCPSC       // (in) - список запретов операций с контрагентом по валюте расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedSettlementCurrency* lsProhibitedSC              // (in) - список запретов операций по валюте расчетов для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, const char* cP                                                       // (in) - код контрагента
);

QDEALERAPI_API int _stdcall QDAPI_GetProhibitedCPAndSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency** lsProhibitedCPSC      // (out) - список запретов операций с контрагентом по валюте расчетов 
); 

QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedSettlementCurrency** lsProhibitedSC             // (out) - список запретов операций по валюте расчетов для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_SetProhibitedCPAndSettlementCurrencyToRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedCPAndSettlementCurrency* lsProhibitedCPSC       // (in) - список запретов операций с контрагентом по валюте расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToProhibitedCPAndSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayProhibitedSettlementCurrency* lsProhibitedSC              // (in) - список запретов операций по валюте расчетов для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveProhibitedCPAndSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromProhibitedCPAndSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_GetRestrictREPOWithCPBasedOnTermFromGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm** lsRestrictRepoCP          // (out) - список ограничений операций РЕПО c контрагентом по сроку сделки 
);

QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOBasedOnTerm** lsRestrictRepo                  // (out) - список ограничений операций РЕПО по сроку сделки для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictREPOWithCPBasedOnTermToGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm* lsRestrictRepoCP           // (in) - список ограничений операций РЕПО c контрагентом по сроку сделки 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOBasedOnTerm* lsRestrictRepo                   // (in) - список ограничений операций РЕПО по сроку сделки для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_GetRestrictREPOWithCPBasedOnTermFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm** lsRestrictRepoCP          // (out) - список ограничений операций РЕПО c контрагентом по сроку сделки 
);
QDEALERAPI_API int _stdcall QDAPI_GetCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOBasedOnTerm** lsRestrictRepo                  // (out) - список ограничений операций РЕПО по сроку сделки для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictREPOWithCPBasedOnTermToRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOWithCPBasedOnTerm* lsRestrictRepoCP           // (in) - список ограничений операций РЕПО c контрагентом по сроку сделки 
);

QDEALERAPI_API int _stdcall QDAPI_SetCPSettingsToRestrictREPOWithCPBasedOnTermRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictREPOBasedOnTerm* lsRestrictRepo                   // (in) - список ограничений операций РЕПО по сроку сделки для контрагента
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictREPOWithCPBasedOnTermFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_RemoveCPSettingsFromRestrictREPOWithCPBasedOnTermRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* cP                                                       // (in) - код контрагента
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
); 

QDEALERAPI_API int _stdcall QDAPI_GetRestrictMaxValueForSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency** lsRestrictMVSC    // (out) - список ограничений максимального объема заявки в валюте расчетов 
); 

QDEALERAPI_API int _stdcall QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* settlementCurrency                                       // (in) - валюта расчетов
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValue** lsRestrictMV                           // (out) - список ограничений максимального объема заявки для валюты расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictMaxValueForSettlementCurrencyToGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency* lsRestrictMVSC     // (in) - список ограничений максимального объема заявки в валюте расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* settlementCurrency                                       // (in) - валюта расчетов
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValue* lsRestrictMV                            // (in) - список ограничений максимального объема заявки для валюты расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
); 

QDEALERAPI_API int _stdcall QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyGlobal(
	const char* firmCode                                                   // (in) - код фирмы
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, const char* settlementCurrency                                       // (in) - валюта расчетов
);

QDEALERAPI_API int _stdcall QDAPI_GetRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency** lsRestrictMVSC    // (out) - список ограничений максимального объема заявки в валюте расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_GetSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* settlementCurrency                                       // (in) - валюта расчетов
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValue** lsRestrictMV                           // (out) - список ограничений максимального объема заявки для валюты расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_SetRestrictMaxValueForSettlementCurrencyToRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValueForSettlementCurrency* lsRestrictMVSC     // (in) - список ограничений максимального объема заявки в валюте расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_SetSCSettingsToRestrictMaxValueForSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, const char* settlementCurrency                                       // (in) - валюта расчетов
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, QDAPI_ArrayRestrictMaxValue* lsRestrictMV                            // (in) - список ограничений максимального объема заявки для валюты расчетов 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveRestrictMaxValueForSettlementCurrencyFromRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_RemoveSCSettingsFromRestrictMaxValueForSettlementCurrencyRestrictionTemplate(
	const char* firmCode                                                   // (in) - код фирмы
	, const char* templateCode                                             // (in) - код шаблона
	, QDAPI_SettingsScope settingsScope                                    // (in) - тип настроек
	, const char* settlementCurrency                                       // (in) - валюта расчетов
);
#pragma endregion

#pragma region
//QDealerAPI 1.12 (шаблонный и клиентский  вариант настройки)

//шаблонный вариант
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* templateName                                                  // (in) – код шаблона
	, QDAPI_ArrayStrings** lsClasses);                                            // (out) - список классов

QDEALERAPI_API int _stdcall QDAPI_AddClassToInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* templateName                                                  // (in) – код шаблона
	, const char* classCode);                                                   // (in) – код класса

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* templateName                                                  // (in) – код шаблона
	, const char* classCode);                                                   // (in) – код класса

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* templateName                                                  // (in) – код шаблона
	, const char* classCode                                                     // (in) – код класса
	, QDAPI_ArrayStrings** lsInstruments);                                        // (out) –список инструментов

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* templateName                                                  // (in) – код шаблона
	, const char* classCode                                                     // (in) – код класса
	, const char* secCode);                                                     // (in)  - код инструмента

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* templateName                                                  // (in) – код шаблона
	, const char* classCode                                                     // (in) – код класса
	, const QDAPI_ArrayStrings* lsInstruments);                                   // (in) – список инструментов

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskMarginTemplate(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* templateName                                                  // (in) – код шаблона
	, const char* classCode                                                     // (in) – код класса
	, const char* secCode);                                                     // (in) – код инструмента

//клиентский вариант

QDEALERAPI_API int _stdcall QDAPI_GetClassListFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* clientCode                                                    // (in) – код клиента
	, QDAPI_ArrayStrings** lsClasses);                                            // (out)  - список классов

QDEALERAPI_API int _stdcall QDAPI_AddClassToInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* clientCode                                                    // (in) – код клиента
	, const char* classCode);                                                   // (in) – код класса

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* clientCode                                                    // (in) – код клиента
	, const char* classCode);                                                   // (in) – код класса

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* clientCode                                                    // (in) – код клиента
	, const char* classCode                                                     // (in) – код класса
	, QDAPI_ArrayStrings** lsInstruments);                                        // (out) –список инструментов

QDEALERAPI_API int _stdcall QDAPI_AddInstrumentForClassToInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* clientCode                                                    // (in) – код клиента
	, const char* classCode                                                     // (in) – код класса
	, const char* secCode);                                                     // (in)  - код инструмента

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* clientCode                                                    // (in) – код клиента
	, const char* classCode                                                     // (in) – код класса
	, const QDAPI_ArrayStrings* lsInstruments);                                   // (in) – список инструментов

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentForClassFromInstrumentsWithoutCurrencyRiskClientSettings(
	const char* firmCode                                                        // (in) – код фирмы
	, const char* clientCode                                                    // (in) – код клиента
	, const char* classCode                                                     // (in) – код класса
	, const char* secCode);                                                     // (in) – код инструмента

#pragma endregion

#pragma region teriffPlanes
// Получение списка тарифных планов :
QDEALERAPI_API int _stdcall QDAPI_GetTPList(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_ArrayStrings** lsTarifPlans                                             // (out)- список тарифных планов
);

// Получение настроек тарифного плана :
QDEALERAPI_API int _stdcall QDAPI_GetTPSettings(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* tPName,                                                         // (in) – имя тарифного плана
	QDAPI_ArrayClassGroups** lsClassGroups                                         // (out) – группы классов с параметрами
);

// Удаление тарифного плана :
QDEALERAPI_API int _stdcall QDAPI_RemoveTPSettings(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* tPName                                                          // (in) – имя тарифного плана
);

// Перезапись настроек или добавление тарифного плана :
QDEALERAPI_API int _stdcall QDAPI_SetTPSettings(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* tPName,                                                         // (in) – имя тарифного плана
	QDAPI_ArrayClassGroups* lsClassGroups                                          // (in) – группы классов с параметрами
);

#pragma endregion teriffPlanes

#pragma region BrokerCommission
//Для работы с параметром «Использовать шкалу комиссии»:
QDEALERAPI_API int _stdcall QDAPI_GetUseCommissionScaleFromGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	bool* useCommissionScale);                                                  // (out) -значение параметра

QDEALERAPI_API int _stdcall QDAPI_SetUseCommissionScaleToGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	bool useCommissionScale);                                                   // (in) -значение параметра

//Для работы с параметром «Шкала комиссии с пересчетом на границе»:
QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleJumpFromGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	bool* useCommissionScaleJump);                                              // (out) -значение параметра

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleJumpToGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	bool useCommissionScaleJump);                                               // (in) -значение параметра

//Для работы с параметрами «Максимальная комиссия», «Минимальная комиссия» и «Минимальный оборот» :
QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRestrictionsFromGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_ScaleCommExParams** minMaxTurnover);                                  // (out) -Максимальная комиссия, Минимальная комиссия, Минимальный оборот

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRestrictionsToGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_ScaleCommExParams* minMaxTurnover);                                   // (in) -Максимальная комиссия, Минимальная комиссия, Минимальный оборот

//Для работы со ставками шкалы комиссии(параметры «Оборот»(в редакторе БРЛ «С суммы») и «Ставка»(в редакторе БРЛ «Размер комиссии»)):
QDEALERAPI_API int _stdcall QDAPI_GetCommissionScaleRatesFromGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_ArrayOfScaleRates** lsScalesAndRates);                                // (out) – количество ступеней шкалы и элементы (нижня гнаница, ставка)

QDEALERAPI_API int _stdcall QDAPI_SetCommissionScaleRatesToGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_ArrayOfScaleRates* lsScalesAndRates);                                 // (in) – количество ступеней шкалы и элементы (нижня гнаница, ставка)

QDEALERAPI_API int _stdcall QDAPI_RemoveCommissionScaleFromGlobal(
	const char* firmCode);                                                      // (in) – код фирмы

#pragma endregion BrokerCommission

#pragma region ProhibitREPOByFirstPartSideAndTerm
// Разрешенные для торговли инструменты
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromSecurityAllowedRestrictionTemplate(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* templateCode,                                                   // (in) – код шаблона
	QDAPI_ArrayStrings** lsInstruments                                          // (out) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_RemoveInstrumentListFromSecurityAllowedRestrictionTemplate(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* templateCode,                                                   // (in) – код шаблона
	QDAPI_ArrayStrings* lsInstruments                                           // (in) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromSecurityAllowedRestrictionTemplate(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* templateCode                                                    // (in) – код шаблона
);

//Запрещенные для торговли инструменты

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromSecurityRestrictedRestrictionTemplate(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* templateCode,                                                   // (in) – код шаблона
	QDAPI_SettingsScope settingsScope                                           // (in) тип настроек
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromSecurityRestrictedGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_SettingsScope settingsScope                                           // (in) тип настроек
);

//Запрет сделок РЕПО по направлению первой части и сроку РЕПО
QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate(
	const char* firmCode,                                                       // (in) – код фирмы
	const char* templateCode,                                                   // (in) – код шаблон
	QDAPI_SettingsScope settingsScope,                                          // (in) тип настроек
	QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm** lsProhibitedREPOInstruments // (out) – список инструментов с направлениями, максимальными сроками 
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListFromProhibitREPOByFirstPartSideAndTermGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_SettingsScope settingsScope,                                          // (in) тип настроек
	QDAPI_ArrayProhibitREPOByFirstPartSideAndTerm** lsProhibitedREPOInstruments // (out) – список инструментов с направлениями, максимальными сроками 
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermRestrictionTemplate(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_SettingsScope settingsScope,                                          // (in) тип настроек
	const char* templateCode                                                    // (in) – код шаблона
);

QDEALERAPI_API int _stdcall QDAPI_RemoveAllFromProhibitREPOByFirstPartSideAndTermGlobal(
	const char* firmCode,                                                       // (in) – код фирмы
	QDAPI_SettingsScope settingsScope                                           // (in) тип настроек
);
#pragma endregion ProhibitREPOByFirstPartSideAndTerm

#pragma region RestrictOpenSecurity
// Глобальная настройка
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  – код фирмы
	QDAPI_ArrayStrings** lsClassCodes                                           // (out) - список классов
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* classCode,                                                      // (in)  – код класса
	QDAPI_ArrayStrings** lsInstruments                                          // (out) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* classCode,                                                      // (in)  – код класса
	QDAPI_ArrayStrings* lsInstruments                                           // (in)  – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictOpenSecurityGlobal(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* classCode                                                       // (in)  – код класса
);

//Настройка в шаблонах «По комиссии»
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* templateName,                                                   // (in)  – имя шаблона по комиссии
	QDAPI_ArrayStrings** lsClassCodes                                           // (out) - список классов
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* templateName,                                                   // (in)  – имя шаблона по комиссии
	const char* classCode,                                                      // (in)  – код класса
	QDAPI_ArrayStrings** lsInstruments                                          // (out) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* templateName,                                                   // (in)  – имя шаблона по комиссии
	const char* classCode,                                                      // (in)  – код класса
	QDAPI_ArrayStrings* lsInstruments                                           // (in)  – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictOpenSecurityClientTemplate(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* templateName,                                                   // (in)  – имя шаблона по комиссии
	const char* classCode                                                       // (in)  – код класса
);

// Настройка на код клиента или префикс кода клиента
QDEALERAPI_API int _stdcall QDAPI_GetClassListFromRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* clientCode,                                                     // (in)  – код клиента
	QDAPI_ArrayStrings** lsClassCodes                                           // (out) - список классов
);

QDEALERAPI_API int _stdcall QDAPI_GetInstrumentListForClassFromRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* clientCode,                                                     // (in)  – код клиента
	const char* classCode,                                                      // (in)  – код класса
	QDAPI_ArrayStrings** lsInstruments                                          // (out) – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_SetInstrumentListForClassToRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* clientCode,                                                     // (in)  – код клиента
	const char* classCode,                                                      // (in)  – код класса
	QDAPI_ArrayStrings* lsInstruments                                           // (in)  – список инструментов
);

QDEALERAPI_API int _stdcall QDAPI_RemoveClassFromRestrictOpenSecurityClientSettings(
	const char* firmCode,                                                       // (in)  – код фирмы
	const char* clientCode,                                                     // (in)  – код клиента
	const char* classCode                                                       // (in)  – код класса
);

#pragma endregion RestrictOpenSecurity

#pragma region ComplexInstruments

QDEALERAPI_API int _stdcall QDAPI_GetComplexInstrumentsAccessControlFromGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	bool* value);                                                               // (out) - значение настройки

QDEALERAPI_API int _stdcall QDAPI_SetComplexInstrumentsAccessControlToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	bool value);                                                                // (out) - значение настройки

QDEALERAPI_API int _stdcall QDAPI_GetComplexFIApprovedClientsFromGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	const char* clientCode,                                                     // (in) - код клиента, если задан, то вернется список из 1 
	                                                                            //        записи с разрешениями для данного клиента, если nullptr, то полный список
	QDAPI_ArrayClientFIApproves** lsApproves);                                  // (out) - список разрешений на клиентов/одна запись для заданного клиента

QDEALERAPI_API int _stdcall QDAPI_AddComplexFIApprovedClientsToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayClientFIApproves* lsApproves);                                   // (in) - список устанавливаемых разрешений

//данная функция перезапишет вся настройку
QDEALERAPI_API int _stdcall QDAPI_SetComplexFIApprovedClientsToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayClientFIApproves* lsApproves);                                   // (in) - список устанавливаемых разрешений 

QDEALERAPI_API int _stdcall QDAPI_RemoveComplexFIApprovedClientsFromGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	const char* clientCode);                                                    // (in) - код клиента

QDEALERAPI_API int _stdcall QDAPI_GetQualifiedInvestorsSignFromRestrictionTemplate(
	const char* firmCode,                                                       // (in) - код фирмы
	const char* templateCode,                                                   // (in) - код шаблона
	bool* value);                                                               // (out) - значение настройки

QDEALERAPI_API int _stdcall QDAPI_SetQualifiedInvestorsSignToRestrictionTemplate(
	const char* firmCode,                                                       // (in) - код фирмы
	const char* templateCode,                                                   // (in) - код шаблона
	bool value);                                                                // (in) - значение настройки

QDEALERAPI_API int _stdcall QDAPI_GetAccessToComplexInstrumentsFromRestrictionTemplate(
	const char* firmCode,                                                       // (in) - код фирмы
	const char* templateCode,                                                   // (in) -  код шаблона
	QDAPI_ArrayStrings** lsApproves);                                           // (out) - список разрешений

QDEALERAPI_API int _stdcall QDAPI_SetAccessToComplexInstrumentsToRestrictionTemplate(
	const char* firmCode,                                                       // (in) - код фирмы
	const char* templateCode,                                                   // (in) - код шаблона
	QDAPI_ArrayStrings* lsApproves);                                            // (in)  -список разрешений

QDEALERAPI_API int _stdcall QDAPI_GetComplexInstrumentsFromGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	const char* complexityType,                                                 // (in) - тип сложности, может быть nullptr, тогда возвращается список всех инструментов, 
	                                                                            //        иначе только настройка для данного типа сложности
	QDAPI_ArrayComplexInstruments** lsComplexSecs);                             // (out) - список cложных инструментов по классам

QDEALERAPI_API int _stdcall QDAPI_AddComplexInstrumentsToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayComplexInstruments* lsComplexSecs);                              // (in) - список сложных инструментов по классам

// Перезапишет настройку целиком
QDEALERAPI_API int _stdcall QDAPI_SetComplexInstrumentsToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayComplexInstruments* lsComplexSecs);                              // (in) - список сложных инструментов по классам

QDEALERAPI_API int _stdcall QDAPI_RemoveComplexInstrumentsFromGlobal(
	const char* firmCode,                                                       // (in) -  код фирмы
	const char* complexityType);                                                // (in) - тип сложности


QDEALERAPI_API int _stdcall QDAPI_GetClientCvalSignFromGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	bool* value);                                                               // (out) -значение настройки

QDEALERAPI_API int _stdcall QDAPI_SetClientCvalSignToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	bool value);                                                                // (out) - значение настройки

QDEALERAPI_API int _stdcall QDAPI_GetClientCvalListFromGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayStrings** lsClients);                                            // (out) - список инвесторов которые имеют квалификацию противоположную 
	                                                                            // глобально заданной по умолчанию

QDEALERAPI_API int _stdcall QDAPI_SetClientCvalListToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayStrings* lsClients);                                             // (out) - список инвесторов которые имеют квалификацию противоположную 
	                                                                            // глобально заданной по умолчанию

QDEALERAPI_API int _stdcall QDAPI_GetComplexInstrumentsTypesWithoutRestrictionsFromGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayStrings** instrumentsTypes);                                     // (out) - список типов инструментов без ограничений для неквалифицированных инвесторов

QDEALERAPI_API int _stdcall QDAPI_SetComplexInstrumentsTypesWithoutRestrictionsToGlobal(
	const char* firmCode,                                                       // (in) - код фирмы
	QDAPI_ArrayStrings* instrumentsTypes);                                      // (in) - список типов инструментов без ограничений для неквалифицированных инвесторов

QDEALERAPI_API int _stdcall QDAPI_RemoveComplexInstrumentsTypesWithoutRestrictionsFromGlobal(
	const char* firmCode);                                                      // (in) - код фирмы



#pragma endregion ComplexInstruments

#pragma region RestrictionTemplate -> IncludeClientsWithLeverage
// Получение списка значений плеч из настройки «Включать в шаблон клиентов со значением плеча» в конкретном шаблоне «По ограничениям».
// Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// Если значение плеча не задано – возвращается пустой список.
QDEALERAPI_API int _stdcall QDAPI_GetIncludeClientsWithLeverageFromRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона «По плечу»
	, QDAPI_ArrayDoubleNumbers** lsLeverages);                              // (out) настройки плеча

// Задание списка значений плеч в настройке «Включать в шаблон клиентов со значением плеча» в конкретном шаблоне «По ограничениям».
// Если шаблон не существует – возвращается ошибка QDAPI_ERROR_TEMPLATE_NOT_FOUND.
// При попытке задания плеча, совпадающего со значением в другом шаблоне того же типа, возвращается ошибка QDAPI_ERROR_DATA_ALREADY_EXIST. 
// Функция также реализует функционал удаления настройки, для чего необходимо задать пустой список.
QDEALERAPI_API int _stdcall QDAPI_SetIncludeClientsWithLeverageToRestrictionTemplate(
	const char* firmCode                                                    // (in) код фирмы
	, const char* templateCode                                              // (in) код шаблона «По плечу»
	, const QDAPI_ArrayDoubleNumbers* lsLeverages);                         // (in) настройки плеча
#pragma endregion

#pragma endregion RestrictionTemplate -> IncludeClientsWithLeverage
#endif // QDEALERAPI_H