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
    /// Lap
    /// </summary>
    [DataContract]
    public partial class Lap :  IEquatable<Lap>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lap" /> class.
        /// </summary>
        /// <param name="id">The unique identifier of this lap.</param>
        /// <param name="activity">activity.</param>
        /// <param name="athlete">athlete.</param>
        /// <param name="averageCadence">The lap&#39;s average cadence.</param>
        /// <param name="averageSpeed">The lap&#39;s average speed.</param>
        /// <param name="distance">The lap&#39;s distance, in meters.</param>
        /// <param name="elapsedTime">The lap&#39;s elapsed time, in seconds.</param>
        /// <param name="startIndex">The start index of this effort in its activity&#39;s stream.</param>
        /// <param name="endIndex">The end index of this effort in its activity&#39;s stream.</param>
        /// <param name="lapIndex">The index of this lap in the activity it belongs to.</param>
        /// <param name="maxSpeed">The maximum speed of this lat, in meters per second.</param>
        /// <param name="movingTime">The lap&#39;s moving time, in seconds.</param>
        /// <param name="name">The name of the lap.</param>
        /// <param name="paceZone">The athlete&#39;s pace zone during this lap.</param>
        /// <param name="split">split.</param>
        /// <param name="startDate">The time at which the lap was started..</param>
        /// <param name="startDateLocal">The time at which the lap was started in the local timezone..</param>
        /// <param name="totalElevationGain">The elevation gain of this lap, in meters.</param>
        public Lap(long? id = default(long?), MetaActivity activity = default(MetaActivity), MetaAthlete athlete = default(MetaAthlete), float? averageCadence = default(float?), float? averageSpeed = default(float?), float? distance = default(float?), int? elapsedTime = default(int?), int? startIndex = default(int?), int? endIndex = default(int?), int? lapIndex = default(int?), float? maxSpeed = default(float?), int? movingTime = default(int?), string name = default(string), int? paceZone = default(int?), int? split = default(int?), DateTime? startDate = default(DateTime?), DateTime? startDateLocal = default(DateTime?), float? totalElevationGain = default(float?))
        {
            this.Id = id;
            this.Activity = activity;
            this.Athlete = athlete;
            this.AverageCadence = averageCadence;
            this.AverageSpeed = averageSpeed;
            this.Distance = distance;
            this.ElapsedTime = elapsedTime;
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;
            this.LapIndex = lapIndex;
            this.MaxSpeed = maxSpeed;
            this.MovingTime = movingTime;
            this.Name = name;
            this.PaceZone = paceZone;
            this.Split = split;
            this.StartDate = startDate;
            this.StartDateLocal = startDateLocal;
            this.TotalElevationGain = totalElevationGain;
        }
        
        /// <summary>
        /// The unique identifier of this lap
        /// </summary>
        /// <value>The unique identifier of this lap</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Activity
        /// </summary>
        [DataMember(Name="activity", EmitDefaultValue=false)]
        public MetaActivity Activity { get; set; }

        /// <summary>
        /// Gets or Sets Athlete
        /// </summary>
        [DataMember(Name="athlete", EmitDefaultValue=false)]
        public MetaAthlete Athlete { get; set; }

        /// <summary>
        /// The lap&#39;s average cadence
        /// </summary>
        /// <value>The lap&#39;s average cadence</value>
        [DataMember(Name="average_cadence", EmitDefaultValue=false)]
        public float? AverageCadence { get; set; }

        /// <summary>
        /// The lap&#39;s average speed
        /// </summary>
        /// <value>The lap&#39;s average speed</value>
        [DataMember(Name="average_speed", EmitDefaultValue=false)]
        public float? AverageSpeed { get; set; }

        /// <summary>
        /// The lap&#39;s distance, in meters
        /// </summary>
        /// <value>The lap&#39;s distance, in meters</value>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public float? Distance { get; set; }

        /// <summary>
        /// The lap&#39;s elapsed time, in seconds
        /// </summary>
        /// <value>The lap&#39;s elapsed time, in seconds</value>
        [DataMember(Name="elapsed_time", EmitDefaultValue=false)]
        public int? ElapsedTime { get; set; }

        /// <summary>
        /// The start index of this effort in its activity&#39;s stream
        /// </summary>
        /// <value>The start index of this effort in its activity&#39;s stream</value>
        [DataMember(Name="start_index", EmitDefaultValue=false)]
        public int? StartIndex { get; set; }

        /// <summary>
        /// The end index of this effort in its activity&#39;s stream
        /// </summary>
        /// <value>The end index of this effort in its activity&#39;s stream</value>
        [DataMember(Name="end_index", EmitDefaultValue=false)]
        public int? EndIndex { get; set; }

        /// <summary>
        /// The index of this lap in the activity it belongs to
        /// </summary>
        /// <value>The index of this lap in the activity it belongs to</value>
        [DataMember(Name="lap_index", EmitDefaultValue=false)]
        public int? LapIndex { get; set; }

        /// <summary>
        /// The maximum speed of this lat, in meters per second
        /// </summary>
        /// <value>The maximum speed of this lat, in meters per second</value>
        [DataMember(Name="max_speed", EmitDefaultValue=false)]
        public float? MaxSpeed { get; set; }

        /// <summary>
        /// The lap&#39;s moving time, in seconds
        /// </summary>
        /// <value>The lap&#39;s moving time, in seconds</value>
        [DataMember(Name="moving_time", EmitDefaultValue=false)]
        public int? MovingTime { get; set; }

        /// <summary>
        /// The name of the lap
        /// </summary>
        /// <value>The name of the lap</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// The athlete&#39;s pace zone during this lap
        /// </summary>
        /// <value>The athlete&#39;s pace zone during this lap</value>
        [DataMember(Name="pace_zone", EmitDefaultValue=false)]
        public int? PaceZone { get; set; }

        /// <summary>
        /// Gets or Sets Split
        /// </summary>
        [DataMember(Name="split", EmitDefaultValue=false)]
        public int? Split { get; set; }

        /// <summary>
        /// The time at which the lap was started.
        /// </summary>
        /// <value>The time at which the lap was started.</value>
        [DataMember(Name="start_date", EmitDefaultValue=false)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The time at which the lap was started in the local timezone.
        /// </summary>
        /// <value>The time at which the lap was started in the local timezone.</value>
        [DataMember(Name="start_date_local", EmitDefaultValue=false)]
        public DateTime? StartDateLocal { get; set; }

        /// <summary>
        /// The elevation gain of this lap, in meters
        /// </summary>
        /// <value>The elevation gain of this lap, in meters</value>
        [DataMember(Name="total_elevation_gain", EmitDefaultValue=false)]
        public float? TotalElevationGain { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Lap {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Activity: ").Append(Activity).Append("\n");
            sb.Append("  Athlete: ").Append(Athlete).Append("\n");
            sb.Append("  AverageCadence: ").Append(AverageCadence).Append("\n");
            sb.Append("  AverageSpeed: ").Append(AverageSpeed).Append("\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  ElapsedTime: ").Append(ElapsedTime).Append("\n");
            sb.Append("  StartIndex: ").Append(StartIndex).Append("\n");
            sb.Append("  EndIndex: ").Append(EndIndex).Append("\n");
            sb.Append("  LapIndex: ").Append(LapIndex).Append("\n");
            sb.Append("  MaxSpeed: ").Append(MaxSpeed).Append("\n");
            sb.Append("  MovingTime: ").Append(MovingTime).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PaceZone: ").Append(PaceZone).Append("\n");
            sb.Append("  Split: ").Append(Split).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  StartDateLocal: ").Append(StartDateLocal).Append("\n");
            sb.Append("  TotalElevationGain: ").Append(TotalElevationGain).Append("\n");
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
            return this.Equals(input as Lap);
        }

        /// <summary>
        /// Returns true if Lap instances are equal
        /// </summary>
        /// <param name="input">Instance of Lap to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Lap input)
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
                    this.Activity == input.Activity ||
                    (this.Activity != null &&
                    this.Activity.Equals(input.Activity))
                ) && 
                (
                    this.Athlete == input.Athlete ||
                    (this.Athlete != null &&
                    this.Athlete.Equals(input.Athlete))
                ) && 
                (
                    this.AverageCadence == input.AverageCadence ||
                    (this.AverageCadence != null &&
                    this.AverageCadence.Equals(input.AverageCadence))
                ) && 
                (
                    this.AverageSpeed == input.AverageSpeed ||
                    (this.AverageSpeed != null &&
                    this.AverageSpeed.Equals(input.AverageSpeed))
                ) && 
                (
                    this.Distance == input.Distance ||
                    (this.Distance != null &&
                    this.Distance.Equals(input.Distance))
                ) && 
                (
                    this.ElapsedTime == input.ElapsedTime ||
                    (this.ElapsedTime != null &&
                    this.ElapsedTime.Equals(input.ElapsedTime))
                ) && 
                (
                    this.StartIndex == input.StartIndex ||
                    (this.StartIndex != null &&
                    this.StartIndex.Equals(input.StartIndex))
                ) && 
                (
                    this.EndIndex == input.EndIndex ||
                    (this.EndIndex != null &&
                    this.EndIndex.Equals(input.EndIndex))
                ) && 
                (
                    this.LapIndex == input.LapIndex ||
                    (this.LapIndex != null &&
                    this.LapIndex.Equals(input.LapIndex))
                ) && 
                (
                    this.MaxSpeed == input.MaxSpeed ||
                    (this.MaxSpeed != null &&
                    this.MaxSpeed.Equals(input.MaxSpeed))
                ) && 
                (
                    this.MovingTime == input.MovingTime ||
                    (this.MovingTime != null &&
                    this.MovingTime.Equals(input.MovingTime))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.PaceZone == input.PaceZone ||
                    (this.PaceZone != null &&
                    this.PaceZone.Equals(input.PaceZone))
                ) && 
                (
                    this.Split == input.Split ||
                    (this.Split != null &&
                    this.Split.Equals(input.Split))
                ) && 
                (
                    this.StartDate == input.StartDate ||
                    (this.StartDate != null &&
                    this.StartDate.Equals(input.StartDate))
                ) && 
                (
                    this.StartDateLocal == input.StartDateLocal ||
                    (this.StartDateLocal != null &&
                    this.StartDateLocal.Equals(input.StartDateLocal))
                ) && 
                (
                    this.TotalElevationGain == input.TotalElevationGain ||
                    (this.TotalElevationGain != null &&
                    this.TotalElevationGain.Equals(input.TotalElevationGain))
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
                if (this.Activity != null)
                    hashCode = hashCode * 59 + this.Activity.GetHashCode();
                if (this.Athlete != null)
                    hashCode = hashCode * 59 + this.Athlete.GetHashCode();
                if (this.AverageCadence != null)
                    hashCode = hashCode * 59 + this.AverageCadence.GetHashCode();
                if (this.AverageSpeed != null)
                    hashCode = hashCode * 59 + this.AverageSpeed.GetHashCode();
                if (this.Distance != null)
                    hashCode = hashCode * 59 + this.Distance.GetHashCode();
                if (this.ElapsedTime != null)
                    hashCode = hashCode * 59 + this.ElapsedTime.GetHashCode();
                if (this.StartIndex != null)
                    hashCode = hashCode * 59 + this.StartIndex.GetHashCode();
                if (this.EndIndex != null)
                    hashCode = hashCode * 59 + this.EndIndex.GetHashCode();
                if (this.LapIndex != null)
                    hashCode = hashCode * 59 + this.LapIndex.GetHashCode();
                if (this.MaxSpeed != null)
                    hashCode = hashCode * 59 + this.MaxSpeed.GetHashCode();
                if (this.MovingTime != null)
                    hashCode = hashCode * 59 + this.MovingTime.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.PaceZone != null)
                    hashCode = hashCode * 59 + this.PaceZone.GetHashCode();
                if (this.Split != null)
                    hashCode = hashCode * 59 + this.Split.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.StartDateLocal != null)
                    hashCode = hashCode * 59 + this.StartDateLocal.GetHashCode();
                if (this.TotalElevationGain != null)
                    hashCode = hashCode * 59 + this.TotalElevationGain.GetHashCode();
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
