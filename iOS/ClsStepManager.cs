using System;
using maptest.iOS;
using CoreMotion;
using Foundation;
using System.Threading.Tasks;
using System.ComponentModel;
using Foundation;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(ClsStepManager))]


namespace maptest.iOS
{
	public class ClsStepManager:IStepCounter
	{
		//		public void  MotionPrivacyManager ()
		//		{
		////			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
		////				pedometer = new CMPedometer ();
		////				motionStatus = CMPedometer.IsStepCountingAvailable ? "Available" : "Not available";
		////			} else {
		////				stepCounter = new CMStepCounter ();
		////				motionManger = new CMMotionManager ();
		////				motionStatus = motionManger.DeviceMotionAvailable ? "Available" : "Not available";
		////			}
		//		}
		CMStepCounter stepCounter = new CMStepCounter ();
		string motionStatus = "Indeterminate";


		CMMotionManager motionManger; // before iOS 8.0
		//		CMPedometer pedometer = new CMPedometer (); // since iOS 8.0
		//NSDate FromDate = DateTimeToNSDate (DateTime.Now.AddMonths (-1));
		//NSDate FromDate = DateTimeToNSDate (DateTime.Now.AddMonths(-1));
		//NSDate ToDate = DateTimeToNSDate (DateTime.Now);
		//NSDate k = DateTimeToNSDate (d);
		nint steps;
		NSOperationQueue Q = NSOperationQueue.MainQueue;
		public string GetData (DateTime FromDate,DateTime ToDate)
		{
			RequestAccess (FromDate,ToDate);
			return steps.ToString();

		}
		public Task RequestAccess (DateTime FromDate,DateTime ToDate)
		{
			//				var yesterday = NSDate.FromTimeIntervalSinceNow (-60 * 60 * 24);
			//
			NSDate FromNSDate = DateTimeToNSDate (FromDate);
			NSDate ToNSDate = DateTimeToNSDate (ToDate);
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				if (!CMStepCounter.IsStepCountingAvailable)
					return Task.FromResult<object> (null);
			}
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) {
				if (!CMStepCounter.IsStepCountingAvailable)
					return Task.FromResult<object> (null);
			}

			//				return pedometer.QueryPedometerDataAsync (d, NSDate.Now)
			//						.ContinueWith (PedometrQueryContinuation);
			//			} else {
			//				if (!motionManger.DeviceMotionAvailable)
			//					return Task.FromResult<object> (null);
			//			}
			//	string log="", errAsincrono="";
			//	Task t= stepCounter.QueryStepCountAsync (k, NSDate.Now, NSOperationQueue.CurrentQueue).ContinueWith (StepQueryContinuation);


			return stepCounter.QueryStepCountAsync (FromNSDate,ToNSDate,Q)
				.ContinueWith(
					//
					//					if (t.IsFaulted || t.IsCanceled)
					//				{
					//						// The login failed. Check the error to see why.
					//						foreach (var es in t.Exception.InnerExceptions)
					//						{
					//
					//							log += es.Message;
					//
					//						}
					//						errAsincrono = t.Exception.Message;
					//
					//					}
					//					else
					//					{
					StepQueryContinuation);

			//				}
			//				});


		}
		public static DateTime NSDateToDateTime(NSDate date)
		{
			return (new DateTime(2001,1,1,0,0,0)).AddSeconds(date.SecondsSinceReferenceDate);
		}

		public static NSDate DateTimeToNSDate(DateTime date)
		{
			return NSDate.FromTimeIntervalSinceReferenceDate((date-(new DateTime(2001,1,1,0,0,0))).TotalSeconds);
		}

		void PedometrQueryContinuation(Task<CMPedometerData> t)
		{
			if (t.IsFaulted) {
				var code = ((NSErrorException)t.Exception.InnerException).Code;
				if (code == (int)CMError.MotionActivityNotAuthorized)
					motionStatus = "Not Authorized";
				return;
			}

			steps =t.Result.NumberOfSteps.NIntValue;
		}

		void StepQueryContinuation(Task<nint> t)
		{
			if (t.IsFaulted) {
				var code = ((NSErrorException)t.Exception.InnerException).Code;
				if (code == (int)CMError.MotionActivityNotAuthorized)
					motionStatus = "Not Authorized";
				return;
			}
			motionManger = new CMMotionManager ();


			steps = t.Result;
		}

		public string CheckAccess ()
		{
			return motionStatus;
		}

		public string GetCountsInfo()
		{
			return steps > 0 ? string.Format ("You have taken {0} steps in the past 24 hours", steps) : string.Empty;
		}

		public void Dispose ()
		{
			motionManger.Dispose ();
			stepCounter.Dispose ();
		}
	}

}

