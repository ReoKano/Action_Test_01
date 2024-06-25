using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

//===================================================
// 更新履歴
//===================================================
// 2024/06/11 : 012020048D : 新規追加
// 2024/06/15 : 012020048D : Task1 : File_Select() 追加
//===================================================

public class Commons
{
	//===================================================
	// ファイル選択
	//===================================================
	// pop_msg : 表示させるメッセージ
	// top_msg : メッセージボックスのタイトル
	// file_Name：デフォルトのファイル名
	// file_filter：[ファイルの種類]に表示される選択肢、ファイル形式
	// title_msg：ウィンドウのタイトル
	// output_file：開いたファイル
	//===================================================
	static public string File_Select(string pop_msg, string top_msg, string file_Name, string file_filter, string title_msg)
	{
		string err_txt;

		//OpenFileDialogクラスのインスタンスを作成
		System.Windows.Forms.OpenFileDialog open_ofd = new System.Windows.Forms.OpenFileDialog();

		//はじめのファイル名を指定する
		//はじめに「ファイル名」で表示される文字列を指定する
		open_ofd.FileName = file_Name;
		//はじめに表示されるフォルダを指定する
		//指定しない（空の文字列）の時は、現在のディレクトリが表示される
		//ofd.InitialDirectory = @"C:\";
		//[ファイルの種類]に表示される選択肢を指定する
		//指定しないとすべてのファイルが表示される
		open_ofd.Filter = file_filter;
		//[ファイルの種類]ではじめに選択されるものを指定する
		//2番目の「すべてのファイル」が選択されているようにする
		open_ofd.FilterIndex = 1;
		//タイトルを設定する
		open_ofd.Title = title_msg;
		//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
		open_ofd.RestoreDirectory = true;
		//存在しないファイルの名前が指定されたとき警告を表示する
		//デフォルトでTrueなので指定する必要はない
		open_ofd.CheckFileExists = true;
		//存在しないパスが指定されたとき警告を表示する
		//デフォルトでTrueなので指定する必要はない
		open_ofd.CheckPathExists = true;

		//ダイアログを表示する
		if (open_ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{

			//OKボタンがクリックされたとき、選択されたファイル名を表示する
			output_file = open_ofd.FileName;
			return output_file;

		}
		else
		{
			//「いいえ」が選択された時
			err_txt = "操作がキャンセルされました。";
			MessageBox.Show(err_txt);
			return null;
		}

	}

}

