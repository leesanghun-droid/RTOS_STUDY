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

    > ref. qemu =>> X11_menual<br/>
    > qemu-system-arm -M realview-pb-a8 -kernel navilos.axf -S -gdb tcp::1234,ipv4<br/>
    > gdb-multiarch navilos.axf<br/>
    > (gdb) target remote:1234
    > (gdb) p/x ==> hex_print
    > (gdb) x/4b 0


## arm-none-eabi-gdb install

- gcc-arm-none-eabi-10.3-2021.10-x86_64-linux.tar.bz2 : </br>
    > https://developer.arm.com/-/media/Files/downloads/gnu-rm/10.3-2021.10/gcc-arm-none-eabi-10.3-2021.10-x86_64-linux.tar.bz2?rev=78196d3461ba4c9089a67b5f33edf82a&hash=D484B37FF37D6FC3597EBE2877FB666A41D5253B