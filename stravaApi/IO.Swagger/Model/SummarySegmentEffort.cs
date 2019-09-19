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
    /// SummarySegmentEffort
    /// </summary>
    [DataContract]
    public partial class SummarySegmentEffort :  IEquatable<SummarySegmentEffort>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummarySegmentEffort" /> class.
        /// </summary>
        /// <param name="id">The unique identifier of this effort.</param>
        /// <param name="elapsedTime">The effort&#39;s elapsed time.</param>
        /// <param name="startDate">The time at which the effort was started..</param>
        /// <param name="startDateLocal">The time at which the effort was started in the local timezone..</param>
        /// <param name="distance">The effort&#39;s distance in meters.</param>
        /// <param name="isKom">Whether this effort is the current best on the leaderboard.</param>
        public SummarySegmentEffort(long? id = default(long?), int? elapsedTime = default(int?), DateTime? startDate = default(DateTime?), DateTime? startDateLocal = default(DateTime?), float? distance = default(float?), bool? isKom = default(bool?))
        {
            this.Id = id;
            this.ElapsedTime = elapsedTime;
            this.StartDate = startDate;
            this.StartDateLocal = startDateLocal;
            this.Distance = distance;
            this.IsKom = isKom;
        }
        
        /// <summary>
        /// The unique identifier of this effort
        /// </summary>
        /// <value>The unique identifier of this effort</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long? Id { get; set; }

        /// <summary>
        /// The effort&#39;s elapsed time
        /// </summary>
        /// <value>The effort&#39;s elapsed time</value>
        [DataMember(Name="elapsed_time", EmitDefaultValue=false)]
        public int? ElapsedTime { get; set; }

        /// <summary>
        /// The time at which the effort was started.
        /// </summary>
        /// <value>The time at which the effort was started.</value>
        [DataMember(Name="start_date", EmitDefaultValue=false)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The time at which the effort was started in the local timezone.
        /// </summary>
        /// <value>The time at which the effort was started in the local timezone.</value>
        [DataMember(Name="start_date_local", EmitDefaultValue=false)]
        public DateTime? StartDateLocal { get; set; }

        /// <summary>
        /// The effort&#39;s distance in meters
        /// </summary>
        /// <value>The effort&#39;s distance in meters</value>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public float? Distance { get; set; }

        /// <summary>
        /// Whether this effort is the current best on the leaderboard
        /// </summary>
        /// <value>Whether this effort is the current best on the leaderboard</value>
        [DataMember(Name="is_kom", EmitDefaultValue=false)]
        public bool? IsKom { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SummarySegmentEffort {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ElapsedTime: ").Append(ElapsedTime).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  StartDateLocal: ").Append(StartDateLocal).Append("\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  IsKom: ").Append(IsKom).Append("\n");
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
            return this.Equals(input as SummarySegmentEffort);
        }

        /// <summary>
        /// Returns true if SummarySegmentEffort instances are equal
        /// </summary>
        /// <param name="input">Instance of SummarySegmentEffort to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SummarySegmentEffort input)
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
                    this.ElapsedTime == input.ElapsedTime ||
                    (this.ElapsedTime != null &&
                    this.ElapsedTime.Equals(input.ElapsedTime))
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
                    this.Distance == input.Distance ||
                    (this.Distance != null &&
                    this.Distance.Equals(input.Distance))
                ) && 
                (
                    this.IsKom == input.IsKom ||
                    (this.IsKom != null &&
                    this.IsKom.Equals(input.IsKom))
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
                if (this.ElapsedTime != null)
                    hashCode = hashCode * 59 + this.ElapsedTime.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.StartDateLocal != null)
                    hashCode = hashCode * 59 + this.StartDateLocal.GetHashCode();
                if (this.Distance != null)
                    hashCode = hashCode * 59 + this.Distance.GetHashCode();
                if (this.IsKom != null)
                    hashCode = hashCode * 59 + this.IsKom.GetHashCode();
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
