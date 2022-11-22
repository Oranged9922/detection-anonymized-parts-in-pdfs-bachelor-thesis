﻿namespace DAPP.Models
{
	public class AnalyzedContractModel
	{
		public int ContractId { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? FilePath { get; set; }
		public List<BoundingBoxModel>? BoundingBoxes { get; set; }
	}
}
