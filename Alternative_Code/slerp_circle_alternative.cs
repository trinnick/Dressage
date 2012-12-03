	/* fullCircle Method using Slerp Function
	IEnumerator fullCircleMovement(Vector3 first, float diameter, string marker, string side){
		float circleAdjustment = 2.0f;
		Vector3 center = new Vector3();
		Vector3 second = new Vector3(first.x,first.y,first.z);
		
		if(marker == "C"){
				if(side == "Left"){
				second = new Vector3(first.x + diameter - circleAdjustment,first.y,first.z);
				center += new Vector3(first.x + (diameter - circleAdjustment)/2.0f,first.y,first.z);
			    float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			}
			if(side == "Right"){
				second = new Vector3(first.x + (diameter - circleAdjustment),first.y,first.z);
				center += new Vector3(first.x + (diameter - circleAdjustment)/2.0f,first.y,first.z);
			    float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			}
		}
		
		if(marker == "A"){
				if(side == "Right"){
				second = new Vector3(first.x - (diameter - circleAdjustment),first.y,first.z);
				center += new Vector3(first.x - (diameter - circleAdjustment)/2.0f,first.y,first.z);
			    float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			}
			if(side == "Left"){
				second = new Vector3(first.x - (diameter - circleAdjustment),first.y,first.z);
				center += new Vector3(first.x - (diameter - circleAdjustment)/2.0f,first.y,first.z);
			    float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			}
		}
		
		if(marker == "G" || marker == "I" || marker == "X" || marker == "L" || marker == "D"){
			if(side == "Left"){
				second = new Vector3(first.x,first.y,first.z - (diameter - circleAdjustment));
				center += new Vector3(first.x,first.y,first.z - (diameter - circleAdjustment)/2.0f);
				
				float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			}
			if(side == "Right"){
				second = new Vector3(first.x,first.y,first.z + (diameter - circleAdjustment));
				center += new Vector3(first.x,first.y,first.z + (diameter - circleAdjustment)/2.0f);
				
				float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();
				}
			}
		}
		
		if(marker == "H" || marker == "S" || marker == "E" || marker == "V" || marker == "K"){
			if(side == "Right"){
				second = new Vector3(first.x,first.y,first.z + (diameter - circleAdjustment));
				center += new Vector3(first.x,first.y,first.z + (diameter - circleAdjustment)/2.0f);
				
				float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			}
			if(side == "Left"){
				second = new Vector3(first.x,first.y,first.z + (diameter - circleAdjustment));
				center += new Vector3(first.x,first.y,first.z + (diameter - circleAdjustment)/2.0f);
				
				float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();
				}
			}
		}
		
		if(marker == "M" || marker == "R" || marker == "B" || marker == "P" || marker == "F"){
			if(side == "Left"){
				second = new Vector3(first.x,first.y,first.z - (diameter - circleAdjustment));
				center += new Vector3(first.x,first.y,first.z - (diameter - circleAdjustment)/2.0f);
				
				float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcFirst, arcSecond, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			}
			if(side == "Right"){
				second = new Vector3(first.x,first.y,first.z - (diameter - circleAdjustment));
				center += new Vector3(first.x,first.y,first.z - (diameter - circleAdjustment)/2.0f);
				
				float dist = (float)Math.PI * (diameter - circleAdjustment);
				
			    Vector3 arcFirst = first - center;
			    Vector3 arcSecond = second - center;
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = -Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();	
			    }
			
			    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {		
				    // Interpolate over the arc relative to center
				    transform.position = Vector3.Slerp(arcSecond, arcFirst, i);
				    transform.position += center;
					yield return null;
					
					pauseMovement();
					tg.toggle();
				}
			}
		}
	}
	*/
