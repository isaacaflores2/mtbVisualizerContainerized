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
    /// Upload
    /// </summary>
    [DataContract]
    public partial class Upload :  IEquatable<Upload>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Upload" /> class.
        /// </summary>
        /// <param name="id">The unique identifier of the upload.</param>
        /// <param name="idStr">The unique identifier of the upload in string format.</param>
        /// <param name="externalId">The external identifier of the upload.</param>
        /// <param name="error">The error associated with this upload.</param>
        /// <param name="status">The status of this upload.</param>
        /// <param name="activityId">The identifier of the activity this upload resulted into.</param>
        public Upload(long? id = default(long?), string idStr = default(string), string externalId = default(string), string error = default(string), string status = default(string), long? activityId = default(long?))
        {
            this.Id = id;
            this.IdStr = idStr;
            this.ExternalId = externalId;
            this.Error = error;
            this.Status = status;
            this.ActivityId = activityId;
        }
        
        /// <summary>
        /// The unique identifier of the upload
        /// </summary>
        /// <value>The unique identifier of the upload</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long? Id { get; set; }

        /// <summary>
        /// The unique identifier of the upload in string format
        /// </summary>
        /// <value>The unique identifier of the upload in string format</value>
        [DataMember(Name="id_str", EmitDefaultValue=false)]
        public string IdStr { get; set; }

        /// <summary>
        /// The external identifier of the upload
        /// </summary>
        /// <value>The external identifier of the upload</value>
        [DataMember(Name="external_id", EmitDefaultValue=false)]
        public string ExternalId { get; set; }

        /// <summary>
        /// The error associated with this upload
        /// </summary>
        /// <value>The error associated with this upload</value>
        [DataMember(Name="error", EmitDefaultValue=false)]
        public string Error { get; set; }

        /// <summary>
        /// The status of this upload
        /// </summary>
        /// <value>The status of this upload</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// The identifier of the activity this upload resulted into
        /// </summary>
        /// <value>The identifier of the activity this upload resulted into</value>
        [DataMember(Name="activity_id", EmitDefaultValue=false)]
        public long? ActivityId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Upload {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IdStr: ").Append(IdStr).Append("\n");
            sb.Append("  ExternalId: ").Append(ExternalId).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ActivityId: ").Append(ActivityId).Append("\n");
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
            return this.Equals(input as Upload);
        }

        /// <summary>
        /// Returns true if Upload instances are equal
        /// </summary>
        /// <param name="input">Instance of Upload to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Upload input)
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
                    this.IdStr == input.IdStr ||
                    (this.IdStr != null &&
                    this.IdStr.Equals(input.IdStr))
                ) && 
                (
                    this.ExternalId == input.ExternalId ||
                    (this.ExternalId != null &&
                    this.ExternalId.Equals(input.ExternalId))
                ) && 
                (
                    this.Error == input.Error ||
                    (this.Error != null &&
                    this.Error.Equals(input.Error))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.ActivityId == input.ActivityId ||
                    (this.ActivityId != null &&
                    this.ActivityId.Equals(input.ActivityId))
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
                if (this.IdStr != null)
                    hashCode = hashCode * 59 + this.IdStr.GetHashCode();
                if (this.ExternalId != null)
                    hashCode = hashCode * 59 + this.ExternalId.GetHashCode();
                if (this.Error != null)
                    hashCode = hashCode * 59 + this.Error.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.ActivityId != null)
                    hashCode = hashCode * 59 + this.ActivityId.GetHashCode();
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
