# CurrencyConverterAPI
An API for converting prices between currencies

This POC .Net Function API is developed to work with the api found here https://trainlinerecruitment.github.io/exchangerates/ to provide converted prices for the currency's available.

http://localhost:7071/api/priceconverterendpoint/?price={input price}&sourcecurrency={source currency}&targetcurrency={target currency}

Notes for extending the solution:
- Increase number and improve on the quality of unit tests with integration tests also added.
- Improve validation and user feedback when requests are submitted - specifically in cases of 404's due to currencies not being present in the downstream API. 
- Improve logging I've only had time for some rudimentary initial examples.
- improve error handling going hand in hand with the above two and hopefully with the direction of more requirements from the business.
- Integrate with API specification tool, especially important as functionality is extended.
- Add caching for responses from the currency exchange rate API, the spec said it had to be up to date so I didn't implement now but I'm assuming in a real world scenario some small caching for a limited time period, seconds/minutes, might be allowable.
- Add retry's for requests to the downstream API.
- Configure downstream endpoint in config along with the above instances features like caching time and retry functionality.
