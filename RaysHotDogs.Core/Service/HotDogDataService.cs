﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RaysHotDogs.Core
{
	public class HotDogDataService
	{
		private static HotDogRepository hotDogRepository = new HotDogRepository();

		public HotDogDataService ()
		{
			
		}

		public List<HotDog> GetAllHotDogs()
		{
			return hotDogRepository.GetAllHotDogs();
		}

		public List<HotDogGroup> GetGroupedHotDogs()
		{
			return hotDogRepository.GetGroupedHotDogs ();
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
		{
			return hotDogRepository.GetHotDogsForGroup (hotDogGroupId);
		}

		public List<HotDog> GetFavoriteHotDogs()
		{
			return hotDogRepository.GetFavoriteHotDogs ();
		}

		public HotDog GetHotDogById(int hotDogId)
		{
			return hotDogRepository.GetHotDogById (hotDogId);
		}

	}
}

