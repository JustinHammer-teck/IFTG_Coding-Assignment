# SettlementBookingTest

## [go down](#my-implementation-plan) to my implementation plan

## Versions

1. Basic Implementation

`BasicBookingController` provides an implementation within the controller that is complete but poorly written.

2. Mediator Implementation

`MediatorBookingController` provides an implementation using the mediator pattern and the data is stored in an [Interval Tree](https://en.wikipedia.org/wiki/Interval_tree) for O(log m + n) access.
This implementatrion also provides unit tests with a mocked repository.

## How to execute

1. Basic:

```
curl --request POST \
  --url https://localhost:44355/BasicBooking \
  --header 'Content-Type: application/json' \
  --data '{
	"bookingTime": "09:00",
	"name": "Keith"
}'
```

2. Mediator

```
curl --request POST \
  --url https://localhost:44355/MediatorBooking \
  --header 'Content-Type: application/json' \
  --data '{
	"bookingTime": "09:30",
	"name": "John"
}'
```
## My Implementation Plan

what I did : 
- restructure the project
- I add Automapper for fluent mapping from entity to dto, I believe in some cases we should control the mapping on our own
not only for performance and complex mapping base on project, but for demonstration purpose this is what I got.
- I add configuration data (Option Pattern) that can be control via BookingSystemOptions
I use this on my last project which support multi tenancy and can be deploy to 2 region 
this option pattern give me the control on each instance have different configuration.
- Mapping Configuration
- Implemented 
- Add new OutOfWorkingHourException 