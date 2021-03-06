﻿using BtcE.Utils;
using Newtonsoft.Json.Linq;
using System;
namespace BtcE {
	public class TradeInfo {
		public decimal Amount { get; private set; }
		public DateTime Date { get; private set; }
		public BtceCurrency Item { get; private set; }
		public decimal Price { get; private set; }
		public BtceCurrency PriceCurrency { get; private set; }
		public uint Tid { get; private set; }
		public TradeInfoType Type { get; private set; }
		public static TradeInfo ReadFromJObject( JObject o ) {
			return o == null ? null : new TradeInfo() {
				Amount = o.Value<decimal>( "amount" ),
				Price = o.Value<decimal>( "price" ),
				Date = UnixTime.ConvertToDateTime( o.Value<UInt32>( "date" ) ),
				Item = BtceCurrencyHelper.FromString( o.Value<string>( "item" ) ),
				PriceCurrency = BtceCurrencyHelper.FromString( o.Value<string>( "price_currency" ) ),
				Tid = o.Value<uint>( "tid" ),
				Type = TradeInfoTypeHelper.FromString( o.Value<string>( "trade_type" ) )
			};
		}
	}
}
