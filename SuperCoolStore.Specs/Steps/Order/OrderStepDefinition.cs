using System.Collections.Generic;
using Store = SuperCoolStore.Entities;
using TechTalk.SpecFlow;
using FluentAssertions;
using TechTalk.SpecFlow.Assist;

namespace SuperCoolStore.Specs.Steps.Order
{
	// For additional information on feature specific Anti-patterns see http://www.thinkcode.se/blog/2016/06/22/cucumber-antipatterns
	// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

	/*
	 *  This attribute defines that this class contains binding steps, and is used together with 
	 * the parser to identify the feature related to the specified steps. Note that the phrasing
	 * matters as it can find multiples steps with the same name and defines on it's own which one
	 * to use. Be specific, but objective.
	 *  Note that a Scope atribute can also be assigned to the class or class's method this way coupling the step definition to the
	 * feature file. This is seen as an anti-pattern since it explicitly couples the code to the concept, a better way is to
	 * describe the scenario in detail using domain specific language and terms to create the proper binding.
	 *  An exemple of Scope usage with this feature context:
	 *      [Scope(Tag = "Shipping")] 
	 */
	[Binding]
	public sealed class OrderStepDefinition
	{
		private readonly ScenarioContext _scenarioContext;
		private decimal _result;
		private decimal _shippingFee;
		private float _orderWeight;
		private float _distance;
		private IEnumerable<Store.Item> _products;
		private Store.Order _sut;

		/*
		 * Obligatory constructor.
		 */
		public OrderStepDefinition(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		/*
		 *  Note how the parser is still able to recognize the parameter even if in the middle of the
		 * sentence using regex.
		 */
		[Given(@"the distance is (.*) kilometers")]
		public void GivenTheDistanceInKilometersIs(float distance)
		{
			_distance = distance;
		}

		/*
		 *  Note that the "Given" attibute is used to represent the "And" clause of the feature file. An "And" is a "Given"
		 * condition, so it should be treated as such. The same does apply for "And" clause when used after the "Then" clause,
		 * multiple "And" clauses after the "Then" are represented by the Then attribute in code.
		 */
		[Given(@"the shipping fee is (.*) cents")]
		public void GivenTheShippingFeeIs(decimal fee)
		{
			_shippingFee = fee;
		}

		[Given(@"the total order weight is (.*) kilograms")]
		public void GivenTheTotalOrderWeightIsKilograms(int weight)
		{
			_orderWeight = weight;
		}

		[When(@"the fee is calculated")]
		public void WhenTheFeeIsCalculated()
		{
			_result = Store.Order.CalculateShippingFee(_distance, _orderWeight, _shippingFee);
		}

		[Then(@"the shipping value should be (.*) dollars")]
		public void ThenTheShippingValueShouldBe(int expectedFee)
		{
			_result.Should().Be(expectedFee);
		}

		[Given(@"an order is placed with the following items")]
		public void GivenAnOrderIsPlacedWithTheFollowingItems(Table orderItems)
		{
			_products = orderItems.CreateSet<Store.Item>();
			_sut = new(_distance, _products, _shippingFee);
		}

		[When(@"the order grand total is calculated")]
		public void WhenTheOrderGrandTotalIsCalculated()
		{
			_result = _sut.GetTotal() - _sut.GetSubtotal();
		}

		[Then(@"the shipping fee should be (.*)")]
		public void ThenTheShippingFeeShouldBe(int expectedShippingFee)
		{
			_result.Should().Be(expectedShippingFee);
		}
	}
}
