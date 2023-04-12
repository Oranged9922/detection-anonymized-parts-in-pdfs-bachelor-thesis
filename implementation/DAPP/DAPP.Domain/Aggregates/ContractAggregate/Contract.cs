﻿namespace DAPP.Domain.Aggregates.ContractAggregate
{
	using System.Diagnostics;

	using DAPP.Domain.Aggregates.ContractAggregate.Entities;
	using DAPP.Domain.Common;

	[DebuggerDisplay("Id: {Id}, Name: {Name}, No. Pages: {PagesCount}")]
	public sealed class Contract
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public required string Path { get; set; }

		public required FileExtensionEnum Extension { get; set; }
		public List<ContractPage> Pages { get; set; }
		public int PagesCount { get => Pages.Count; }
	}
}