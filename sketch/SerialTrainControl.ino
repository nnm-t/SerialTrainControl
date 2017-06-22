/*
Serial Train Control

Copyright (c) 2015 Noname Kamisawa


This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/
#define INPUT_NUM 30
#define DIRECTION_FWD 9
#define DIRECTION_REV 10
#define POINT1_FWD A2
#define POINT1_REV A3
#define POINT2_FWD A4
#define POINT2_REV A5
char input[INPUT_NUM];
int i = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(DIRECTION_FWD, OUTPUT);
  pinMode(DIRECTION_REV, OUTPUT);
  pinMode(POINT1_FWD, OUTPUT);
  pinMode(POINT1_REV, OUTPUT);
  pinMode(POINT2_FWD, OUTPUT);
  pinMode(POINT2_REV, OUTPUT);
  analogWrite(DIRECTION_FWD, 0);
  analogWrite(DIRECTION_REV, 0);
  digitalWrite(POINT1_FWD, LOW);
  digitalWrite(POINT1_REV, LOW);
  digitalWrite(POINT2_FWD, LOW);
  digitalWrite(POINT2_REV, LOW);
  Serial.begin(115200);
  Serial.write("Get Started\n");
}

void control() {
  //入力したコマンドより制御
  //コマンドは"foo/bar."の形式で入力(/は形式と値の区切り、.は終端文字)
  String command = input;
  //fooの部分(コマンドの形式)を取得
  String com_type = command.substring(0, command.indexOf("/"));
  //barの部分(コマンドの値(数字))を取得
  String com_value = command.substring(command.indexOf("/") + 1);
  if (com_type == "fwd")
  {
    //前進
    analogWrite(DIRECTION_FWD, com_value.toInt());
    analogWrite(DIRECTION_REV, 0);
  }
  else if (com_type == "rev")
  {
    //後退
    analogWrite(DIRECTION_FWD, 0);
    analogWrite(DIRECTION_REV, com_value.toInt());
  }
  else if(com_type == "pt1")
  {
    //ポイント1切替
    switch(com_value.toInt())
    {
      case 1:
        //正位
        digitalWrite(POINT1_FWD, HIGH);
        delay(20);
        digitalWrite(POINT1_FWD, LOW);
        break;
      case -1:
        //正位
        digitalWrite(POINT1_REV, HIGH);
        delay(20);
        digitalWrite(POINT1_REV, LOW);
        break;
    }
  }
  else if(com_type == "pt2")
  {
    //ポイント1切替
    switch(com_value.toInt())
    {
      case 1:
        //正位
        digitalWrite(POINT2_FWD, HIGH);
        delay(20);
        digitalWrite(POINT2_FWD, LOW);
        break;
      case -1:
        //正位
        digitalWrite(POINT2_REV, HIGH);
        delay(20);
        digitalWrite(POINT2_REV, LOW);
        break;
    }
  }
  else
  {
    //それ以外は停止
    analogWrite(DIRECTION_FWD, 0);
    analogWrite(DIRECTION_REV, 0);
  }
}

void loop() {
  // データ受信したとき
  if (Serial.available()) {
    input[i] = Serial.read();
    // 文字数が30以上 or 末尾文字
    if (i > 30 || input[i] == '.') {
      // 末尾に終端文字の挿入
      input[i] = '\0';
      // 受信文字列を送信
      //Serial.write("\r\n");
      Serial.write("Input Command:");
      Serial.write(input);
      Serial.write("\r\n");
      //制御を実行
      control();
      // カウンタの初期化
      i = 0;
    }
    else {
      i++;
    }
  }
}
