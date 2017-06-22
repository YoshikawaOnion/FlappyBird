using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class NotifyProperty<T> : IObservable<T> {
	private Subject<T> subject;
	private T value_;

	public T Value {
		get{ return value_; }
		set {
			value_ = value;
			subject.OnNext (value);
		}
	}

	public NotifyProperty ()
	{
		subject = new Subject<T> ();
	}

	public void Dispose(){
		subject.Dispose ();
	}

	public IDisposable Subscribe(IObserver<T> observer){
		return subject.Subscribe (observer);
	}
}
