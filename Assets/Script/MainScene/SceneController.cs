/*
 The MIT License (MIT)

Copyright (c) 2013 yamamura tatsuhiko

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using UnityEngine;
using System.Collections;
using System;

public class SceneController : MonoBehaviour {

	[SerializeField] Fade fade;
	[SerializeField] FadeImage m_fadeImage;
	[SerializeField] GameObject m_blackOut;
	private Action m_action;

	// Use this for initialization
	void Start () {
		m_blackOut.SetActive (true);
		FirstFadeOut();
	}

	public void FirstFadeOut(){
		fade.FadeIn (0,()=>{
			m_blackOut.SetActive (false);
			OnFadeOut(0.6f);
		});
	}

	public void WarpFadeIn(float time, Action callback = null){
		fade.FadeIn (time,()=>{
			if(callback != null) callback();
		});
	}
	public void WarpFadeOut(float time, Action callback = null){
		fade.FadeOut (time,()=>{
			if(callback != null) callback();
		});
	}

	public void NextAreaFade(float time, Action callback = null){
		fade.FadeIn (time,()=>{
			OnFadeOut(time);
			if(callback != null) callback();
		});
	}

	public void OnFadeIn(float time, Action callback = null){
		fade.FadeIn (time);
		if(callback != null) callback();
	}
	
	public void OnFadeOut(float time, Action callback = null){
		fade.FadeOut (time);
		if(callback != null) callback();
	}

	public void SetBlackOut(){
		m_blackOut.SetActive (true);
		//FirstFadeOut();
	}

	public void SetAction(Action action = null){
		m_action = action;
	}
	public void ToAction(Action action){
		if (m_action != null) m_action();
	}
}
