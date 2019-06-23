import { User } from "./UserModel";
import { LaporanItem } from "./LaporanItemModel";

export class LaporanHeader {
    judulLaporan: string = "";
    keterangan: string = "";
    statusLaporan: string = "";
    userId: string = "";
    tglBuat: Date = new Date();
    tglSelesai: Date = null;
    user: User = new User;
    laporanItems: LaporanItem[] = [];
    status: string = "";
}