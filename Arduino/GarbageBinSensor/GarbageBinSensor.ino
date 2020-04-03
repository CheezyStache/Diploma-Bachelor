#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27,16,2);  // Устанавливаем дисплей

long contWidth, contLength, contHeight, input;
bool allEntered;

// defines pins numbers
const int trigPin = 11;
const int echoPin = 12;

const int redLED = 8;
const int greenLED = 9;

const float fillPercent = 0.8;

// defines variables
long duration, distanceMm;

void setup()
{
  resetVariables();
  
  lcd.init(); 
  lcd.backlight();// Включаем подсветку дисплея
  
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
    input = Serial.readString().toInt();
    if(allEntered)
    {
      resetVariables();
      clearLCD();
      allEntered = false;
    }

    if(contWidth == 0)
    {
      contWidth = input;
      Serial.println("Enter length:");
    }
    else if(contLength == 0)
    {
      contLength = input;
      Serial.println("Enter height:");
    }
    else if(contHeight == 0)
    {
      contHeight = input;
      allEntered = true;
      Serial.println("You entered all measures!");
      Serial.println("Enter width:");
    }

    lcd.print(input);
    lcd.print(" ");
    delay(10);
  }
  
  if(allEntered && contHeight != 0)
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
    
    lcd.setCursor(0,1); // Sets the location at which subsequent text written to the LCD will be displayed
    //lcd.print("Distance: "); // Prints string "Distance" on the LCD
    lcd.print(distanceMm); // Prints the distance value from the sensor
    lcd.print(" mm");

    if(distanceMm <= contHeight * (1.0 - fillPercent))
    {
      digitalWrite(redLED, HIGH);
      digitalWrite(greenLED, LOW);
    }
    else
    {
      digitalWrite(redLED, LOW);
      digitalWrite(greenLED, HIGH);
    }
    
    delay(1000);
  }
}

void clearLCD()
{
  lcd.setCursor(0,0);
  lcd.print("                ");
  lcd.setCursor(0,1);
  lcd.print("                ");
  lcd.setCursor(0,0);
}

void resetVariables()
{
  contWidth = 0;
  contLength = 0;
  contHeight = 0;
  allEntered = true;
}
