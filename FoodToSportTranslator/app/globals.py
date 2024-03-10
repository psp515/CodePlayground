MOCK_RESPONSES = False
AUTHORIZED_KEYS_FILE_PATH = "authorized_keys"

DELIMITER = ","

ERROR_MESSAGE = "error_message"
ERROR_WRONG_ARGS_COUNT = "Wrong arguments count"
ERROR_UNAUTHORIZED = "Invalid API key, if you don't own one contact the administrator via email: admin@workeatout.com"

NUTRITIONIX_DELIMITER = ","
NUTRITIONIX_EXERCISE_PREFIX = " 1 min "
NUTRITIONIX_AUTH_HEADERS = {"x-app-id": NUTRITIONIX_APP_ID, "x-app-key": NUTRITIONIX_APP_KEY, "x-remote-user-id": "0"}
NUTRITIONIX_EXERCISE_URL = "https://trackapi.nutritionix.com/v2/natural/exercise"

EDAMAM_DELIMITER = " and "
EDAMAM_GRAMS_PER_SERVING = 100
EDAMAM_FOOD_AUTH_PARAMS = {"app_id": "d208c114", "app_key": "03d0b80511a17b6696737286bdf62745"}
EDAMAM_FOOD_PARAMS = {"nutrition-type": "logging"} | EDAMAM_FOOD_AUTH_PARAMS
EDAMAM_FOOD_PARSER_URL = "https://api.edamam.com/api/food-database/parser"