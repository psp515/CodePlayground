# Food To Sport Translator 

Application is using 2 external services:
- [Edamam API](https://developer.edamam.com/edamam-docs-food-database-api) - to get information about food
- [Ninjas API](https://api-ninjas.com/api) - to get information about sport

#### Avaiable endpoints

- GET /calculation/form: Get the form for the calculation
- GET /calculation/result: Get the result of the calculation
- GET /calculation/result/raw: Get the raw result of the calculation
- GET /security/csrf: Get the CSRF token
- GET /security/csrf/raw: Get the CSRF token raw
- GET /: Welcome message and endpoints list
- GET /docs: API documentation


#### How to run

To run docker invoke following commands:

``` docker build -t food-to-sport-translator . ```

``` docker run -p 8000:80 ```