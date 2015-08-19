using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.ModelBuilders
{
	public interface IStandingsModelBuilder
	{
		StandingsModel BuildModel();
	}
}