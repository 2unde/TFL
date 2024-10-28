Feature: Plan your journey feature

As a TLF user, I want to plan my journey
@mytag
Scenario: Journey planner
	Given a tfl user is on the Tfl website
	When I plan a new journey from "cov" to "lei"
	Then Jorney result should display the following:
		| Field               | Value                  |
		| Cycling             | Cycling                |
		| Route               | Route:Moderate         |
		| CyclingDistance     | 2mins                  |
		| CyclingDistanceInkm | Disatance:0.6km        |
		| Walking             | Walking                |
		| WalkingSpeed        | Walking speed:Moderate |
		| WalkingDistance     | 9mins                  |
		| WalkingDistanceInkm | Distance:0.4Km         |

		
