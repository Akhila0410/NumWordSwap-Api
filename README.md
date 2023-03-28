# Number Word Swaps - Api

## Description
Built an API to return Dynamic Fizz Buzz words by taking a Max Number, Multiple - Word Swap combinations and a Sorted Order Boolean value.

`curl --location --request POST 'https://localhost:7152/api/getswappednumwords' \
--header 'Content-Type: application/json' \
--data-raw '{
    "maxNumber": 100,
    "multipleWordSwaps": [
        {
            "multiple": 3,
            "wordSwap": "Fizz"
        },
        {
            "multiple": 5,
            "wordSwap": "Buzz"
        }
    ],
    "sortedOrder": false
}'`

## Tech Stack
- .Net 6.0
- NSwag
- Swagger
- XUnit
- MOQ


## IDE
- Visual Studio
- PostMan

## Unit Tests
Written 16 Unit Tests covering primarily the integration of Controller and the Service layer and validating multiple input conditions.

![alt text](/images/xunit-tests-all-passed.png)


## Manual Testing

![alt text](/images/swagger-documentation.png)

![alt text](/images/swagger-documentation-with-input.png)

![alt text](/images/swagger-documentation-with-response.png)

![alt text](/images/Postman-testing.png)
