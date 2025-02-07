# Robot
Arduino робот задвижван от два правотокови двигателя и управляван през bluetooth посредством Android мобилно устройство.

## 1. Shematics
Електрическа схема на свързване компонентите на робота:
![Shematics.png](Shematics.png)

## 2. Arduino
Изходен програмен код в интегрираната среда за разработка Arduino IDE:
![Arduino.png](Arduino.png)
```
// Control 2 DC motors with Smartphone via bluetooth
int state = 0;
int flag = 0;    
 
int motor1Pin1 = 4; // pin 4 on L293D IC
int motor1Pin2 = 5; // pin 5 on L293D IC
int motor2Pin1 = 6; // pin 6 on L293D IC
int motor2Pin2 = 7; // pin 7 on L293D IC

void setup() 
{
    // sets the pins as outputs:
    pinMode(motor1Pin1, OUTPUT);
    pinMode(motor1Pin2, OUTPUT);
    pinMode(motor2Pin1, OUTPUT);
    pinMode(motor2Pin2, OUTPUT);    
    // initialize serial communication at 9600 bits per second:
    Serial.begin(9600);
}

void loop() 
{
    // if some date is sent, reads it and saves in state
    if(Serial.available() > 0)
    {     
      state = Serial.read();   
      flag = 1;
      if(flag == 1) Serial.println(state);
    }       
    // Forward
    if (state == 'F') 
    {
        digitalWrite(motor1Pin1, HIGH);
        digitalWrite(motor1Pin2, LOW); 
        digitalWrite(motor2Pin1, LOW);
        digitalWrite(motor2Pin2, HIGH);
        if(flag == 1) Serial.println("FORWARD");
    }
    // Backward
    else if (state == 'B') 
    {
        digitalWrite(motor1Pin1, LOW); 
        digitalWrite(motor1Pin2, HIGH);
        digitalWrite(motor2Pin1, HIGH);
        digitalWrite(motor2Pin2, LOW);
        if(flag == 1) Serial.println("BACKWARD");
    }
    // Stop
    else if (state == 'S') 
    {
        digitalWrite(motor1Pin1, LOW); 
        digitalWrite(motor1Pin2, LOW); 
        digitalWrite(motor2Pin1, LOW);
        digitalWrite(motor2Pin2, LOW);
        if(flag == 1) Serial.println("STOP");
    }
    // Right
    else if (state == 'R') 
    {
        digitalWrite(motor1Pin1, LOW); 
        digitalWrite(motor1Pin2, LOW); 
        digitalWrite(motor2Pin1, LOW);
        digitalWrite(motor2Pin2, HIGH);
        if(flag == 1) Serial.println("RIGHT");
        delay(1500);
    }
    // Left
    else if (state == 'L') 
    {
        digitalWrite(motor1Pin1, HIGH); 
        digitalWrite(motor1Pin2, LOW); 
        digitalWrite(motor2Pin1, LOW);
        digitalWrite(motor2Pin2, LOW);
        if(flag == 1) Serial.println("LEFT");
        delay(1500);
    }
    flag = 0;
}
```
Изтегли цялата програма: [Arduino.ino](Arduino.ino)

## 3. Android
Android мобилното приложение е разработено с помоща на продукта [MIT App Inventor](http://ai2.appinventor.mit.edu/).
Изтеглете готовият пакет на мобилното приложение [Android.apk](Android.apk) и го качете на вашето Android устройство.

# Източник
[Arduino Control 2 DC Motors Via Bluetooth](https://randomnerdtutorials.com/arduino-control-2-dc-motors-via-bluetooth/)