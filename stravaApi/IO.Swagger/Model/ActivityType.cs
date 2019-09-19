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
    /// An enumeration of the types an activity may have.
    /// </summary>
    /// <value>An enumeration of the types an activity may have.</value>
    
    public enum ActivityType
    {

        /// <summary>
        /// Enum AlpineSki for value: AlpineSki
        /// </summary>

        AlpineSki,
        
        /// <summary>
        /// Enum BackcountrySki for value: BackcountrySki
        /// </summary>
        
        BackcountrySki,
        
        /// <summary>
        /// Enum Canoeing for value: Canoeing
        /// </summary>
        
        Canoeing,
        
        /// <summary>
        /// Enum Crossfit for value: Crossfit
        /// </summary>
        
        Crossfit ,
        
        /// <summary>
        /// Enum EBikeRide for value: EBikeRide
        /// </summary>
        
        EBikeRide,
        
        /// <summary>
        /// Enum Elliptical for value: Elliptical
        /// </summary>
        
        Elliptical,
        
        /// <summary>
        /// Enum Golf for value: Golf
        /// </summary>
        
        Golf,
        
        /// <summary>
        /// Enum Handcycle for value: Handcycle
        /// </summary>
        
        Handcycle,
        
        /// <summary>
        /// Enum Hike for value: Hike
        /// </summary>
        
        Hike ,
        
        /// <summary>
        /// Enum IceSkate for value: IceSkate
        /// </summary>
        
        IceSkate ,
        
        /// <summary>
        /// Enum InlineSkate for value: InlineSkate
        /// </summary>
        
        InlineSkate ,
        
        /// <summary>
        /// Enum Kayaking for value: Kayaking
        /// </summary>
        
        Kayaking ,
        
        /// <summary>
        /// Enum Kitesurf for value: Kitesurf
        /// </summary>
        
        Kitesurf ,
        
        /// <summary>
        /// Enum NordicSki for value: NordicSki
        /// </summary>
        
        NordicSki,
        
        /// <summary>
        /// Enum Ride for value: Ride
        /// </summary>
        
        Ride ,
        
        /// <summary>
        /// Enum RockClimbing for value: RockClimbing
        /// </summary>
        
        RockClimbing ,
        
        /// <summary>
        /// Enum RollerSki for value: RollerSki
        /// </summary>
        
        RollerSki ,
        
        /// <summary>
        /// Enum Rowing for value: Rowing
        /// </summary>
        
        Rowing ,
        
        /// <summary>
        /// Enum Run for value: Run
        /// </summary>
        
        Run ,
        
        /// <summary>
        /// Enum Sail for value: Sail
        /// </summary>
        
        Sail ,
        
        /// <summary>
        /// Enum Skateboard for value: Skateboard
        /// </summary>
        
        Skateboard ,
        
        /// <summary>
        /// Enum Snowboard for value: Snowboard
        /// </summary>
        
        Snowboard ,
        
        /// <summary>
        /// Enum Snowshoe for value: Snowshoe
        /// </summary>
        
        Snowshoe ,
        
        /// <summary>
        /// Enum Soccer for value: Soccer
        /// </summary>
        
        Soccer ,
        
        /// <summary>
        /// Enum StairStepper for value: StairStepper
        /// </summary>
        
        StairStepper ,
        
        /// <summary>
        /// Enum StandUpPaddling for value: StandUpPaddling
        /// </summary>
        
        StandUpPaddling,
        
        /// <summary>
        /// Enum Surfing for value: Surfing
        /// </summary>
        
        Surfing ,
        
        /// <summary>
        /// Enum Swim for value: Swim
        /// </summary>
        
        Swim ,
        
        /// <summary>
        /// Enum Velomobile for value: Velomobile
        /// </summary>
        
        Velomobile ,
        
        /// <summary>
        /// Enum VirtualRide for value: VirtualRide
        /// </summary>
        
        VirtualRide ,
        
        /// <summary>
        /// Enum VirtualRun for value: VirtualRun
        /// </summary>
        
        VirtualRun ,
        
        /// <summary>
        /// Enum Walk for value: Walk
        /// </summary>
        
        Walk ,
        
        /// <summary>
        /// Enum WeightTraining for value: WeightTraining
        /// </summary>
        
        WeightTraining ,
        
        /// <summary>
        /// Enum Wheelchair for value: Wheelchair
        /// </summary>
        
        Wheelchair ,
        
        /// <summary>
        /// Enum Windsurf for value: Windsurf
        /// </summary>
        
        Windsurf ,
        
        /// <summary>
        /// Enum Workout for value: Workout
        /// </summary>
        
        Workout,
        
        /// <summary>
        /// Enum Yoga for value: Yoga
        /// </summary>
        
        Yoga
    }

}
