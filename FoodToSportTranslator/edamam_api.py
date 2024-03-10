import requests


class PartialFoodData:
    def __init__(self, name: str, recipe:str, calories: int, health: [], diet: []):
        self.name = name
        self.recipe = recipe
        self.calories = calories
        self.health = health
        self.diet = diet


class EdamamApi:
    def __init__(self):
        self.key = "03d0b80511a17b6696737286bdf62745"
        self.app_id = "d208c114"
        self.base = "https://api.edamam.com/api"

    async def get_nutrition_info(self, food_name: str, quantity: int, measure: str) -> PartialFoodData:

        # API parameters
        params = {
            "app_id": self.app_id,
            "app_key": self.key,
            "ingr": f"{quantity} {measure} {food_name}"
        }

        try:
            response = requests.get(f"{self.base}/nutrition-data", params=params)
            data = response.json()
            if response.status_code == 200:
                return PartialFoodData(food_name, data["uri"], data["calories"], data["healthLabels"], data["dietLabels"])

            return None
        except requests.exceptions.RequestException as e:
            print("Error fetching data:", e)
            return None
