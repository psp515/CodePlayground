import requests


class SportData:
    def __init__(self, name, calories_per_hour, duration_minutes, total_calories):
        self.name = name
        self.calories_per_hour = calories_per_hour
        self.duration_minutes = duration_minutes
        self.total_calories = total_calories


class NinjaApi:
    def __init__(self):
        self.base = "https://api.api-ninjas.com/v1"
        self.key = "KeNJnT8ZxnJOHONW4ystxQ==NUt0XMTqpMFKAR4F"

    async def get_calculations(self, sport) -> [SportData]:
        url = f"{self.base}/caloriesburned?activity={sport}"
        try:
            response = requests.get(url, headers={'X-Api-Key': self.key})

            sports = []

            for x in response.json():
                sports.append(SportData(x["name"], x["calories_per_hour"], x["duration_minutes"], x["total_calories"]))

            return sports
        except Exception as e:
            print("Exception in Ninja Api.")
            return []