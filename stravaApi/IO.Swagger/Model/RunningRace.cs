/* 
 * Strava API v3
 *
 * The [Swagger Playground](https://developers.strava.com/playground) is the easiest way to familiarize yourself with the Strava API by submitting HTTP requests and observing the responses before you write any client code. It will show what a response will look like with different endpoints depending on the authorization scope you receive from your athletes. To use the Playground, go to https://www.strava.com/settings/api and change your “Authorization Callback Domain” to developers.strava.com. Please note, we only support Swagger 2.0. There is a known issue where you can only select one scope at a time. For more information, please check the section “client code” at https://developers.strava.com/docs.
 *
 * OpenAPI spec version: 3.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// RunningRace
    /// </summary>
    [DataContract]
    public partial class RunningRace :  IEquatable<RunningRace>, IValidatableObject
    {
        /// <summary>
        /// The unit system in which the race should be displayed.
        /// </summary>
        /// <value>The unit system in which the race should be displayed.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MeasurementPreferenceEnum
        {
            
            /// <summary>
            /// Enum Feet for value: feet
            /// </summary>
            [EnumMember(Value = "feet")]
            Feet = 1,
            
            /// <summary>
            /// Enum Meters for value: meters
            /// </summary>
            [EnumMember(Value = "meters")]
            Meters = 2
        }

        /// <summary>
        /// The unit system in which the race should be displayed.
        /// </summary>
        /// <value>The unit system in which the race should be displayed.</value>
        [DataMember(Name="measurement_preference", EmitDefaultValue=false)]
        public MeasurementPreferenceEnum? MeasurementPreference { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RunningRace" /> class.
        /// </summary>
        /// <param name="id">The unique identifier of this race..</param>
        /// <param name="name">The name of this race..</param>
        /// <param name="runningRaceType">The type of this race..</param>
        /// <param name="distance">The race&#39;s distance, in meters..</param>
        /// <param name="startDateLocal">The time at which the race begins started in the local timezone..</param>
        /// <param name="city">The name of the city in which the race is taking place..</param>
        /// <param name="state">The name of the state or geographical region in which the race is taking place..</param>
        /// <param name="country">The name of the country in which the race is taking place..</param>
        /// <param name="routeIds">The set of routes that cover this race&#39;s course..</param>
        /// <param name="measurementPreference">The unit system in which the race should be displayed..</param>
        /// <param name="url">The vanity URL of this race on Strava..</param>
        /// <param name="websiteUrl">The URL of this race&#39;s website..</param>
        public RunningRace(int? id = default(int?), string name = default(string), int? runningRaceType = default(int?), float? distance = default(float?), DateTime? startDateLocal = default(DateTime?), string city = default(string), string state = default(string), string country = default(string), List<int?> routeIds = default(List<int?>), MeasurementPreferenceEnum? measurementPreference = default(MeasurementPreferenceEnum?), string url = default(string), string websiteUrl = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.RunningRaceType = runningRaceType;
            this.Distance = distance;
            this.StartDateLocal = startDateLocal;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.RouteIds = routeIds;
            this.MeasurementPreference = measurementPreference;
            this.Url = url;
            this.WebsiteUrl = websiteUrl;
        }
        
        /// <summary>
        /// The unique identifier of this race.
        /// </summary>
        /// <value>The unique identifier of this race.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// The name of this race.
        /// </summary>
        /// <value>The name of this race.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// The type of this race.
        /// </summary>
        /// <value>The type of this race.</value>
        [DataMember(Name="running_race_type", EmitDefaultValue=false)]
        public int? RunningRaceType { get; set; }

        /// <summary>
        /// The race&#39;s distance, in meters.
        /// </summary>
        /// <value>The race&#39;s distance, in meters.</value>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public float? Distance { get; set; }

        /// <summary>
        /// The time at which the race begins started in the local timezone.
        /// </summary>
        /// <value>The time at which the race begins started in the local timezone.</value>
        [DataMember(Name="start_date_local", EmitDefaultValue=false)]
        public DateTime? StartDateLocal { get; set; }

        /// <summary>
        /// The name of the city in which the race is taking place.
        /// </summary>
        /// <value>The name of the city in which the race is taking place.</value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// The name of the state or geographical region in which the race is taking place.
        /// </summary>
        /// <value>The name of the state or geographical region in which the race is taking place.</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// The name of the country in which the race is taking place.
        /// </summary>
        /// <value>The name of the country in which the race is taking place.</value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        /// The set of routes that cover this race&#39;s course.
        /// </summary>
        /// <value>The set of routes that cover this race&#39;s course.</value>
        [DataMember(Name="route_ids", EmitDefaultValue=false)]
        public List<int?> RouteIds { get; set; }


        /// <summary>
        /// The vanity URL of this race on Strava.
        /// </summary>
        /// <value>The vanity URL of this race on Strava.</value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// The URL of this race&#39;s website.
        /// </summary>
        /// <value>The URL of this race&#39;s website.</value>
        [DataMember(Name="website_url", EmitDefaultValue=false)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RunningRace {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RunningRaceType: ").Append(RunningRaceType).Append("\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  StartDateLocal: ").Append(StartDateLocal).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  RouteIds: ").Append(RouteIds).Append("\n");
            sb.Append("  MeasurementPreference: ").Append(MeasurementPreference).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  WebsiteUrl: ").Append(WebsiteUrl).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as RunningRace);
        }

        /// <summary>
        /// Returns true if RunningRace instances are equal
        /// </summary>
        /// <param name="input">Instance of RunningRace to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RunningRace input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.RunningRaceType == input.RunningRaceType ||
                    (this.RunningRaceType != null &&
                    this.RunningRaceType.Equals(input.RunningRaceType))
                ) && 
                (
                    this.Distance == input.Distance ||
                    (this.Distance != null &&
                    this.Distance.Equals(input.Distance))
                ) && 
                (
                    this.StartDateLocal == input.StartDateLocal ||
                    (this.StartDateLocal != null &&
                    this.StartDateLocal.Equals(input.StartDateLocal))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.RouteIds == input.RouteIds ||
                    this.RouteIds != null &&
                    this.RouteIds.SequenceEqual(input.RouteIds)
                ) && 
                (
                    this.MeasurementPreference == input.MeasurementPreference ||
                    (this.MeasurementPreference != null &&
                    this.MeasurementPreference.Equals(input.MeasurementPreference))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.WebsiteUrl == input.WebsiteUrl ||
                    (this.WebsiteUrl != null &&
                    this.WebsiteUrl.Equals(input.WebsiteUrl))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.RunningRaceType != null)
                    hashCode = hashCode * 59 + this.RunningRaceType.GetHashCode();
                if (this.Distance != null)
                    hashCode = hashCode * 59 + this.Distance.GetHashCode();
                if (this.StartDateLocal != null)
                    hashCode = hashCode * 59 + this.StartDateLocal.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.Country != null)
                    hashCode = hashCode * 59 + this.Country.GetHashCode();
                if (this.RouteIds != null)
                    hashCode = hashCode * 59 + this.RouteIds.GetHashCode();
                if (this.MeasurementPreference != null)
                    hashCode = hashCode * 59 + this.MeasurementPreference.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.WebsiteUrl != null)
                    hashCode = hashCode * 59 + this.WebsiteUrl.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
