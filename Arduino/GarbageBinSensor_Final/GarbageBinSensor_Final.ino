//Codes:
//OK - 0
//Not OK - 1
//2 - First ID success
//3 - ID is incorrect
//4 - ID authorization success
//5 - Entered value is invalid
//6 - Data is entered (will send ID and height - 2 responses)

#include <Wire.h> 

long contHeight;
bool idEntered = false, measuresEntered = false;

const int trigPin = 11;
const int echoPin = 12;

const float fillPercent = 0.8;
const long defaultDelay = 1000;
const long okDelay = 10000;
const long notOkDelay = 1000;

long duration, distanceMm;

String input, ID = "";
unsigned long previousMillis = 0;
long interval = 1000; 

void setup()
{
  resetVariables();
  
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  
  Serial.begin(9600);
}

void loop()
{
  if (Serial.available())
  {
    enterData();
  }

  unsigned long currentMillis = millis();

  if (currentMillis - previousMillis < interval) {
    delay(defaultDelay);
    return;
  }

  previousMillis = currentMillis;

  if(measuresEntered)
  {
    checkDistance();
  }

  delay(defaultDelay);
}


void resetVariables()
{
  contHeight = 0;
  measuresEntered = false;
}

bool enterVariable(long *currentValue, String input)
{
  if(*currentValue != 0 || input.toInt() <= 0)
  {
    if(input.toInt() <= 0)
      Serial.println(5);
      
    return false;
  }

  *currentValue = input.toInt();
  return true;
}

void enterData()
{
  input = Serial.readString();

    if(!idEntered)
    {
      ID = input;
      idEntered = true;
      Serial.println(2);
      return;
    }
    
    if(measuresEntered)
    {
      if(ID == input)
      {
        Serial.println(4);
        resetVariables();
      }
      else
        Serial.println(3);
        
      return;
    }

    if(enterVariable(&contHeight, input))
    {
      measuresEntered = true;
      Serial.println(6);
      Serial.println(ID);
      Serial.println(contHeight);
      return;
    }
}

void checkDistance()
{
  // Clears the trigPin
    digitalWrite(trigPin, LOW);
    delayMicroseconds(2);
    
    // Sets the trigPin on HIGH state for 10 micro seconds
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin, LOW);
    
    // Reads the echoPin, returns the sound wave travel time in microseconds
    duration = pulseIn(echoPin, HIGH);
    
    // Calculating the distance
    distanceMm= duration*0.34/2;
    
    if(distanceMm <= contHeight * (1.0 - fillPercent))
    {
      Serial.println(0);
      interval = notOkDelay;
    }
    else
    {
      Serial.println(1);
      interval = okDelay;
    }
}
