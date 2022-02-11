


#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <DHT_U.h>

float h;
#define DHTPIN A0     
#define DHTTYPE DHT11    
DHT_Unified dht(DHTPIN, DHTTYPE);

uint32_t delayMS;



void setup() {
  Serial.begin(9600);
    dht.begin();
    //sensor_t sensor;
pinMode(22,OUTPUT);
pinMode(23,OUTPUT);
pinMode(24,OUTPUT);
}

void loop() {
   sensors_event_t event;
  String readString;
  String Q;
  while(Serial.available())
  {
    delay(1);
    if(Serial.available()>0)
    {
     // Serial.println("1");
      char c=Serial.read();
      //Serial.println(c);
     if(isControl(c))
      {
        //Serial.println("2");
        break;
        }
        readString+=c;
        // Serial.println(readString);
      }
    }
  Q=readString;
  //Serial.println(Q);
  if(Q=="gon")
  {
   digitalWrite(22,HIGH);
   
     }
      if(Q=="goff")
  {
   digitalWrite(22,LOW);
   
     }
if(Q=="yon")
  {
    digitalWrite(24,HIGH);
     }
      if(Q=="yoff")
  {
   digitalWrite(24,LOW);
   
     }
     if(Q=="ron")
  {
    digitalWrite(23,HIGH);
     }
      if(Q=="roff")
  {
   digitalWrite(23,LOW);
   
     }
     if(Q=="gt")
     {
      dht.temperature().getEvent(&event);
  if (isnan(event.temperature)) {
    Serial.println(F("Error reading temperature!"));
  }
  else {
   
    Serial.println(event.temperature);
    
  }
      }
      if(Q=="gh")
      {
        dht.humidity().getEvent(&event);
  if (isnan(event.relative_humidity)) {
    Serial.println(F("Error reading humidity!"));
  }
  else {
   
    Serial.println(event.relative_humidity);
   
    }
        }
}
