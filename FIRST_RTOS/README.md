## Entry.S

- compile

    > arm-none-eabi-as -march=armv7-a -mcpu=cortex-a8 -o Entry.o ./Entry.S<br/>
    arm-none-eabi-objcopy -O binary Entry.o Entry.bin<br/>
    hexdump Entry.bin<br/>

## navilos.ld

- Linker

    > arm-none-eabi-ld -n -T ./navilos.ld -nostdlib -o navilos.axf boot/Entry.o<br/>
    > arm-none-eabi-objdump -D navilos.axf<br/>

## run with QEMU

- QEMU run

    > qemu-system-arm -M realview-pb-a8 -kernel navilos.axf -S -gdb tcp::1234,ipv4<br/>
    > install xming<br/>
    > gdb-multiarch navilos.axf<br/>