from fastapi import FastAPI, APIRouter
from starlette import status
from starlette.responses import HTMLResponse, JSONResponse
import secrets
import json
import os

# Get the current working directory
current_directory = os.getcwd()

# List files in the current directory
files_in_directory = os.listdir(current_directory)

# Print the list of files
print("Files in the current directory:")
for file in files_in_directory:
    print(file)


from ninja_api import NinjaApi
from edamam_api import EdamamApi


app = FastAPI()
edm = EdamamApi()
ninja = NinjaApi()
global CSRF_TOKENS_STORE
CSRF_TOKENS_STORE = []


@app.get("/")
async def root():
    response = {
        "message": "Welcome to the Nutrition and Sports API",
        "endpoints": {
            "GET /calculation/form": "Get the form for the calculation",
            "GET /calculation/result": "Get the result of the calculation",
            "GET /calculation/result/raw": "Get the raw result of the calculation",
            "GET /security/csrf": "Get the CSRF token",
            "GET /": "Welcome message and endpoints list",
            "GET /docs": "API documentation",
        }
    }

    return JSONResponse(content=response, status_code=status.HTTP_200_OK)


def bad_request(data: str) -> str:
    with open("bad_request.html", "r") as f:
        bad_request = f.read()
    bad_request = bad_request.replace("$MESSAGE", data)
    return bad_request


def activity_not_found() -> str:
    with open("activities_not_found.html", "r") as f:
        not_found = f.read()
    return not_found


def forbidden() -> str:
    with open("forbidden.html", "r") as f:
        forbidden = f.read()
    return forbidden


def generate_csrf_token():
    token = secrets.token_hex(32)
    CSRF_TOKENS_STORE.append(token)
    return token


security_router = APIRouter()


@security_router.get("/security/csrf")
async def meal_form():
    global CSRF_TOKENS_STORE
    csrf_token = generate_csrf_token()
    with open("csrf_token.html", "r") as f:
        CSRF = f.read()
    CSRF = CSRF.replace("$CSRF_TOKEN", csrf_token)
    return HTMLResponse(content=CSRF, status_code=200)


@security_router.get("/security/csrf/raw")
async def meal_form():
    global CSRF_TOKENS_STORE
    csrf_token = generate_csrf_token()
    csrf_json = {
        "csrf": csrf_token
    }
    return JSONResponse(content=csrf_json, status_code=200)


class ResponseActivity:
    def __init__(self, name: str, calories_per_hour, calories):
        self.name = name
        self.minutes_of_training = int(60 * calories / calories_per_hour)
        self.calories_per_hour = calories_per_hour


async def calculations(name: str, quantity: int, unit: str, activity_name: str):
    if quantity < 0:
        return False, HTMLResponse(content=bad_request("Invalid quantity"), status_code=status.HTTP_400_BAD_REQUEST)

    if name is None or name == "" or unit is None or unit == "" or activity_name is None or activity_name == "":
        return False, HTMLResponse(content=bad_request("Name, unit and activity cannot be empty"),
                                   status_code=status.HTTP_400_BAD_REQUEST)

    food = await edm.get_nutrition_info(name, quantity, unit)
    sports = await ninja.get_calculations(activity_name)

    if food is None:
        return False, HTMLResponse(content=bad_request("Invalid food or unit."), status_code=status.HTTP_400_BAD_REQUEST)

    if len(sports) == 0:
        return False, HTMLResponse(content=activity_not_found(), status_code=status.HTTP_404_NOT_FOUND)

    response_activities = []

    for activity in sports:
        response_activities.append(ResponseActivity(activity.name, activity.calories_per_hour, food.calories))

    response = {
        "name": name,
        "quantity": quantity,
        "unit": unit,
        "calories": food.calories,
        "health": food.health,
        "diet": food.diet,
        "recipeUrl": food.recipe,

        "activityName": activity_name,
        "sports": response_activities
    }

    return True, response


calculation_router = APIRouter()


@calculation_router.get("/calculation/form")
async def meal_form():
    global CSRF_TOKENS_STORE
    csrf_token = generate_csrf_token()
    CSRF_TOKENS_STORE.append(csrf_token)
    with open("form.html", "r") as f:
        html_content = f.read()

    html_content = html_content.replace("$CSRF_TOKEN", csrf_token)

    return HTMLResponse(content=html_content, status_code=200)


@calculation_router.get("/calculation/result/raw")
async def meal_results(name: str = "rice",
                       quantity: int = 1,
                       unit: str = "cup",
                       activity: str = "skiing",
                       csrf: str = ""):
    global CSRF_TOKENS_STORE

    if csrf not in CSRF_TOKENS_STORE:
        return HTMLResponse(content=forbidden(), status_code=status.HTTP_403_FORBIDDEN)

    CSRF_TOKENS_STORE.remove(csrf)

    _, response = await calculations(name, quantity, unit, activity)
    return response


@calculation_router.get("/calculation/result")
async def meal_results(name: str = "rice",
                       quantity: int = 1,
                       unit: str = "cup",
                       activity: str = "skiing",
                       csrf: str = ""):
    global CSRF_TOKENS_STORE

    if csrf not in CSRF_TOKENS_STORE:
        return HTMLResponse(content=forbidden(), status_code=status.HTTP_403_FORBIDDEN)

    CSRF_TOKENS_STORE.remove(csrf)

    result, response = await calculations(name, quantity, unit, activity)

    if not result:
        return response

    with open("results.html", "r") as template_file:
        html_template = template_file.read()

    # Replace placeholders with JSON values
    html_output = html_template.replace("$NAME", response["name"])
    html_output = html_output.replace("$QUANTITY", str(response["quantity"]))
    html_output = html_output.replace("$UNIT", response["unit"])
    html_output = html_output.replace("$CALORIES", str(response["calories"]))
    html_output = html_output.replace("$RECIPE_URL", response["recipeUrl"])
    html_output = html_output.replace("$ACTIVITY_NAME", response["activityName"])

    # Replace health labels dynamically
    health_labels = "\n".join([f"    <li>{label.replace('_', ' ').capitalize()}</li>" for label in response["health"]])
    html_output = html_output.replace("<!-- $HEALTH_LABELS will be replaced dynamically -->", health_labels)

    # Replace diet labels dynamically
    diet_labels = "\n".join([f"    <li>{label.replace('_', ' ').capitalize()}</li>" for label in response["diet"]])
    html_output = html_output.replace("<!-- $DIET_LABELS will be replaced dynamically -->", diet_labels)

    # Replace sports details dynamically
    sports_details = ""
    for sport in response["sports"]:
        sports_details += f'''
        <li>
          <strong>Name:</strong> {sport.name}<br>
          <strong>Minutes of Training:</strong> {sport.minutes_of_training}<br>
          <strong>Calories per Hour:</strong> {sport.calories_per_hour}
        </li>
    '''
    html_output = html_output.replace("<!-- $SPORTS_DETAILS will be replaced dynamically -->", sports_details)

    return HTMLResponse(content=html_output, status_code=status.HTTP_200_OK)


app.include_router(security_router, tags=["Security"])
app.include_router(calculation_router, tags=["Calculations"])
