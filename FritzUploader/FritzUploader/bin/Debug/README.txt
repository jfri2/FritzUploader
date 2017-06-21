FritzUploader

Upload .hex files to ATmega328P or ATmega328PB 

Instructions for use:
    1) Open the application
    2) Browse for and select the .hex file you want to upload to your microcontroller
    3) Select the proper COM port
    4) Select the microcontroller (ATmega328P or ATmega328PB) to upload the program to
    5) Before pressing upload,  reset the microcontroller (press the reset button or hold the reset line low)
    6) Release the reset button and click the "Upload" button within 3 seconds of releasing the reset line. 

Note: The bootload has around a 3 second timeout after MCU reset to upload a new application. After reset/power cycle
if no activity is detected on the MCU bootloader pins, the MCU will boot to the application last loaded to flash. 