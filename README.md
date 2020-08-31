# CarRentalAPI

To run in development use:

```
dotnet run
```

For more information about the connection with the data source in Car Rental API, read the following [document](https://github.com/oriolbv/CarRentalAPI/blob/master/Doc/CarRentalAPI.pdf)

## API Requests

- Rent cars and get price
```
/rental/price?customer_id=XXXX
```
Also, you need to pass in the body parameters a json with this format:
```json
[
    {
        "carid": "1",
        "days": 6
    },
    {
        "carid": "2",
        "days": 2
    },
    {
        "carid": "3",
        "days": 1
    }
]
```

- Return cars and get surcharges
```
/rental/surcharges
```
Also, you need to pass in the body parameters a json with this format:
```json
[
    {
        "carid": "1",
        "days": 2
    },
    {
        "carid": "3",
        "days": 2
    }
]

```
