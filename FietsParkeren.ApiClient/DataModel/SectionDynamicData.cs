﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Newtonsoft.Json;

namespace FietsParkeren.ApiClient.DataModel
{
    public class SectionDynamicData
    {
        public string Id { get; set; }

        public DateTime? TimeStamp { get; set; }

        public string AuthorityId { get; set; }

        public string SurveyId { get; set; }

        public string ContractorId { get; set; }

        public int? ParkingCapacity { get; set; }

        public int? VacantSpaces { get; set; }

        public int? OccupiedSpaces { get; set; }

        public string StaticSectionId { get; set; }

        #region gone in api v2
        //public IEnumerable<Count> Counts { get; set; }
        #endregion  
    }
    
    public class SectionDynamicDataRaw
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? TimeStamp { get; set; }

        [JsonProperty("authorityId")]
        public string AuthorityId { get; set; }

        [JsonProperty("surveyId")]
        public string SurveyId { get; set; }

        [JsonProperty("contractorId")]
        public string ContractorId { get; set; }

        [JsonProperty("parkingCapacity")]
        public int? ParkingCapacity { get; set; }

        [JsonProperty("vacantSpaces")]
        public int? VacantSpaces { get; set; }

        [JsonProperty("occupiedSpaces")]
        public int? OccupiedSpaces { get; set; }

        [JsonProperty("staticSectionId")]
        public string StaticSectionId { get; set; }

        #region gone in api v2
        //[JsonProperty("count")]
        //public IEnumerable<CountRaw> CountsRaw { get; set; }
        #endregion

    }

    public class SectionDynamicDataRawResponse : BaseResponse
    {
        [JsonProperty("result")]
        public SectionDynamicDataRaw[] Sections { get; set; }

    }

    public class SectionDynamicDataMaxOccupationRawResponse : BaseResponse
    {
        [JsonProperty("result")]
        public SectionDynamicDataRawResponse[] Result { get; set; }

    }

    public static class SectionDynamicDataRawResponseExtensions
    {
        public static IEnumerable<SectionDynamicData> AsSection(this SectionDynamicDataRawResponse obj)
        {
            return obj?.Sections.AsSections();
        }
    }

    public static class SectionDynamicDataRawExtensions
    {
        public static SectionDynamicData AsSection(this SectionDynamicDataRaw obj)
        {
            if (obj != null)
                return new SectionDynamicData
                {
                    Id = obj.Id,
                    TimeStamp = obj.TimeStamp,
                    AuthorityId = obj.AuthorityId,
                    SurveyId = obj.SurveyId,
                    ContractorId = obj.ContractorId,
                    ParkingCapacity = obj.ParkingCapacity,
                    VacantSpaces = obj.VacantSpaces,
                    OccupiedSpaces = obj.OccupiedSpaces,
                    StaticSectionId = obj.StaticSectionId,
                    #region gone in api v2
                    //Counts = obj.CountsRaw.AsCounts()
                    #endregion
                };

            return null;
        }

        public static IEnumerable<SectionDynamicData> AsSections(this IEnumerable<SectionDynamicDataRaw> data)
        {
            return data.Select(x => x.AsSection());
        }

        public static IEnumerable<SectionDynamicData> AsSections(this SectionDynamicDataRawResponse data)
        {
            return data?.Sections.AsSections();
        }
    }
}
