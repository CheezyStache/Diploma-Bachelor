#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27,16,2);  // Устанавливаем дисплей

long contWidth, contLength, contHeight, input;
bool allEntered;

void setup()
{
  allEntered = true;
  lcd.init(); 
  lcd.backlight();// Включаем подсветку дисплея
  
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
      contWidth = input;
      resetVariables();
      Serial.println("You entered all measures!");
      Serial.println("Enter width:");
    }

    lcd.print(input);
    lcd.print(" ");
  }
  delay(10);
}

void clearLCD()
{
  lcd.setCursor(0,0);
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
