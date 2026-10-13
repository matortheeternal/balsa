import struct

outdir = "/home/colin/git/balsa/fixtures"

def write_bsa(filename, version, abbrev):
    folder = b"interface"
    fname = b"test.txt"
    text = (
        "This is a test file for use in a %s BSA file.\r\n"
        "\r\n"
        "Produced by Mator 02/17/2021." % abbrev
    ).encode("ascii")
    folder_names_len = len(folder) + 1
    file_names_len = len(fname) + 1
    frec_len = 24 if version == 105 else 16
    block_actual = 36 + frec_len
    stored_off = block_actual + file_names_len
    header = struct.pack(
        "<4s8I", b"BSA\0", version, 36, 0x3, 1, 1,
        folder_names_len, file_names_len, 0x100,
    )
    assert len(header) == 36
    if version == 105:
        frec = struct.pack("<QIIQ", 0, 1, 0, stored_off)
    else:
        frec = struct.pack("<QII", 0, 1, stored_off)
    nameblob = struct.pack("B", len(folder) + 1) + folder + b"\x00"
    data_off = block_actual + len(nameblob) + 16 + file_names_len
    filerec = struct.pack("<QII", 0, len(text), data_off)
    blob = header + frec + nameblob + filerec + fname + b"\x00" + text
    path = outdir + "/" + filename
    open(path, "wb").write(blob)
    print(path, len(blob))

write_bsa("TES4.bsa", 103, "TES4")
write_bsa("FO3.bsa", 104, "FO3")
write_bsa("FNV.bsa", 104, "FNV")
write_bsa("SSE.bsa", 105, "SSE")
