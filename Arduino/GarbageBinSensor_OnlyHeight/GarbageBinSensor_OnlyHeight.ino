#include <Wire.h> 

long contHeight;
bool idEntered = false, measuresEntered = false;

// defines pins numbers
const int trigPin = 11;
const int echoPin = 12;

const int redLED = 8;
const int greenLED = 9;

const float fillPercent = 0.8;
const long defaultDelay = 1000;
const long okDelay = 10000;
const long notOkDelay = 1000;

// defines variables
long duration, distanceMm;

String input, ID = "";
unsigned long previousMillis = 0;
long interval = 1000; 

void setup()
{
  resetVariables();
  
  pinMode(trigPin, OUTPUT); // Sets the trigPin as an Output
  pinMode(echoPin, INPUT); // Sets the echoPin as an Input

  pinMode(redLED, OUTPUT);
  pinMode(greenLED, OUTPUT);
  
  Serial.begin(9600); // Starts the serial communication
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
      Serial.println("Entered value is invalid");
      
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
      Serial.println("ID is set successfully");
      Serial.println("Enter container's height:");
      return;
    }
    
    if(measuresEntered)
    {
      if(ID == input)
      {
        Serial.println("Entered ID is correct");
        resetVariables();
        Serial.println("Enter container's height:");
      }
      else
        Serial.println("Incorrect ID");
        
      return;
    }

    if(enterVariable(&contHeight, input))
    {
      measuresEntered = true;
      Serial.println("Required data is entered");
      Serial.println("If you want to change data, enter sensor's ID:");
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
      digitalWrite(redLED, HIGH);
      digitalWrite(greenLED, LOW);
      Serial.print(distanceMm);
      Serial.println(" mm - Not OK");
      interval = notOkDelay;
    }
    else
    {
      digitalWrite(redLED, LOW);
      digitalWrite(greenLED, HIGH);
      Serial.print(distanceMm);
      Serial.println(" mm - OK");
      interval = okDelay;
    }
}
